using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HanukaGame.ObjectModels;
using HanukaGame.Sevivons;
using Microsoft.Xna.Framework;

namespace HanukaGame.Services
{
    public class SevivonsFactory
    {
        private static Gambler s_Gambler;
        private static List<Sevivon> m_Sevivons = new List<Sevivon>();

        public enum eSevivonType
        {
            TriangleList,
            Indexed,
            TriangleStrip
        }

        public static Sevivon CreateSevivon(Game i_Game, eSevivonType i_SevivonType, Vector3 i_Position)
        {
            if (s_Gambler == null)
            {
                setGambler(i_Game);
            }

            Sevivon sevivon = null;
            switch (i_SevivonType)
            {
                case eSevivonType.TriangleList:
                    sevivon = new TriangleListSevivon(i_Game, i_Position);
                    break;

                case eSevivonType.TriangleStrip:
                    sevivon = new TriangleStripSevivon(i_Game, i_Position);
                    break;

                case eSevivonType.Indexed:
                    sevivon = new IndexedSevivon(i_Game, i_Position);
                    break;
            }

            sevivon.Stopped += s_Gambler.CheckSevivon;
            m_Sevivons.Add(sevivon);
            return sevivon;
        }

        private static void setGambler(Game i_Game)
        {
            s_Gambler = new Gambler(i_Game);
            s_Gambler.BetPlaced += new Action(() =>
            {
                foreach (Sevivon item in m_Sevivons)
                {
                    item.CanSpin = true;
                }
            });
            i_Game.Components.Add(s_Gambler);
        }
    }
}
