using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using HanukaGame.Infrustructure.ServiceInterfaces;
using Microsoft.Xna.Framework.Input;

namespace HanukaGame.ObjectModels
{
    public class Gambler : GameComponent
    {
        private IInputManager m_InputManager;
        private eBidLetter m_Bet;
        private int m_Score;
        private bool m_CanBet = true;
        private bool m_IsBet = false;

        public event Action BetPlaced;

        public enum eBidLetter
        {
            N,
            G,
            H,
            P
        }

        public Gambler(Game i_Game)
            : base(i_Game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            m_InputManager = Game.Services.GetService(typeof(IInputManager)) as IInputManager;
            updateScreenTitle();
        }

        private void updateScreenTitle()
        {
            if (m_IsBet)
            {
                Game.Window.Title = string.Format("Score: {0}   Bet: {1}", m_Score, m_Bet);
            }
            else
            {
                Game.Window.Title = string.Format("Score: {0}   Bet: ", m_Score);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (m_CanBet)
            {
                if (m_InputManager.KeyPressed(Keys.N))
                {
                    OnBetPlaced(eBidLetter.N);
                }
                else if (m_InputManager.KeyPressed(Keys.G))
                {
                    OnBetPlaced(eBidLetter.G);
                }
                else if (m_InputManager.KeyPressed(Keys.H))
                {
                    OnBetPlaced(eBidLetter.H);
                }
                else if (m_InputManager.KeyPressed(Keys.P))
                {
                    OnBetPlaced(eBidLetter.P);
                }
            }

            base.Update(gameTime);
        }

        protected virtual void OnBetPlaced(eBidLetter i_Bet)
        {
            m_IsBet = true;
            m_Bet = i_Bet;
            m_CanBet = false;
            updateScreenTitle();

            if (BetPlaced != null)
            {
                BetPlaced.Invoke();
            }
        }

        public void CheckSevivon(eBidLetter i_ShownLetter)
        {
            if (i_ShownLetter.Equals(m_Bet))
            {
                m_Score++;
                updateScreenTitle();
            }

            m_CanBet = true;
        }
    }
}
