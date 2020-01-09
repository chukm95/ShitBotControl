using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShitBotControl.Models;
using ShitBotControl.PathFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGraphicsDevice;

namespace ShitBotControl.EditorComponents
{
    using Point = System.Drawing.Point;

    public class EditorScene : GraphicsDeviceControl
    {
        private ContentManager contentManager;
        private Texture2D nodeTex;
        private Texture2D connectionTex;
        private Texture2D shitbotTex;
        private SpriteBatch spriteBatch;
        private PathFinding.PathFinding pathFinding;
        protected override void Initialize()
        {
            contentManager = new ContentManager(Services, "Content");

            nodeTex = new Texture2D(GraphicsDevice, 16, 16);

            Color[] colors = new Color[16 * 16];

            for(int i = 0; i < 16 * 16; i++)
            {
                int x = i % 16;
                int y = i / 16;

                if (Vector2.Distance(new Vector2(x, y), new Vector2(8, 8)) < 8)
                    colors[i] = Color.White;
                else
                    colors[i] = Color.Transparent;
            }

            nodeTex.SetData(colors);

            connectionTex = new Texture2D(GraphicsDevice, 1, 1);
            connectionTex.SetData(new Color[] { Color.White });

            shitbotTex = new Texture2D(GraphicsDevice, 16, 16);

            colors[8] = Color.Red;
            colors[9] = Color.Red;

            colors[24] = Color.Red;
            colors[25] = Color.Red;

            colors[40] = Color.Red;
            colors[41] = Color.Red;

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public void SetPathfinding(PathFinding.PathFinding pathFinding)
        {
            this.pathFinding = pathFinding;
        }
        
        public void update()
        {

        }

        protected override void Draw()
        {            
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            pathFinding?.DrawMap(this);

            spriteBatch.End();
        }

        public void DrawNode(int x, int y)
        {
            spriteBatch.Draw(nodeTex, new Vector2(x, y), null, Color.DarkGray, 0, new Vector2(8, 8), 1f, SpriteEffects.None, 1f);
            spriteBatch.Draw(nodeTex, new Vector2(x, y), null, Color.LightGray, 0, new Vector2(8, 8), 0.60f, SpriteEffects.None, 1f);
        }

        public void DrawShitBot(int x, int y, int rot)
        {
            spriteBatch.Draw(nodeTex, new Vector2(x, y), null, Color.DarkBlue, 0, new Vector2(8, 8), 1.5f, SpriteEffects.None, 1f);
            spriteBatch.Draw(nodeTex, new Vector2(x, y), null, Color.Blue, 0, new Vector2(8, 8), 1.20f, SpriteEffects.None, 1f);
            spriteBatch.Draw(connectionTex, new Vector2(x, y), new Rectangle(0, 0, 4, 9), Color.Yellow, MathHelper.ToRadians(90f) * rot, new Vector2(2f, 0), 1f, SpriteEffects.None, 1f);
        }

        public void DrawEndPoint(int x, int y)
        {
            spriteBatch.Draw(nodeTex, new Vector2(x, y), null, Color.Red, 0, new Vector2(8, 8), 0.60f, SpriteEffects.None, 1f);
        }

        public void DrawConnection(Node n, int x, int y)
        {
            if (n.n_down != null)
            {
                spriteBatch.Draw(connectionTex, new Vector2(x - 3, y), new Rectangle(0, 0, 6, 48), Color.DarkGray);
                spriteBatch.Draw(connectionTex, new Vector2(x - 1, y), new Rectangle(0, 0, 2, 48), Color.LightGray);
            }

            if (n.n_right != null)
            {
                spriteBatch.Draw(connectionTex, new Vector2(x, y - 3), new Rectangle(0, 0, 48, 6), Color.DarkGray);
                spriteBatch.Draw(connectionTex, new Vector2(x, y - 1), new Rectangle(0, 0, 48, 2), Color.LightGray);
            }
        }

        public void DrawHitBoxes(int x, int y, int width, int height, bool color)
        {
            spriteBatch.Draw(connectionTex, new Rectangle(x, y, width, height), (color? Color.Red : Color.Blue) * 0.5f);
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            float rot = (float)Math.Atan2((double)(y2 - y1), (double)(x2 - x1));
            spriteBatch.Draw(connectionTex, new Vector2(x1, y1), new Rectangle(0, 0, 48, 2), Color.Red, rot, new Vector2(0, 1), 1f, SpriteEffects.None, 1f);

            spriteBatch.Draw(nodeTex, new Vector2(x1, y1), null, Color.Red, 0, new Vector2(8, 8), 0.60f, SpriteEffects.None, 1f);
        }
    }
}
