using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperBoard : Form
    {
        // details about the cells' appearances
        static readonly Point CellOrigin = new Point(0, 0);
        static readonly Size CellSize = new Size(30, 30);

        static readonly int[] BoardDims = new int[] { 25, 15 };
        const int MineNum = 100;
        
        // temporary
        bool db = false;

        // the current cell which the mouse is over
        CellVisual hoveredCell;

        CellVisual[,] boardVisual;

        public MinesweeperBoard()
        {
            InitializeComponent();
        }

        Board board;

        // used to create the Cell controls and have them with the same appearance
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
            }
        }

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
                        new Point(x, y)
                        );

                    MinePanel.Controls.Add(newCellVisual);
                    boardVisual[y, x] = newCellVisual;
                    CellEventHandlers(newCellVisual);
                }
            }
        }

        private void UpdateBoardVisual(bool isGameOver = false)
        {
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

            db = false;
        }

        // event handlers for the panel to see the targeted cells of the cursor
        private void CellEventHandlers(CellVisual cell)
        {
            Point cellPos = (Point)cell.Tag;
            Cell boardCell = board.Cells[cellPos.Y, cellPos.X];

            cell.MouseClick += (object sender, MouseEventArgs e) =>
            {
                // if the cell is already cleared, it cannot be cleared again
                if (!board.GameOver)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // ClearCell returns true if the user hits a mine
                        UpdateBoardVisual(board.ClearCell(cellPos.X, cellPos.Y));
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        board.FlagCell(cellPos.X, cellPos.Y);
                        UpdateBoardVisual();
                    }
                }
            };

            cell.MouseEnter += (object sender, EventArgs e) =>
            {
                if (board.GameOver || boardCell.IsCleared || boardCell.IsFlagged)
                {
                    return;
                }

                if (Control.MouseButtons == MouseButtons.Left)
                {
                    cell.Image = ImageReferences.Clear;
                }
                
            };

            cell.MouseLeave += (object sender, EventArgs e) =>
            {
                if (board.GameOver || boardCell.IsCleared || boardCell.IsFlagged)
                {
                    return;
                }

                cell.Image = ImageReferences.New;
            };
        }




        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Smiley_Click(object sender, EventArgs e)
        {
            // prevent code from firing multiple times
            if (board is object && board.GameOver && db)
            {
                ClearBoard();
            }



            if (db) return;
            db = true;

            MessageBox.Show("making board");

            board = new Board(BoardDims[0], BoardDims[1], MineNum);
            
            boardVisual = new CellVisual[board.Cells.GetLength(0), board.Cells.GetLength(1)];

            GenerateBoardVisual(CellOrigin, CellSize);
            
        }

        private void DimensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MinesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

// TODO:
// add timer
// add mine counter
// make face have expressions
// make the window resize with the board
// let the user be able to change settings (board size & mine count)
// add more details to mimick te original game
