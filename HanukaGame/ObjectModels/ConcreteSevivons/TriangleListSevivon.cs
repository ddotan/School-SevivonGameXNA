using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HanukaGame.Infrustructure.Collections;

namespace HanukaGame.Sevivons
{
    public class TriangleListSevivon : Sevivon
    {
        public TriangleListSevivon(Game i_Game, Vector3 i_Location)
            : base(i_Game, i_Location)
        {
            HandleColor = Color.Red;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            BodyEffect.VertexColorEnabled = true;
            BodyPrimitiveType = PrimitiveType.TriangleList;
            PersonalArrayList<VertexPositionColor> vertices = new PersonalArrayList<VertexPositionColor>(114);

            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, 5), Color.Blue));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, 5), Color.Blue));
            vertices.Add(new VertexPositionColor(new Vector3(5, 5, 5), Color.Blue));

            vertices.Add(new VertexPositionColor(new Vector3(5, 5, 5), Color.Blue));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, 5), Color.Blue));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, 5), Color.Blue));

            vertices.Add(new VertexPositionColor(new Vector3(5, 5, 5), Color.Red));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, 5), Color.Red));
            vertices.Add(new VertexPositionColor(new Vector3(5, 5, -5), Color.Red));

            vertices.Add(new VertexPositionColor(new Vector3(5, 5, -5), Color.Red));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, 5), Color.Red));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, -5), Color.Red));

            vertices.Add(new VertexPositionColor(new Vector3(5, 5, -5), new Color(76, 255, 0)));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, -5), new Color(76, 255, 0)));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, -5), new Color(76, 255, 0)));

            vertices.Add(new VertexPositionColor(new Vector3(5, 5, -5), new Color(76, 255, 0)));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, -5), new Color(76, 255, 0)));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, -5), new Color(76, 255, 0)));

            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, -5), Color.Yellow));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, -5), Color.Yellow));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, 5), Color.Yellow));

            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, 5), Color.Yellow));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, -5), Color.Yellow));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, 5), Color.Yellow));

            createLetterP(vertices);
            createLetterH(vertices);
            createLetterG(vertices);
            createLetterN(vertices);

            BodyBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            BodyBuffer.SetData(vertices.ToArray(), 0, vertices.Length);
            BodyPrimitiveCount = vertices.Length / 3;
        }

        private void createLetterP(PersonalArrayList<VertexPositionColor> i_Vertices)
        {
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 12, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 14, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 14, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 12, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 14, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 12, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 12, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 12, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 6, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 6, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 12, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 6, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 6, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 8, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 6, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 6, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 8, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 8, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 8, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 10, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-2, 8, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-2, 8, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 10, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-2, 10, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-2, 10, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(0, 10, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-2, 9, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-2, 9, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(0, 10, 5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(0, 9, 5.01f), Color.Black));
        }

        private void createLetterG(PersonalArrayList<VertexPositionColor> i_Vertices)
        {
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 12, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 14, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 14, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 12, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 14, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 12, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 12, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-1, 6, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-1, 12, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 12, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-3, 6, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-1, 6, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-1, 8, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 8, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-1, 10, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 8, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 10, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-1, 10, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 8, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 8, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 6, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(3, 6, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 8, -5.01f), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(1, 6, -5.01f), Color.Black));
        }

        private void createLetterN(PersonalArrayList<VertexPositionColor> i_Vertices)
        {
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 12, -1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 14, -1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 14, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 14, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 12, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 12, -1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 12, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 6, 1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 12, 1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 12, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 6, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 6, 1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 6, 1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 6, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 8, 1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 6, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 8, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(-5.01f, 8, 1), Color.Black));
        }

        private void createLetterH(PersonalArrayList<VertexPositionColor> i_Vertices)
        {
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 12, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 14, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 14, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 12, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 14, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 12, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 12, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 6, -1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 12, -1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 6, -1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 12, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 6, -3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 6, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 9, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 9, 1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 6, 3), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 9, 1), Color.Black));
            i_Vertices.Add(new VertexPositionColor(new Vector3(5.01f, 6, 1), Color.Black));
        }
    }
}