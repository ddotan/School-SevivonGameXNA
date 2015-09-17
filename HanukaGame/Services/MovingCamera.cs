using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using HanukaGame.Infrustructure.ObjectModel;
using HanukaGame.Infrustructure.ServiceInterfaces;
using Microsoft.Xna.Framework.Input;

namespace HanukaGame.Services
{
    public class MovingCamera : Camera
    {
        private IInputManager m_InputManager;

        public MovingCamera(Game i_Game, float i_ViewAngle, float i_AspectRatio, float i_NearPlaneDistance, float i_FarPlaneDistance)
            : base(i_Game, i_ViewAngle, i_AspectRatio, i_NearPlaneDistance, i_FarPlaneDistance)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            m_InputManager = Game.Services.GetService(typeof(IInputManager)) as IInputManager;
        }

        protected override void RegisterAsService()
        {
            Game.Services.AddService(typeof(Camera), this);
        }

        public override void Update(GameTime gameTime)
        {
            Vector3 cameraLocation = new Vector3(CameraLocation.X, CameraLocation.Y, CameraLocation.Z);
            Vector3 cameraLookAt = new Vector3(CameraLookAt.X, CameraLookAt.Y, CameraLookAt.Z);

            if (m_InputManager.KeyHeld(Keys.Up))
            {
                cameraLocation = new Vector3(cameraLocation.X, CameraLocation.Y, cameraLocation.Z - 1);
                cameraLookAt = new Vector3(cameraLookAt.X, CameraLookAt.Y, cameraLookAt.Z - 1);
            }
            else if (m_InputManager.KeyHeld(Keys.Down))
            {
                cameraLocation = new Vector3(cameraLocation.X, CameraLocation.Y, cameraLocation.Z + 1);
                cameraLookAt = new Vector3(cameraLookAt.X, CameraLookAt.Y, cameraLookAt.Z + 1);
            }

            if (m_InputManager.KeyHeld(Keys.Left))
            {
                cameraLocation = new Vector3(cameraLocation.X - 1, CameraLocation.Y, cameraLocation.Z);
                cameraLookAt = new Vector3(cameraLookAt.X - 1, CameraLookAt.Y, cameraLookAt.Z);
            }
            else if (m_InputManager.KeyHeld(Keys.Right))
            {
                cameraLocation = new Vector3(cameraLocation.X + 1, CameraLocation.Y, cameraLocation.Z);
                cameraLookAt = new Vector3(cameraLookAt.X + 1, CameraLookAt.Y, cameraLookAt.Z);
            }

            CameraLocation = cameraLocation;
            CameraLookAt = cameraLookAt;

            base.Update(gameTime);
        }
    }
}
