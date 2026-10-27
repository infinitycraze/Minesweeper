// Name: Liam Lidder
// Date: 8/7/2026
// Assignment: Final Project
// Description: The Form's class. Handles the creation and use of the Board class. Creates a
// grid of PictureBox objects used to visually display the board and allow the user to do actions
// on the board.

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperGame : Form
    {
        const int UpperMarginSize = 70;
        const int MarginSize = 20;
        const int MenuBarSize = 24;
        const int ActionHistorySize = 30;

        // settings presets
        static readonly int[] SmallBoardDims = new int[] { 9, 9 };
        static readonly int[] MediumBoardDims = new int[] { 16, 16 };
        static readonly int[] LargeBoardDims = new int[] { 30, 16 };

        const int LowMineDensity = 12;
        const int MediumMineDensity = 15;
        const int HighMineDensity = 20;

        // board size bounds
        const int MinimumWidth = 9;
        const int MinimumHeight = 5;

        const int MaximumWidth = 60;
        const int MaximumHeight = 30;

        // mine density bounds
        const int MinimumDensity = 5;
        const int MaximumDensity = 75;

        // 3 digit decimal limit
        const int MaxTimerCount = 999;
        // one second
        const int TimerDelayMs = 1000;

        // details about the cells' appearances
        static readonly Point CellOrigin = new Point(0, 0);
        static readonly Size CellSize = new Size(30, 30);

        // default inital board settings
        int[] boardDims = new int[] { 16, 16 };
        int minePercent = 15;
        
        bool isBoardInitialized = false;
        // whether the actionHistory is currently being displayed
        bool actionHistoryShown = false;

        // a list of all of the coordinates the user recently clicked
        List<Point> actionHistory = new List<Point>();
        // a 2D array cantaining the controls to display the game's board
        CellVisual[,] boardVisual;

        public MinesweeperGame()
        {
            InitializeComponent();
            Smiley_Click(Smiley, new EventArgs());
        }

        Board board;

        // used to create the Cell controls and have them with the same appearance and functionality
        private class CellVisual : PictureBox
        {
            public CellVisual(Point position, Size size, Point coords)
            {
                Name = $"cell{coords.X}_{coords.Y}";

                Location = position;
                Size = size;

                SizeMode = PictureBoxSizeMode.StretchImage;
                Image = ImageReferences.New;

                BackColor = Color.Transparent;

                Visible = true;

                Tag = new Point(coords.X, coords.Y);

                WaitOnLoad = false;
            }
        }

        private void ResizeWindow()
        {
            if (!(board is object)) { return; }

            // update the size of the window to fit the board and all of the things to be displayed
            this.Size = new Size(
                boardDims[0] * CellSize.Width + MarginSize * 2, 
                boardDims[1] * CellSize.Height + MarginSize * 3 + UpperMarginSize + MenuBarSize + 
                ActionHistorySize * (actionHistoryShown ? 1 : 0));

            // resize & reposition the action history label
            if (actionHistoryShown)
            {
                ActionHistoryLabel.Location = new Point(
                    ActionHistoryLabel.Location.X, 
                    boardDims[1] * CellSize.Height + MarginSize * 4 + MenuBarSize);

                // makes the width of the control be the same width as the board
                ActionHistoryLabel.Size = new Size(
                    boardDims[0] * CellSize.Width,
                    ActionHistorySize);
            }
        }

        // Board handling:

        // creates the board in cells on the windows form
        // by default is in the starting position; for representation of board states use UpdateBoardVisual
        private void GenerateBoardVisual(Point cellOrigin, Size cellSize)
        {
            for (int y = 0; y < board.Cells.GetLength(0); y++)
            {
                for (int x = 0; x < board.Cells.GetLength(1); x++)
                {
                    CellVisual newCellVisual = new CellVisual(
                        // calculate where to place the cell from the origin
                        new Point(cellOrigin.X + x * cellSize.Width, cellOrigin.Y + y * cellSize.Height),
                        cellSize,
                        new Point(x, y));

                    MinePanel.Controls.Add(newCellVisual);
                    boardVisual[y, x] = newCellVisual;
                    CellEventHandlers(newCellVisual);
                }
            }
        }

        // updates the appearance of the Pictureboxes on the screen to match the state of the board
        private void UpdateBoardVisual(bool isGameOver = false)
        {
            // loop through all cells
            for (int y = 0; y < board.Cells.GetLength(0); y++)
            {
                for (int x = 0; x < board.Cells.GetLength(1); x++)
                {
                    Cell cell = board.Cells[y, x];

                    if (cell.IsCleared)
                    {
                        if (isGameOver && cell.HasMine)
                        {
                            boardVisual[y, x].Image = ImageReferences.HitMine;
                            continue;
                        }

                        // matches the cell's FaceNumber to the image values
                        switch (cell.FaceNumber)
                        {
                            case 0:
                                boardVisual[y, x].Image = ImageReferences.Clear;
                                break;
                            case 1:
                                boardVisual[y, x].Image = ImageReferences.Number1;
                                break;
                            case 2:
                                boardVisual[y, x].Image = ImageReferences.Number2;
                                break;
                            case 3:
                                boardVisual[y, x].Image = ImageReferences.Number3;
                                break;
                            case 4:
                                boardVisual[y, x].Image = ImageReferences.Number4;
                                break;
                            case 5:
                                boardVisual[y, x].Image = ImageReferences.Number5;
                                break;
                            case 6:
                                boardVisual[y, x].Image = ImageReferences.Number6;
                                break;
                            case 7:
                                boardVisual[y, x].Image = ImageReferences.Number7;
                                break;
                            case 8:
                                boardVisual[y, x].Image = ImageReferences.Number8;
                                break;
                            default:
                                throw new ArgumentException("Cell has invalid FaceNumber value.", $"board.Cells[{y},{x}].FaceNumber");
                        }
                    }
                    else
                    {
                        if (isGameOver && cell.HasMine)
                        {
                            boardVisual[y, x].Image = cell.IsFlagged ? ImageReferences.Flag : ImageReferences.Mine;
                            continue;
                        }

                        // if isGameOver then the cell has been flagged without a mine
                        if (cell.IsFlagged)
                        {
                            boardVisual[y, x].Image = isGameOver ? ImageReferences.FalseFlag : ImageReferences.Flag;
                        }
                        else
                        {
                            boardVisual[y, x].Image = ImageReferences.New;
                        }
                    }
                }
            }
        }

        // when the game is over and a new game needs to start
        private void ClearBoard()
        {
            foreach (CellVisual cv in boardVisual)
            {
                MinePanel.Controls.Remove(cv);
            }

            actionHistory.Clear();

            if (actionHistoryShown)
            {
                UpdateActionHistory();
            }

            isBoardInitialized = false;
            Smiley.Image = ImageReferences.Smiley;
        }

        // event handlers for each individual cell to detect user actions 
        private void CellEventHandlers(CellVisual cell)
        {
            Point cellPos = (Point)cell.Tag;
            Cell boardCell = board.Cells[cellPos.Y, cellPos.X];

            cell.MouseClick += (object sender, MouseEventArgs e) =>
            {
                if (!board.GameOver)
                {
                    // ctrl + click is an alternate way to flag other than right click
                    if (e.Button == MouseButtons.Right || 
                    (e.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.Control))
                    {
                        board.FlagCell(cellPos.X, cellPos.Y);
                        UpdateBoardVisual();
                        UpdateMineCount();
                    }
                    else if (e.Button == MouseButtons.Left)
                    {
                        if (!board.GameStarted) {
                            // this is when the game starts (first cell cleared)
                            // the first cell will always be clear
                            board.ClearCell(cellPos.X, cellPos.Y);
                            UpdateBoardVisual();
                            StartTimer();
                        } 
                        else
                        {
                            // any cell cleared after the start of the game
                            bool hitMine = board.ClearCell(cellPos.X, cellPos.Y);
                            UpdateBoardVisual(hitMine);

                            if (hitMine)
                            {
                                // if the user lost, the loss indicator shows (dead smiley)
                                Smiley.Image = ImageReferences.Dead;
                                // loss message
                                MessageBox.Show($"You hit a mine!\nGames Played: {Board.CalculateGamesPlayed()}\nWins/Losses: {Board.GamesWon}/{Board.GamesLost}");
                            }
                            else if (board.CheckWin())
                            {
                                // if the user won, the win indicator shows (smiley with glasses)
                                Smiley.Image = ImageReferences.Win;
                                // win message
                                MessageBox.Show($"You Won!\nGames Played: {Board.CalculateGamesPlayed()}\nWins/Losses: {Board.GamesWon}/{Board.GamesLost}");
                            }
                        }

                        // adds the cell to the actionHistory if it is a unique action
                        if (!boardCell.IsFlagged && !actionHistory.Contains(cellPos))
                        {
                            actionHistory.Add(cellPos);

                            if (actionHistoryShown)
                            {
                                UpdateActionHistory();
                            }
                        }
                    } 
                }
            };

            // detection of mouse up/down of cells for the cell pressed animation
            // game cannot be over, the cell has to be uncleared, and the user has to use LMB without pressing CTRL
            cell.MouseDown += (object sender, MouseEventArgs e) =>
            {
                if (board.GameOver || boardCell.IsCleared || boardCell.IsFlagged || e.Button != MouseButtons.Left || (Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return;
                }

                cell.Image = ImageReferences.Clear;
                Smiley.Image = ImageReferences.Gasp;
            };

            cell.MouseUp += (object sender, MouseEventArgs e) =>
            {
                if (board.GameOver || e.Button != MouseButtons.Left)
                {
                    return;
                }

                Smiley.Image = ImageReferences.Smiley;

                if (boardCell.IsCleared || boardCell.IsFlagged)
                {
                    return;
                }

                cell.Image = ImageReferences.New;
            };
        }

        // Smiley event handlers:

        // smiley face pressed animation
        private void Smiley_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Smiley.Image = ImageReferences.SmileyPressed;
            }
        }

        private void Smiley_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Smiley.Image = ImageReferences.Smiley;
            }
        }

        // pressing the smiley face initiates the creation of a new board & deletes the old board
        private void Smiley_Click(object sender, EventArgs e)
        {
            if (board is object && isBoardInitialized && !board.IsLoading)
            {
                ClearBoard();
            }

            // prevent code from firing multiple times
            if (isBoardInitialized) return;
            isBoardInitialized = true;

            // this is when a new board has been generated

            board = new Board(boardDims[0], boardDims[1], minePercent * boardDims[0] * boardDims[1] / 100);
            boardVisual = new CellVisual[board.Cells.GetLength(0), board.Cells.GetLength(1)];

            GenerateBoardVisual(CellOrigin, CellSize);

            // resets the segment displays
            UpdateMineCount();
            UpdateSegmentDisplay(0, TimerHundreds);
            UpdateSegmentDisplay(0, TimerTens);
            UpdateSegmentDisplay(0, TimerOnes);

            ResizeWindow();
        }

        // Action history:
        private void UpdateActionHistory()
        {
            const string LeftBracket = "(";
            const string RightBracket = ")";
            const string CoordinateConcatenation = ", ";
            const string ActionHistoryConcatenation = ", ";

            // if there is no history yet, display "None"
            if (actionHistory.Count == 0)
            {
                ActionHistoryLabel.Text = "None";
                return;
            }

            int i = actionHistory.Count;
            string fullHistory = "";

            // converts the actionHistory to a string
            while (i > 0)
            {
                --i;
                fullHistory += LeftBracket + actionHistory[i].X + CoordinateConcatenation + actionHistory[i].Y + RightBracket + (i > 0 ? ActionHistoryConcatenation : "");
            }

            ActionHistoryLabel.Text = fullHistory;
        }

        // toggles the display of the action history
        private void ShowActionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actionHistoryShown)
            {
                actionHistoryShown = false;
                ActionHistoryLabel.Visible = false;
                ResizeWindow();
            } 
            else
            {
                actionHistoryShown = true;
                UpdateActionHistory();
                ResizeWindow();

                ActionHistoryLabel.Visible = true;
            }
        }

        // Segment Displays:

        // chages the image of a segment display PictureBox to match the given number
        void UpdateSegmentDisplay(int placeValue, PictureBox display)
        {
            switch (placeValue)
            {
                case 0:
                    display.Image = ImageReferences.SegmentDisplay0;
                    break;
                case 1:
                    display.Image = ImageReferences.SegmentDisplay1;
                    break;
                case 2:
                    display.Image = ImageReferences.SegmentDisplay2;
                    break;
                case 3:
                    display.Image = ImageReferences.SegmentDisplay3;
                    break;
                case 4:
                    display.Image = ImageReferences.SegmentDisplay4;
                    break;
                case 5:
                    display.Image = ImageReferences.SegmentDisplay5;
                    break;
                case 6:
                    display.Image = ImageReferences.SegmentDisplay6;
                    break;
                case 7:
                    display.Image = ImageReferences.SegmentDisplay7;
                    break;
                case 8:
                    display.Image = ImageReferences.SegmentDisplay8;
                    break;
                case 9:
                    display.Image = ImageReferences.SegmentDisplay9;
                    break;
                default:
                    // if value is not a digit
                    throw new ArgumentException("Input must be an integer 0-9.");
            }
        }

        // updates the mine count display to match the # of remaining unflagged mines
        void UpdateMineCount()
        {
            // if the value is less than 0, it becomes 0
            int minesRemaining = Math.Max(board.NumMines - board.FlagCount, 0);

            UpdateSegmentDisplay(minesRemaining / 100, MineCounterHundreds);
            UpdateSegmentDisplay(minesRemaining / 10 % 10, MineCounterTens);
            UpdateSegmentDisplay(minesRemaining % 10, MineCounterOnes);
        }

        // timer
        private async void StartTimer()
        {
            int initalGameNo = Board.GameID;
            // is -1 because addition happens first
            int timePassed = -1;

            // keeps looping until the number of games changes
            while (initalGameNo == Board.GameID && !board.GameOver)
            {
                ++timePassed;

                // update each individual digit (only updates greater digits when needed)
                if (timePassed % 100 == 0) { UpdateSegmentDisplay(timePassed / 100, TimerHundreds); }
                if (timePassed % 10 == 0) { UpdateSegmentDisplay(timePassed / 10 % 10, TimerTens); }
                UpdateSegmentDisplay(timePassed % 10, TimerOnes);

                // the timer maxxes out after 999 seconds; no point in updating it
                if (timePassed >= MaxTimerCount) { return; }

                // waits 1 second
                await Task.Delay(TimerDelayMs);
            }
        }

        // Board Attributes:

        // changes the size of the board and generates a new board
        private void ResizeBoard(int[] dimensions)
        {
            boardDims[0] = dimensions[0];
            boardDims[1] = dimensions[1];
            Smiley_Click(Smiley, new EventArgs());
        }
        
        // changes the number of mines in the board and generates a new board
        private void ChangeDensity(int newPercentage)
        {
            minePercent = newPercentage;
            Smiley_Click(Smiley, new EventArgs());
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeBoard(SmallBoardDims);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeBoard(MediumBoardDims);
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeBoard(LargeBoardDims);
        }

        private void LowMineDensityMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDensity(LowMineDensity);
        }

        private void MediumMineDensityMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDensity(MediumMineDensity);
        }

        private void HighMineDensityMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDensity(HighMineDensity);
        }


        // when the board size is set to a custom size
        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // attempt to parse textbox values to ints
            if (!int.TryParse(WidthTextbox.Text, out int width))
            {
                return;
            }

            if (!int.TryParse(HeightTextbox.Text, out int height))
            {
                return;
            }

            // if the value is out of bounds, confine it to bounds
            if (width < MinimumWidth)
            {
                width = MinimumWidth;
                WidthTextbox.Text = MinimumWidth.ToString();
            }

            if (width > MaximumWidth)
            {
                width = MaximumWidth;
                WidthTextbox.Text = MaximumWidth.ToString();
            }

            // if the value is out of bounds, confine it to bounds
            if (height < MinimumHeight)
            {
                height = MinimumHeight;
                HeightTextbox.Text = MinimumHeight.ToString();
            }

            if (height > MaximumHeight)
            {
                height = MaximumHeight;
                HeightTextbox.Text = MaximumHeight.ToString();
            }

            ResizeBoard(new int[] {width, height});
        }

        // when the enter is pressed on the custom mine density textbox
        private void MineDensityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!int.TryParse(MineDensityTextBox.Text, out int mineDensity))
                {
                    MineDensityTextBox.Text = minePercent.ToString();
                    return;
                }

                if (mineDensity < MinimumDensity)
                {
                    mineDensity = MinimumDensity;
                    MineDensityTextBox.Text = MinimumDensity.ToString();
                }

                if (mineDensity > MaximumDensity)
                {
                    mineDensity = MaximumDensity;
                    MineDensityTextBox.Text = MaximumDensity.ToString();
                }

                ChangeDensity(mineDensity);
            }
        }
    }
}