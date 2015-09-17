using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HanukaGame.Sevivons
{
    public class TriangleStripSevivon : TexturedSevivon
    {
        public TriangleStripSevivon(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position)
        {
            HandleColor = Color.White;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            BodyPrimitiveType = PrimitiveType.TriangleStrip;
        }
    }
}
