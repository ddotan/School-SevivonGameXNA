using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using HanukaGame.Infrastructure.Managers;
using HanukaGame.Sevivons;
using HanukaGame.Services;

namespace HanukaGame
{
    public class HanukaGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager m_Graphics;

        public HanukaGame()
        {
            m_Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            MovingCamera camera = new MovingCamera(this, MathHelper.PiOver4, GraphicsDevice.Viewport.AspectRatio, 0.5f, 1000.0f);
            camera.CameraLocation = new Vector3(0, 10, 80);
            InputManager inputManager = new InputManager(this);
            SevivonsFactory.CreateSevivon(this, SevivonsFactory.eSevivonType.TriangleList, new Vector3(-40, -15, -10));
            SevivonsFactory.CreateSevivon(this, SevivonsFactory.eSevivonType.TriangleList, new Vector3(30, 5, 5));
            SevivonsFactory.CreateSevivon(this, SevivonsFactory.eSevivonType.Indexed, new Vector3(30, -20, -50));
            SevivonsFactory.CreateSevivon(this, SevivonsFactory.eSevivonType.Indexed, new Vector3(-15, -5, -20));
            SevivonsFactory.CreateSevivon(this, SevivonsFactory.eSevivonType.TriangleStrip, new Vector3(5, 0, 10));
            SevivonsFactory.CreateSevivon(this, SevivonsFactory.eSevivonType.TriangleStrip, new Vector3(-10, -25, 0));
            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
