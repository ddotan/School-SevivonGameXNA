using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HanukaGame.Infrustructure.ObjectModel
{
    public class Camera : GameService
    {
        protected Matrix m_CameraSettings;
        protected Matrix m_CameraState;
        private Vector3 m_CameraUpDirection = new Vector3(0, 1, 0);

        public Camera(Game i_Game, float i_ViewAngle, float i_AspectRatio, float i_NearPlaneDistance, float i_FarPlaneDistance)
            : base(i_Game)
        {
            m_CameraSettings = Matrix.CreatePerspectiveFieldOfView(
                i_ViewAngle,
                i_AspectRatio,
                i_NearPlaneDistance,
                i_FarPlaneDistance);
        }

        public Vector3 CameraLookAt { get; set; }

        public Vector3 CameraLocation { get; set; }

        public Vector3 CameraUpDirection 
        {
            get { return m_CameraUpDirection; }
            set { m_CameraUpDirection = value; }
        }

        public Matrix CameraState
        {
            get { return m_CameraState; }
        }

        public Matrix CameraSettings
        {
            get { return m_CameraSettings; }
        }

        public override void Update(GameTime gameTime)
        {
            m_CameraState = Matrix.CreateLookAt(
                CameraLocation, CameraLookAt, CameraUpDirection);

            base.Update(gameTime);
        }
    }
}
