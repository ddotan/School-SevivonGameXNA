using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using HanukaGame.Infrustructure.ObjectModel;
using HanukaGame.Infrustructure.ServiceInterfaces;
using HanukaGame.Infrustructure.Collections;
using HanukaGame.ObjectModels;

namespace HanukaGame.Sevivons
{
    public abstract class Sevivon : Sprite3D
    {
        private const float k_45Deg = MathHelper.PiOver4;
        private const float k_135Deg = MathHelper.PiOver4 + MathHelper.PiOver2;
        private const float k_225Deg = MathHelper.Pi + MathHelper.PiOver4;
        private const float k_315Deg = MathHelper.TwoPi - MathHelper.PiOver4;
        private static Random s_Rand = new Random();
        private bool m_Spinning, m_CanSpin;
        private float m_SpinningSpeed;
        private IInputManager m_InputManager;
        private BasicEffect m_BodyEffect;
        private VertexBuffer m_SevivonBuffer, m_BodyBuffer;
        private IndexBuffer m_BodyIndices;
        private float m_AccumulatedRotation;
       
        public event Action<Gambler.eBidLetter> Stopped;

        public event Action Spinning;

        public Sevivon(Game i_Game, Vector3 i_Position)
            : base(i_Game)
        {
            Position = i_Position;
            i_Game.Components.Add(this);
        }

        protected Color HandleColor { get; set; }

        protected PrimitiveType BodyPrimitiveType { get; set; }

        public int BodyPrimitiveCount { get; set; }

        public bool CanSpin 
        { 
            get { return m_CanSpin; } 
            set { m_CanSpin = value; } 
        }

        protected VertexBuffer BodyBuffer
        {
            get { return m_BodyBuffer; }
            set { m_BodyBuffer = value; }
        }

        protected IndexBuffer BodyIndicies
        {
            get { return m_BodyIndices; }
            set { m_BodyIndices = value; }
        }

        protected BasicEffect BodyEffect
        {
            get { return m_BodyEffect; }
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            m_BodyEffect = new BasicEffect(this.GraphicsDevice);
            BasicEffect.VertexColorEnabled = true;
            RotationOrder = eRotationOrder.YXZ;
            m_InputManager = Game.Services.GetService(typeof(IInputManager)) as IInputManager;
            PersonalArrayList<VertexPositionColor> vertices = new PersonalArrayList<VertexPositionColor>(48);
            vertices.Add(new VertexPositionColor(Vector3.Zero, Color.White));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, 5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(5, 5, 5), Color.Gray));
            vertices.Add(new VertexPositionColor(Vector3.Zero, Color.White));
            vertices.Add(new VertexPositionColor(new Vector3(5, 5, 5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(5, 5, -5), Color.Gray));
            vertices.Add(new VertexPositionColor(Vector3.Zero, Color.White));
            vertices.Add(new VertexPositionColor(new Vector3(5, 5, -5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, -5), Color.Gray));
            vertices.Add(new VertexPositionColor(Vector3.Zero, Color.White));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, -5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 5, 5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, 5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, -5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, 5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, 5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(-5, 15, -5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(5, 15, -5), Color.Gray));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 15, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 15, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 15, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 15, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 15, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 15, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 15, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 15, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 15, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 15, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 15, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 15, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, 1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(-1, 20, -1), HandleColor));
            vertices.Add(new VertexPositionColor(new Vector3(1, 20, -1), HandleColor));

            m_SevivonBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            m_SevivonBuffer.SetData(vertices.ToArray(), 0, vertices.Length);
        }

        protected override void UnloadContent()
        {
            if (m_BodyEffect != null)
            {
                m_BodyEffect.Dispose();
                m_BodyEffect = null;
            }

            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (m_Spinning)
            {
                accumulateRotation(gameTime);

                if (YRotationVelocity > 0)
                {
                    slowDownIn3Seconds(gameTime);
                }
                else
                {
                    YRotationVelocity = 0;
                    m_Spinning = false;
                    m_CanSpin = true;
                    determineStoppedOnLetter();
                }
            }
            else
            {
                if (m_CanSpin)
                {
                    if (m_InputManager.KeyPressed(Keys.Space))
                    {
                        YRotationVelocity = m_SpinningSpeed = ((float)s_Rand.Next(500) / 100f) + 1;
                        OnSpinning();
                    }
                }
            }

            base.Update(gameTime);
        }

        protected virtual void OnSpinning()
        {
            m_Spinning = true;
            m_CanSpin = false;

            if (Spinning != null)
            {
                Spinning.Invoke();
            }
        }

        private void determineStoppedOnLetter()
        {
            if (m_AccumulatedRotation > k_45Deg && m_AccumulatedRotation <= k_135Deg)
            {
                OnStopped(Gambler.eBidLetter.N);
            }
            else if (m_AccumulatedRotation > k_135Deg && m_AccumulatedRotation <= k_225Deg)
            {
                OnStopped(Gambler.eBidLetter.G);
            }
            else if (m_AccumulatedRotation > k_225Deg && m_AccumulatedRotation <= k_315Deg)
            {
                OnStopped(Gambler.eBidLetter.H);
            }
            else
            {
                OnStopped(Gambler.eBidLetter.P);
            }
        }

        protected virtual void OnStopped(Gambler.eBidLetter i_WinningLetter)
        {
            if (Stopped != null)
            {
                Stopped.Invoke(i_WinningLetter);
            }
        }

        private void accumulateRotation(GameTime gameTime)
        {
            m_AccumulatedRotation += YRotationVelocity * MathHelper.TwoPi * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (m_AccumulatedRotation >= MathHelper.TwoPi)
            {
                m_AccumulatedRotation -= MathHelper.TwoPi;
            }
        }

        private void slowDownIn3Seconds(GameTime gameTime)
        {
            YRotationVelocity -= (m_SpinningSpeed / 3) * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        protected override void DrawPrimitives(GameTime gameTime)
        {
            BasicEffect.GraphicsDevice.SetVertexBuffer(m_SevivonBuffer);

            foreach (EffectPass pass in BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                BasicEffect.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 16);
            }

            m_BodyEffect.World = WorldMatrix;
            m_BodyEffect.View = Camera.CameraState;
            m_BodyEffect.Projection = Camera.CameraSettings;

            m_BodyEffect.GraphicsDevice.SetVertexBuffer(m_BodyBuffer);

            if (m_BodyIndices == null)
            {
                foreach (EffectPass pass in m_BodyEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();

                    m_BodyEffect.GraphicsDevice.DrawPrimitives(BodyPrimitiveType, 0, BodyPrimitiveCount);
                }
            }
            else
            {
                m_BodyEffect.GraphicsDevice.Indices = m_BodyIndices;
                foreach (EffectPass pass in m_BodyEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();

                    m_BodyEffect.GraphicsDevice.DrawIndexedPrimitives(BodyPrimitiveType, 0, 0, m_BodyBuffer.VertexCount, 0, BodyPrimitiveCount);
                }
            }
        }
    }
}
