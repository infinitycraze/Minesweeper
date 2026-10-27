// Name: Liam Lidder
// Date: 8/7/2026
// Assignment: Final Project
// Description: Represents a singular cell of the board, with properties such as isCleared and isFlagged representing
// the cell's state.

using System;

namespace Minesweeper
{
    public class Cell
    {
        public Cell(int faceNumber = 0, bool hasMine = false, bool Cleared = false, bool Flagged = false)
        {
            FaceNumber = faceNumber;
            HasMine = hasMine;
            isCleared = Cleared;
            isFlagged = Flagged;
        }

        int faceNumber { get; set; }

        public bool HasMine { get; set; }

        bool isCleared;
        bool isFlagged;

        public int FaceNumber
        {
            get
            {
                return faceNumber;
            }
            set
            {
                if (value >= 0 && value <= 8)
                {
                    faceNumber = value;
                }
                else
                {
                    throw new ArgumentException("Cell's FaceNumber value must be within 0 and 8.");
                }
            }
        }

        public bool IsCleared
        {
            get
            {
                return isCleared;
            }
            set
            {
                // prevent user from clearing a flagged space
                {
                    isCleared = value && !IsFlagged;
                }
            }
        }

        public bool IsFlagged
        {
            get
            {
                return isFlagged;
            }
            set
            {
                // prevent user from flagging a cleared space
                isFlagged = value && !IsCleared;
            }
        }
    }
}
