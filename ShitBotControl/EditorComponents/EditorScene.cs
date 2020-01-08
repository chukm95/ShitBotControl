using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGraphicsDevice;

namespace Orthus.Editor.EditorComponents
{
    using Point = System.Drawing.Point;

    class EditorScene : GraphicsDeviceControl
    {
        private ContentManager contentManager;

        protected override void Initialize()
        {
            contentManager = new ContentManager(Services, "Content");
        }
        
        public void update()
        {

        }

        protected override void Draw()
        {            
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
