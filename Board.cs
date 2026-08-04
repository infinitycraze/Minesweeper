using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Board
    {
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

            numMines = numberOfMines;
        }

        // stores all of the game data in an array
        public Cell[,] Cells;

        bool gameStarted = false;
        public bool GameStarted
        {
            get
            {
                return gameStarted;
            }
        }

        bool gameOver = false;
        public bool GameOver
        {
            get
            {
                return gameOver;
            }
        }

        // used to prevent multiple functions firing at once, possibly causing errors
        private bool isLoading = false;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
        }

        private int numMines;
        public int NumMines
        {
            get
            {
                return NumMines;
            }
        }

        public void StartGame(int posx, int posy)
        {
            isLoading = true;

            Random randomObj = new Random();

            // clicked cell and its surroundings
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
            if (numMines > availableCells.Count)
            {
                numMines = availableCells.Count;
            }

            // place all of the mines except where the first click and its surrounding cells are.

            for (int minesPlaced = 0; minesPlaced < numMines; minesPlaced++)
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

            isLoading = false;
            gameStarted = true;
        }   

        public List<Cell> GetSurroundingCells(int posx, int posy)
        {
            var surroundingCells = new List<Cell>();

            // gets all cells within 1 of the position in either x or y
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
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
                if (isFirst) {
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

            if (gameOver) { return true; }
            if (isLoading) { return false; }

            if (gameStarted == false) { StartGame(posx, posy); }

            isLoading = true;

            bool hitMine = ClearCellHelper(posx, posy, true);
            if (hitMine) { gameOver = true; }

            isLoading = false;

            return hitMine;
        }

        public void FlagCell(int posx, int posy)
        {
            if (isLoading || gameOver || !gameStarted) { return; }
            isLoading = true;

            Cell currentCell;

            currentCell = Cells[posy, posx];

            if (currentCell.IsCleared)
            {
                isLoading = false;
                return;
            }

            // flagging toggles the state of the flag
            currentCell.IsFlagged = !currentCell.IsFlagged;
            isLoading = false;
        }

        // creates a representation of the solved Minesweeper board as a string printed to the console
        // code is now useless after switching to a Forms app; ctrl+k+u to uncomment

        //public void RevealBoard()
        //{
        //    // referece dictionary for all of the numbers' corresponding colors
        //    var numberColoring = new Dictionary<int, ConsoleColor>();
        //    numberColoring.Add(0, ConsoleColor.Gray);
        //    numberColoring.Add(1, ConsoleColor.Blue);
        //    numberColoring.Add(2, ConsoleColor.DarkGreen);
        //    numberColoring.Add(3, ConsoleColor.Red);
        //    numberColoring.Add(4, ConsoleColor.DarkMagenta);
        //    numberColoring.Add(5, ConsoleColor.DarkRed);
        //    numberColoring.Add(6, ConsoleColor.Cyan);
        //    numberColoring.Add(7, ConsoleColor.Black);
        //    numberColoring.Add(8, ConsoleColor.DarkGray);

        //    const ConsoleColor defaultBG = ConsoleColor.Black;
        //    const ConsoleColor defaultFG = ConsoleColor.White;

        //    const ConsoleColor mineColor = ConsoleColor.Black;
        //    const ConsoleColor mineBG = ConsoleColor.Gray;

        //    const ConsoleColor lineColor = ConsoleColor.DarkGray;
        //    const ConsoleColor backgroundColor = ConsoleColor.White;

        //    const char horizontalSeparator = '-';
        //    const char verticalSeparator = '|';
        //    const char mineSymbol = 'X';
        //    const bool includeWhiteSpace = true;

        //    int lineLength = Cells.GetLength(1) * (includeWhiteSpace ? 4 : 2) + 1;

        //    Console.BackgroundColor = backgroundColor;
        //    Console.ForegroundColor = lineColor;

        //    // creates a line the width of the display; the top part of the board
        //    Console.Write(RepeatString(horizontalSeparator.ToString(), lineLength));

        //    // backing the background the default so it doesn't streak on the newline
        //    Console.BackgroundColor = defaultBG;
        //    Console.WriteLine();
        //    Console.BackgroundColor = backgroundColor;

        //    for (int y = 0; y < Cells.GetLength(0); y++)
        //    {
        //        for (int x = 0; x < Cells.GetLength(1); x++)
        //        {
        //            Console.Write(verticalSeparator);

        //            var currentCell = Cells[y, x];

        //            // finding the corresponding color for the numbers; mines are black
        //            Console.ForegroundColor = currentCell.HasMine ? mineColor : numberColoring[currentCell.FaceNumber];

        //            // make the cell the mine symbol if it has a mine, else its number
        //            string symbol = currentCell.HasMine ? mineSymbol.ToString() : currentCell.FaceNumber.ToString();

        //            // "0" is represented as a blank space
        //            symbol = symbol == "0" ? " " : symbol;
        //            // add whitespace
        //            symbol = includeWhiteSpace ? " " + symbol + " " : symbol;
        //            // merge with separator

        //            if (currentCell.HasMine)
        //            {
        //                Console.BackgroundColor = mineBG;
        //            }

        //            Console.Write((symbol == "0" ? " " : symbol));

        //            Console.BackgroundColor = backgroundColor;
        //            Console.ForegroundColor = lineColor;
        //        }

        //        Console.Write(verticalSeparator);

        //        Console.BackgroundColor = defaultBG;
        //        Console.WriteLine();
        //        Console.BackgroundColor = backgroundColor;

        //        Console.Write(RepeatString(horizontalSeparator.ToString(), lineLength));

        //        Console.BackgroundColor = defaultBG;
        //        Console.WriteLine();
        //        Console.BackgroundColor = backgroundColor;
        //    }

        //    Console.BackgroundColor = defaultBG;
        //    Console.ForegroundColor = defaultFG;
        //}

        //// prints a representation of the current game board to the console
        //public void PrintBoard()
        //{
        //    // referece dictionary for all of the numbers' corresponding colors
        //    var numberColoring = new Dictionary<int, ConsoleColor>();
        //    numberColoring.Add(0, ConsoleColor.Gray);
        //    numberColoring.Add(1, ConsoleColor.Blue);
        //    numberColoring.Add(2, ConsoleColor.DarkGreen);
        //    numberColoring.Add(3, ConsoleColor.Red);
        //    numberColoring.Add(4, ConsoleColor.DarkMagenta);
        //    numberColoring.Add(5, ConsoleColor.DarkRed);
        //    numberColoring.Add(6, ConsoleColor.Cyan);
        //    numberColoring.Add(7, ConsoleColor.Black);
        //    numberColoring.Add(8, ConsoleColor.DarkGray);

        //    const ConsoleColor defaultBG = ConsoleColor.Black;
        //    const ConsoleColor defaultFG = ConsoleColor.White;

        //    const ConsoleColor unclearedColor = ConsoleColor.Gray;
        //    const ConsoleColor flagColor = ConsoleColor.Red;
        //    const ConsoleColor lineColor = ConsoleColor.DarkGray;
        //    const ConsoleColor backgroundColor = ConsoleColor.White;

        //    const char horizontalSeparator = '-';
        //    const char verticalSeparator = '|';
        //    const char flagSymbol = 'F';
        //    const bool includeWhiteSpace = true;

        //    int lineLength = Cells.GetLength(1) * (includeWhiteSpace ? 4 : 2) + 1;

        //    Console.BackgroundColor = backgroundColor;
        //    Console.ForegroundColor = lineColor;

        //    // creates a line the width of the display; the top part of the board
        //    Console.Write(RepeatString(horizontalSeparator.ToString(), lineLength));

        //    // backing the background the default so it doesn't streak on the newline
        //    Console.BackgroundColor = defaultBG;
        //    Console.WriteLine();
        //    Console.BackgroundColor = backgroundColor;

        //    for (int y = 0; y < Cells.GetLength(0); y++)
        //    {
        //        for (int x = 0; x < Cells.GetLength(1); x++)
        //        {
        //            Console.Write(verticalSeparator);

        //            var currentCell = Cells[y, x];

        //            // finding the corresponding color for the numbers; mines are black
        //            Console.ForegroundColor = currentCell.IsCleared ? numberColoring[currentCell.FaceNumber] : flagColor;

        //            // make the cell the mine symbol if it has a mine, else its number
        //            string symbol = currentCell.IsCleared ? currentCell.FaceNumber.ToString() : (currentCell.IsFlagged ? flagSymbol.ToString() : " ");

        //            // "0" is represented as a blank space
        //            symbol = symbol == "0" ? " " : symbol;
        //            // add whitespace
        //            symbol = includeWhiteSpace ? " " + symbol + " " : symbol;
        //            // merge with separator

        //            if (!currentCell.IsCleared)
        //            {
        //                Console.BackgroundColor = unclearedColor;
        //            }

        //            Console.Write((symbol == "0" ? " " : symbol));

        //            Console.BackgroundColor = backgroundColor;
        //            Console.ForegroundColor = lineColor;
        //        }

        //        Console.Write(verticalSeparator);

        //        // backing the background the default so it doesn't streak on the newline
        //        Console.BackgroundColor = defaultBG;
        //        Console.WriteLine();
        //        Console.BackgroundColor = backgroundColor;

        //        Console.Write(RepeatString(horizontalSeparator.ToString(), lineLength));

        //        // backing the background the default so it doesn't streak on the newline
        //        Console.BackgroundColor = defaultBG;
        //        Console.WriteLine();
        //        Console.BackgroundColor = backgroundColor;
        //    }

        //    Console.BackgroundColor = defaultBG;
        //    Console.ForegroundColor = defaultFG;
        //}

        //private string RepeatString(string s, int n)
        //{
        //    string result = s;

        //    // add s to itself n-1 times
        //    for (int i = 1; i < n; i++)
        //    {
        //        result += s;
        //    }

        //    return result;
        //}
    }
}
