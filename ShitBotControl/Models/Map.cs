using ShitBotControl.PathFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitBotControl.Models
{
    /// <summary>
    /// The map only contains data on wh
    /// </summary>
    public class Map
    {
        public string Name
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }
        public int Height
        {
            get;
            private set;
        }

        private Intersection[,] intersections;

        public Map(string name, int width, int height)
        {           
            this.Name = name;
            this.Width = width;
            this.Height = height;

            intersections = new Intersection[width, height];

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    intersections[x, y] = new Intersection();
                    intersections[x, y].x = x;
                    intersections[x, y].y = y;
                    intersections[x, y].isEnabled = true;
                    intersections[x, y].isConnectedLeft = (x != 0);
                    intersections[x, y].isConnectedRight = (x < width - 1);
                    intersections[x, y].isConnectedUp = (y != 0);
                    intersections[x, y].isConnectedDown = (y < height - 1);

                }
            }
        }

        public Intersection[,] GetIntersections()
        {
            return intersections;
        }
    }
}
