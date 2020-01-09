using Microsoft.Xna.Framework.Graphics;
using ShitBotControl.EditorComponents;
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
        private Map map;

        private Node[,] nodes;
        private Rectangle[,] rects;
        private Rectangle[,] nodeConnection;

        private int shitbotX;
        private int shitbotY;
        private int shitbotRot;
        private int endpointX;
        private int endpointY;

        public int Rotation
        {
            get => shitbotRot;
            set => shitbotRot = value;
        }

        private Point[] path; 

        public PathFinding()
        {
            shitbotX = -1;
            shitbotY = -1;
            shitbotRot = 0;
            endpointX = -1;
            endpointY = -1;
        }

        public void SetMap(Map map)
        {
            this.map = map;

            shitbotX = -1;
            shitbotY = -1;
            endpointX = -1;
            endpointY = -1;

            //create node array
            nodes = new Node[map.Width, map.Height];
            rects = new Rectangle[map.Width, map.Height];
            //get intersections
            Intersection[,] intsect = map.GetIntersections();
            nodeConnection = new Rectangle[map.Width * 2, map.Height * 2];

            //create nodes
            for(int x = 0; x < map.Width; x++)
            {
                for(int y = 0; y < map.Height; y++)
                {
                    nodes[x, y] = new Node(true);
                    nodes[x, y].x = x;
                    nodes[x, y].y = y;
                    rects[x, y] = new Rectangle(24 + 48 * x, 24 + 48 * y, 16, 16);
                }
            }

            for (int x = 0; x < (map.Width * 2) -1; x++)
            {
                for (int y = 0; y < (map.Height * 2) -1; y++)
                {
                    if((x % 2 == 1 || y % 2 == 1) && !(x % 2 == 1 && y % 2 == 1))
                        nodeConnection[x, y] = new Rectangle(24 + 24 * x, 24 + 24 * y, 16, 16);
                }
            }

            //connect nodes
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    //check if node is enabled
                    if(nodes[x, y].isEnabled)
                    {
                        //check if up is connected
                        if(intsect[x, y].isConnectedUp)
                        {
                            nodes[x, y].n_up = nodes[x, y-1];
                        }

                        //check if right is connected
                        if (intsect[x, y].isConnectedRight)
                        {
                            nodes[x, y].n_right = nodes[x+1, y];
                        }

                        //check if down is connected
                        if (intsect[x, y].isConnectedDown)
                        {
                            nodes[x, y].n_down = nodes[x, y+1];
                        }

                        //check if left is connected
                        if (intsect[x, y].isConnectedLeft)
                        {
                            nodes[x, y].n_left = nodes[x-1, y];
                        }
                    }
                }
            }
        }

        public void SetShitBot(int x, int y)
        {
            for (int xr = 0; xr < map.Width; xr++)
            {
                for (int yr = 0; yr < map.Height; yr++)
                {
                    if(rects[xr, yr].Contains(x, y))
                    {
                        if (shitbotX == xr && shitbotY == yr)
                        {
                            shitbotRot++;
                            shitbotRot = shitbotRot % 4;
                            return;
                        }
                        else
                        {
                            shitbotX = xr;
                            shitbotY = yr;
                            shitbotRot = 2;
                            return;
                        }
                    }
                }
            }
        }

        public void SetEndPoint(int x, int y)
        {
            for (int xr = 0; xr < map.Width; xr++)
            {
                for (int yr = 0; yr < map.Height; yr++)
                {
                    if (rects[xr, yr].Contains(x, y))
                    {
                        endpointX = xr;
                        endpointY = yr;
                        return;
                    }
                }
            }
        }

        public void SetConnection(int xx, int yy)
        {
            for (int x = 0; x < (map.Width * 2) - 1; x++)
            {
                for (int y = 0; y < (map.Height * 2) - 1; y++)
                {
                    if ((x % 2 == 1 || y % 2 == 1) && !(x % 2 == 1 && y % 2 == 1))
                    {
                        if(nodeConnection[x, y] != null)
                        {
                            if (nodeConnection[x, y].Contains(xx, yy))
                            {
                                if (x % 2 == 1 && y % 2 == 0)
                                {
                                    int nodex1 = (x / 2);
                                    int nodex2 = (int)(((float)x / 2f) + 0.5f);

                                    nodes[nodex1, y/2].n_right = nodes[nodex2, y/2];
                                    nodes[nodex2, y/2].n_left = nodes[nodex1, y/2];
                                }
                                else if (x % 2 == 0 && y % 2 == 1)
                                {
                                    int nodey1 = (y / 2);
                                    int nodey2 = (int)(((float)y / 2f) + 0.5f);

                                    nodes[x/2, nodey1].n_down = nodes[x/2, nodey2];
                                    nodes[x/2, nodey2].n_up = nodes[x/2, nodey1];
                                }
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void RemoveConnection(int xx, int yy)
        {
            for (int x = 0; x < (map.Width * 2) - 1; x++)
            {
                for (int y = 0; y < (map.Height * 2) - 1; y++)
                {
                    if ((x % 2 == 1 || y % 2 == 1) && !(x % 2 == 1 && y % 2 == 1))
                    {
                        if (nodeConnection[x, y] != null)
                        {
                            if (nodeConnection[x, y].Contains(xx, yy))
                            {
                                if (x % 2 == 1 && y % 2 == 0)
                                {
                                    int nodex1 = (x / 2);
                                    int nodex2 = (int)(((float)x / 2f) + 0.5f);

                                    nodes[nodex1, y/2].n_right = null;
                                    nodes[nodex2, y/2].n_left = null;
                                }
                                else if(x % 2 == 0 && y % 2 == 1)
                                {
                                    int nodey1 = (y / 2);
                                    int nodey2 = (int)(((float)y / 2f) + 0.5f);

                                    nodes[x/2, nodey1].n_down = null;
                                    nodes[x/2, nodey2].n_up = null;
                                }
                                return;
                            }
                        }
                    }
                }
            }
        }

        public Point[] CalculatePath()
        {
            if(map != null)
            {
                if (endpointX != -1 && endpointY != -1 && shitbotX != -1 && shitbotY != -1)
                {
                    List<Point> plist = new List<Point>();

                    //reset every node
                    foreach (Node n in nodes)
                    {
                        n.currentState = Node.State.DORMANT;
                        n.previousNode = null;
                    }

                    //set endpoint alive
                    nodes[endpointX, endpointY].currentState = Node.State.ALIVE;
                    nodes[endpointX, endpointY].weight = 0;

                    Tick();

                    Node nd = nodes[shitbotX, shitbotY];
                    plist.Add(new Point(nd.x, nd.y));

                    while(nd.previousNode != null)
                    {
                        
                        nd = nd.previousNode;
                        plist.Add(new Point(nd.x, nd.y));
                    }
                    
                    path = plist.ToArray();

                    return path;
                }
            }

            return null;
        }

        private void Tick()
        {
            bool isRunning = true;

            while (isRunning) {
                //set waking up nodes to alive
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        if (nodes[x, y].currentState == Node.State.WAKING_UP)
                        {
                            nodes[x, y].currentState = Node.State.ALIVE;
                        }
                    }
                }

                //wake up other nodes
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        if (nodes[x, y].currentState == Node.State.ALIVE)
                        {
                            nodes[x, y].Update();
                            nodes[x, y].currentState = Node.State.DEATH;
                        }
                    }
                }


                if(nodes[shitbotX, shitbotY].currentState == Node.State.DEATH)
                {
                    isRunning = false;
                }


                bool isOneAlive = false;
                foreach(Node n in nodes)
                {
                    if(n.currentState != Node.State.DEATH)
                    {
                        isOneAlive = true;
                        break;
                    }
                }

                if (!isOneAlive)
                {
                    isRunning = false;
                }

            }

        }

        public void SetShitBotPosition(int x, int y)
        {
            shitbotX = x;
            shitbotY = y;
        }

        public void Reset()
        {            
            shitbotX = endpointX;
            shitbotY = endpointY;
            endpointX = -1;
            endpointY = -1;
            path = null;
        }

        public void DrawMap(EditorScene e)
        {
            //for (int x = 0; x < map.Width; x++)
            //{
            //    for (int y = 0; y < map.Height; y++)
            //    {
            //            e.DrawHitBoxes(rects[x,y].X, rects[x,y].Y, rects[x,y].Width, rects[x,y].Height, true);
            //    }
            //}

            //for (int x = 0; x < map.Width * 2; x++)
            //{
            //    for (int y = 0; y < map.Height * 2; y++)
            //    {
            //        if(nodeConnection[x, y] != null)
            //            e.DrawHitBoxes(nodeConnection[x, y].X, nodeConnection[x, y].Y, nodeConnection[x, y].Width, nodeConnection[x, y].Height, false);
            //    }
            //}

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    e.DrawConnection(nodes[x, y], 32 + 48 * x, 32 + 48 * y);
                }
            }

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    e.DrawNode(32 + 48 * x, 32 + 48 * y);
                }
            }


            if(path != null)
            {
                int x1 = path[0].X, y1 = path[0].Y;

                for(int i = 1; i < path.Length; i++)
                {
                    e.DrawLine(32 + 48 * x1, 32 + 48 * y1, 32 + 48 * path[i].X, 32 + 48 * path[i].Y);
                    x1 = path[i].X;
                    y1 = path[i].Y;
                }
            }

            e.DrawEndPoint(32 + 48 * endpointX, 32 + 48 * endpointY);
            e.DrawShitBot(32 + 48 * shitbotX, 32 + 48 * shitbotY, shitbotRot);

        }
    }
}
