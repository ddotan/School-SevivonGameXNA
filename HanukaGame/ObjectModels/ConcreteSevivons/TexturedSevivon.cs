using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HanukaGame.Infrustructure.Collections;

namespace HanukaGame.Sevivons
{
    public class TexturedSevivon : Sevivon
    {
        public TexturedSevivon(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Texture2D texture = Game.Content.Load<Texture2D>(@"Textures\Body");
            BodyEffect.Texture = texture;
            BodyEffect.TextureEnabled = true;
            PersonalArrayList<VertexPositionTexture> verticies = new PersonalArrayList<VertexPositionTexture>(10);
            verticies.Add(new VertexPositionTexture(new Vector3(-5, 5, 5), new Vector2(0, 1)));
            verticies.Add(new VertexPositionTexture(new Vector3(-5, 15, 5), new Vector2(0, 0)));
            verticies.Add(new VertexPositionTexture(new Vector3(5, 5, 5), new Vector2(0.25f, 1)));
            verticies.Add(new VertexPositionTexture(new Vector3(5, 15, 5), new Vector2(0.25f, 0)));
            verticies.Add(new VertexPositionTexture(new Vector3(5, 5, -5), new Vector2(0.5f, 1)));
            verticies.Add(new VertexPositionTexture(new Vector3(5, 15, -5), new Vector2(0.5f, 0)));
            verticies.Add(new VertexPositionTexture(new Vector3(-5, 5, -5), new Vector2(0.75f, 1)));
            verticies.Add(new VertexPositionTexture(new Vector3(-5, 15, -5), new Vector2(0.75f, 0)));
            verticies.Add(new VertexPositionTexture(new Vector3(-5, 5, 5), new Vector2(1, 1)));
            verticies.Add(new VertexPositionTexture(new Vector3(-5, 15, 5), new Vector2(1, 0)));
            BodyBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionTexture), verticies.Length, BufferUsage.WriteOnly);
            BodyBuffer.SetData(verticies.ToArray(), 0, verticies.Length);
            BodyPrimitiveCount = 8;
        }
    }
}
