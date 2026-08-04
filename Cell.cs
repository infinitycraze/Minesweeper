using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Minesweeper
{
    public class Cell
    {
        public Cell(bool isEmpty = false, int faceNumber = 0, bool hasMine = false, bool Cleared = false, bool Flagged = false)
        {
            FaceNumber = faceNumber;
            HasMine = hasMine;
            isCleared = Cleared;
            isFlagged = Flagged;
        }

        public int FaceNumber { get; set; }

        public bool HasMine { get; set; }

        bool isCleared;
        bool isFlagged;

        // used for special boards
        // cell is unusable
        bool isEmpty;

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
