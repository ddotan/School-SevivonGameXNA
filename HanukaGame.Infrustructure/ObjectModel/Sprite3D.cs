using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HanukaGame.Infrustructure.ObjectModel
{
    public enum eRotationOrder
    {
        XYZ,
        XZY,
        YXZ,
        YZX,
        ZXY,
        ZYX
    }

    public abstract class Sprite3D : DrawableGameComponent
    {
        private float m_YRotation, m_XRotation, m_ZRotation;
        private float m_Scale = 1f;
        private Camera m_Camera;
        private Matrix m_WorldMatrix;
        private BasicEffect m_BasicEffect;

        public Sprite3D(Game i_Game)
            : base(i_Game)
        {
        }

        public Vector3 Position { get; set; }

        public float XRotationVelocity { get; set; }

        public float YRotationVelocity { get; set; }

        public float ZRotationVelocity { get; set; }

        public eRotationOrder RotationOrder { get; set; }

        public float Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }

        public BasicEffect BasicEffect
        {
            get { return m_BasicEffect; }
        }

        public Camera Camera
        {
            get { return m_Camera; }
        }

        public Matrix WorldMatrix
        {
            get { return m_WorldMatrix; }
        }

        protected override void LoadContent()
        {
            m_Camera = Game.Services.GetService(typeof(Camera)) as Camera;
            m_BasicEffect = new BasicEffect(Game.GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            if (m_BasicEffect != null)
            {
                m_BasicEffect.Dispose();
                m_BasicEffect = null;
            }

            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            m_XRotation += XRotationVelocity * MathHelper.TwoPi * (float)gameTime.ElapsedGameTime.TotalSeconds;
            m_YRotation += YRotationVelocity * MathHelper.TwoPi * (float)gameTime.ElapsedGameTime.TotalSeconds;
            m_ZRotation += ZRotationVelocity * MathHelper.TwoPi * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Matrix rotation = buildRotationMatrixByPriority();

            m_WorldMatrix = Matrix.Identity *
                Matrix.CreateScale(Scale) *
                rotation *
                Matrix.CreateTranslation(Position);
        }

        private Matrix buildRotationMatrixByPriority()
        {
            Matrix rotation = Matrix.Identity;
            Matrix x = Matrix.CreateRotationX(m_XRotation);
            Matrix y = Matrix.CreateRotationY(m_YRotation);
            Matrix z = Matrix.CreateRotationZ(m_ZRotation);

            switch (RotationOrder)
            {
                case eRotationOrder.XYZ:
                    rotation *= x * y * z;
                    break;
                case eRotationOrder.XZY:
                    rotation *= x * z * y;
                    break;
                case eRotationOrder.YXZ:
                    rotation *= y * x * z;
                    break;
                case eRotationOrder.YZX:
                    rotation *= y * z * x;
                    break;
                case eRotationOrder.ZXY:
                    rotation *= z * x * y;
                    break;
                case eRotationOrder.ZYX:
                    rotation *= z * y * x;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Error! Please specify rotation value.");
            }

            return rotation;
        }

        public sealed override void Draw(GameTime gameTime)
        {
            m_BasicEffect.World = m_WorldMatrix;
            m_BasicEffect.View = m_Camera.CameraState;
            m_BasicEffect.Projection = m_Camera.CameraSettings;

            DrawPrimitives(gameTime);
        }

        protected abstract void DrawPrimitives(GameTime gameTime);
    }
}
