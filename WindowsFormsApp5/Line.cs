using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp5
{
    class Line
    {
        private Point[] coord = new Point[2];
        private Pen blackpen;
        public Line(int x1, int y1, int x2, int y2)
        {
            coord[0].X = x1;
            coord[0].Y = y1;
            coord[1].X = x2;
            coord[1].Y = y2;
            blackpen = new Pen(Color.Black);
        }
        public int X1 { get { return coord[0].X; } }
        public int Y1 { get { return coord[0].Y; } }
        public int X2 { get { return coord[1].X; } }
        public int Y2 { get { return coord[1].Y; } }
        public Graphics Draw(Graphics graf)
        {
            graf.DrawLine(blackpen, coord[0], coord[1]);
            return graf;
        }
    }
}
