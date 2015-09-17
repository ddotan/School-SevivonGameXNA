using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HanukaGame.Infrustructure.Collections;

namespace HanukaGame.Sevivons
{
    public class IndexedSevivon : TexturedSevivon
    {
        public IndexedSevivon(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position)
        {
            HandleColor = Color.Blue;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            BodyPrimitiveType = PrimitiveType.TriangleList;
            PersonalArrayList<short> indicies = new PersonalArrayList<short>(24);
            indicies.Add(0, 1, 2, 1, 3, 2, 2, 3, 4, 4, 3, 5, 4, 5, 6, 6, 5, 7, 6, 7, 8, 8, 7, 9);
            BodyIndicies = new IndexBuffer(this.GraphicsDevice, IndexElementSize.SixteenBits, indicies.Length, BufferUsage.WriteOnly);
            BodyIndicies.SetData(indicies.ToArray());
        }
    }
}
