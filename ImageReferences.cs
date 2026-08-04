using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    // all images are 30x30
    static public class ImageReferences
    {
        // cell images
        public static readonly Image New = Properties.Resources.newsweeper;
        public static readonly Image Clear = Properties.Resources.clearsweeper;

        // number images
        public static readonly Image Number1 = Properties.Resources.sweeper1;
        public static readonly Image Number2 = Properties.Resources.sweeper2;
        public static readonly Image Number3 = Properties.Resources.sweeper3;
        public static readonly Image Number4 = Properties.Resources.sweeper4;
        public static readonly Image Number5 = Properties.Resources.sweeper5;
        public static readonly Image Number6 = Properties.Resources.sweeper6;
        public static readonly Image Number7 = Properties.Resources.sweeper7;
        public static readonly Image Number8 = Properties.Resources.sweeper8;

        // special
        public static readonly Image Flag = Properties.Resources.flagsweeper;
        public static readonly Image HitMine = Properties.Resources.hitmine;
        public static readonly Image Mine = Properties.Resources.mine;
        public static readonly Image FalseFlag = Properties.Resources.falsemine;

    }
}
