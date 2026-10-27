using System.Drawing;

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

        // smiley face states
        public static readonly Image Smiley = Properties.Resources.smiley;
        public static readonly Image SmileyPressed = Properties.Resources.smiley_pressed;
        public static readonly Image Dead = Properties.Resources.dead;
        public static readonly Image Gasp = Properties.Resources.gasp;
        public static readonly Image Win = Properties.Resources.win;

        // seven segment display images
        public static readonly Image SegmentDisplay0 = Properties.Resources.segmentdisplay0;
        public static readonly Image SegmentDisplay1 = Properties.Resources.segmentdisplay1;
        public static readonly Image SegmentDisplay2 = Properties.Resources.segmentdisplay2;
        public static readonly Image SegmentDisplay3 = Properties.Resources.segmentdisplay3;
        public static readonly Image SegmentDisplay4 = Properties.Resources.segmentdisplay4;
        public static readonly Image SegmentDisplay5 = Properties.Resources.segmentdisplay5;
        public static readonly Image SegmentDisplay6 = Properties.Resources.segmentdisplay6;
        public static readonly Image SegmentDisplay7 = Properties.Resources.segmentdisplay7;
        public static readonly Image SegmentDisplay8 = Properties.Resources.segmentdisplay8;
        public static readonly Image SegmentDisplay9 = Properties.Resources.segmentdisplay9;
    }
}
