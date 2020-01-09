using NetworkTest.ShittyNetCode.Messages;
using ShitBotControl.EditorComponents;
using ShitBotControl.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShitBotControl.Controllers
{
    public class cnt_Route : Controller
    {
        private EditorScene editorScene;
        private Map map;
        private PathFinding.PathFinding pathFinding;

        public cnt_Route(Form form, EditorScene editorScene) : base(form)
        {
            this.editorScene = editorScene;
            map = new Map("test map", 11, 6);
            pathFinding = new PathFinding.PathFinding();
            pathFinding.SetMap(map);
            editorScene.SetPathfinding(pathFinding);            
        }

        public void SetShitBot(int x, int y)
        {
            pathFinding.SetShitBot(x, y);
            pathFinding.SetConnection(x, y);
        }

        public void SetEndPoint(int x, int y)
        {
            pathFinding.SetEndPoint(x, y);
            pathFinding.RemoveConnection(x, y);
        }

        public void Drive()
        {
            Point[] p = pathFinding.CalculatePath();

            if(p != null)
            {
                GetInstructions(p);
            }
        }

        List<int[]> instructions;

        private void GetInstructions(Point[] p)
        {
            if (p.Length > 0)
            {
                Point first = p[0];
                List<int[]> instructions = new List<int[]>();
                int rotatie = pathFinding.Rotation;
                
                //0 is naar beneden
                //1 is links
                //2 is omhoog 
                //3 is rechts

                for (int i = 1; i < p.Length; i++)
                {
                    if(first.X == p[i].X)
                    {//we need to drive vertical
                        if(first.Y > p[i].Y)
                        {//we need to drive up
                            switch (rotatie)
                            {
                                case 0: //beneden
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie});
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });


                                    break;
                                case 1: //liks
                                    //Console.WriteLine("draai rechts");
                                    instructions.Add(new int[] { 1, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });

                                    break;
                                case 2: //omhoog
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 3: //rechts
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                            }
                            rotatie = 2;
                        }
                        else if(first.Y < p[i].Y)
                        {//we need to drive down
                            switch (rotatie)
                            {
                                case 2: //beneden
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 1: //liks
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });

                                    break;
                                case 0: //omhoog
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 3: //rechts
                                    //Console.WriteLine("draai rechts");
                                    instructions.Add(new int[] { 1, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                            }
                            rotatie = 0;
                        }
                    }
                    else if(first.Y == p[i].Y)
                    {//we need to drive horizontal
                        if(first.X < p[i].X)
                        {//drive right
                            switch (rotatie)
                            {
                                case 1: //links
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 0: //beneden
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 3: //rechts
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 2: //omhoog
                                    //Console.WriteLine("draai rechts");
                                    instructions.Add(new int[] { 1, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                            }
                            rotatie = 3;
                        }
                        else if(first.X > p[i].X)
                        {//drive left
                            switch (rotatie)
                            {
                                case 3: //beneden
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 0: //liks
                                    //Console.WriteLine("draai links");
                                    instructions.Add(new int[] { 1, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 1: //omhoog
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                                case 2: //rechts
                                    //Console.WriteLine("draai rechts");
                                    instructions.Add(new int[] { 0, first.X, first.Y, rotatie });
                                    //Console.WriteLine("scannen");
                                    //Console.WriteLine("rij vooruit");
                                    instructions.Add(new int[] { 2, first.X, first.Y, rotatie });
                                    break;
                            }
                            rotatie = 1;
                        }

                    }

                    first = p[i];
                }

                instructions.Add(new int[] { 99, first.X, first.Y, rotatie });
                this.instructions = instructions;

                OnComplete();

            }
        }

        //0 = draai links
        //1 = draai rechts
        //2 = rij vooruit
        //3 = scannen
        
        protected override void OnUpdate()
        {
            editorScene.Refresh();
        }

        protected override void OnTimeout()
        {
            Console.WriteLine("timeout");
            form.Owner.Owner.Show();
            Stop();
            form.Owner.Hide();
        }

        bool isComplete;
        int[] lastInstruction;

        protected override void OnComplete()
        {
            MessagesOut msg = null;

            if (instructions.Count > 0)
            {
                if(lastInstruction != null)
                {
                    pathFinding.SetShitBotPosition(lastInstruction[1], lastInstruction[2]);
                    pathFinding.Rotation = lastInstruction[3];
                }

                Console.WriteLine(instructions[0][0]);

                switch (instructions[0][0])
                {
                    case 0:
                        msg = new Msg_Out_Left();
                        break;
                    case 1:
                        msg = new Msg_Out_Right();
                        break;
                    case 2:
                        msg = new Msg_Out_Forward();
                        break;
                }

                if(msg != null)
                    shittyNetClient.SendMessage(msg);

                lastInstruction = instructions[0];
                instructions.RemoveAt(0);

                Console.WriteLine("count : " + instructions.Count);

                if (msg == null)
                    OnComplete();
            }
            else if(lastInstruction != null)
            {
                pathFinding.SetShitBotPosition(lastInstruction[1], lastInstruction[2]);
                pathFinding.Rotation = lastInstruction[3];
                Console.WriteLine(lastInstruction[3]);
                pathFinding.Reset();
                lastInstruction = null;
                
            }
            else
            {
                lastInstruction = null;
            }
        }

        

    }
}
