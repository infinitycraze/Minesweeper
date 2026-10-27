// Name: Liam Lidder
// Date: 8/7/2026
// Assignment: Final Project
// Description: Creates a grid of Cells and populates them with mines, alongside labeling cells according
// to the number of nearby mines surrounding them. Has mathods corresponding to action that the user can 
// to the board, such as clearing and flagging cells.

using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Board
    {
        // can only be altered from within the class
        public static int GameID { get; private set; } = 0;

        public static int GamesWon { get; private set; } = 0;
        public static int GamesLost { get; private set; } = 0;

        // board initializer; generated upon starting new game
        public Board(int dimx, int dimy, int numberOfMines)
        {
            // board is stored as a series of rows
            Cells = new Cell[dimy, dimx];

            for (int y = 0; y < dimy; y++)
            {
                for (int x = 0; x < dimx; x++)
                {
                    Cells[y, x] = new Cell();
                }
            }

            // upon the start of the game, there are always 9 empty cells, so nine is cubtracted from the total number of cells
            if (numberOfMines > dimx * dimy - 9)
            {
                throw new ArgumentException("numberOfMines must be less than the amount of cells on the board not counting the initial nine cells.");
            }

            NumMines = numberOfMines;
            ++GameID;
        }

        // stores all of the game data in an array
        public Cell[,] Cells;

        // Properties:

        public bool GameStarted { get; private set; } = false;

        public bool GameOver { get; private set; } = false;

        // used to prevent multiple functions firing at once, possibly causing errors
        public bool IsLoading { get; private set; } = false;

        public int NumMines { get; private set; }

        public int FlagCount { get; private set; } = 0;

        public void StartGame(int posx, int posy)
        {
            IsLoading = true;

            // random object to choose the mines
            Random randomObj = new Random();

            // clicked cell and its surroundings
            // the user can never click on a mine on first click
            var clearCells = GetSurroundingCells(posx, posy);
            clearCells.Add(Cells[posy, posx]);

            var availableCells = new List<Cell>();

            foreach (var cell in Cells)
            {
                // skip over the required clear cells
                if (!clearCells.Contains(cell))
                {
                    availableCells.Add(cell);
                }
            }

            // if # of mines is impossible, remove mines
            if (NumMines > availableCells.Count)
            {
                NumMines = availableCells.Count;
            }

            // place all of the mines except where the first click and its surrounding cells are.

            for (int minesPlaced = 0; minesPlaced < NumMines; minesPlaced++)
            {
                int selectedIndex = randomObj.Next(availableCells.Count);

                // chooses a random cell from the List, places a mine, then removes it
                Cell selectedCell = availableCells[selectedIndex];
                selectedCell.HasMine = true;
                availableCells.RemoveAt(selectedIndex);
            }

            // determine number values (surrounding mine count)
            // go through each cell and count the number of surrounding mines it has
            // maybe this could be done while placing mines?? (but it would probably require that the cell classes also have positional data as well)
            for (int y = 0; y < Cells.GetLength(0); y++)
            {
                for (int x = 0; x < Cells.GetLength(1); x++)
                {
                    int mineCount = 0;

                    foreach (var cell in GetSurroundingCells(x, y))
                    {
                        if (cell.HasMine)
                        {
                            mineCount++;
                        }
                    }

                    Cells[y, x].FaceNumber = mineCount;
                }
            }

            IsLoading = false;
            GameStarted = true;
        }

        // returns a list of cells adjacent to a position, including diagonally
        public List<Cell> GetSurroundingCells(int posx, int posy)
        {
            var surroundingCells = new List<Cell>();

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    // skip the given cell
                    if (x == 0 && y == 0) { continue; }

                    try
                    {
                        surroundingCells.Add(Cells[y + posy, x + posx]);
                    }
                    // if the surrounding cell doesn't exist (edge case) skip over it
                    catch (IndexOutOfRangeException) { }
                }
            }

            return surroundingCells;
        }

        // a helper function which allows for recursion for the 0 auto-clear and the ability to clear the surrounding cells by clicking on a number
        private bool ClearCellHelper(int posx, int posy, bool isFirst = false)
        {
            Cell currentCell;

            // recursion can reach invalid edge cells; precaution
            try
            {
                currentCell = Cells[posy, posx];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

            if (currentCell.IsCleared)
            {
                // the rescursion can hit a mine too if a flag is placed wrong, so it will stop
                bool hitMine = false;

                // if the cell is cleared, then it can clear neighboring cells
                // isFirst is a precaution to prevent infinite recursion
                if (isFirst)
                {
                    int flagCount = 0;

                    foreach (Cell surroundingCell in GetSurroundingCells(posx, posy))
                    {
                        if (surroundingCell.IsFlagged)
                        {
                            ++flagCount;
                        }
                    }

                    // the number of flags has to be equal to the number of mines
                    if (flagCount == currentCell.FaceNumber)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            for (int x = -1; x <= 1; x++)
                            {
                                if (x == 0 && y == 0)
                                {
                                    continue;
                                }

                                if (ClearCellHelper(posx + x, posy + y))
                                {
                                    hitMine = true;
                                }
                            }
                        }
                    }
                }

                return hitMine;
            }
            
            if (currentCell.IsFlagged)
            {
                return false;
            }

            currentCell.IsCleared = true;

            if (currentCell.HasMine)
            {
                return true;
            }

            // if the cell is 0, automatically clear surrounding cells
            if (currentCell.FaceNumber == 0)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        // doesn't clear itself
                        if (x == 0 && y == 0)
                        {
                            continue;
                        }

                        ClearCellHelper(posx + x, posy + y);
                    }
                }
            }

            return false;
        }


        public bool ClearCell(int posx, int posy)
        {

            if (GameOver) { return true; }
            if (IsLoading) { return false; }

            if (GameStarted == false) { StartGame(posx, posy); }

            IsLoading = true;

            bool hitMine = ClearCellHelper(posx, posy, true);

            if (hitMine) 
            {
                ++GamesLost;
                GameOver = true;
            }

            IsLoading = false;

            return hitMine;
        }

        public void FlagCell(int posx, int posy)
        {
            if (IsLoading || GameOver || !GameStarted) { return; }
            IsLoading = true;

            Cell currentCell;

            currentCell = Cells[posy, posx];

            if (currentCell.IsCleared)
            {
                IsLoading = false;
                return;
            }

            // flagging toggles the state of the flag
            // update FlagCount
            if (currentCell.IsFlagged)
            {
                currentCell.IsFlagged = false;
                --FlagCount;
            }
            else
            {
                currentCell.IsFlagged = true;
                ++FlagCount;
            }

            IsLoading = false;
        }

        // returns true if the game is over and the user cleared all cells without hitting a mine
        public bool CheckWin()
        {
            // prevents the win from being checked twice
            if (GameOver) { return false; }

            foreach (Cell cell in this.Cells)
            {
                // all cells without mines must be cleared, all cells with mines must not, else return
                if (cell.IsCleared == cell.HasMine)
                {
                    return false;
                }
            }

            ++GamesWon;
            GameOver = true;

            return true;
        }

        public static int CalculateGamesPlayed()
        {
            return GamesWon + GamesLost;
        }
    }
}