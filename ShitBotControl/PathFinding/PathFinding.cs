using ShitBotControl.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitBotControl.PathFinding
{
    public class PathFinding
    {
        private Node[,] nodes;

        public PathFinding()
        {

        }

        public void SetMap(Map map)
        {
            nodes = new Node[map.Width, map.Height];
        }

        public void CalculatePath()
        {
            
        }

        public void DrawMap(Graphics g, SolidBrush brush)
        {

        }
    }
}
