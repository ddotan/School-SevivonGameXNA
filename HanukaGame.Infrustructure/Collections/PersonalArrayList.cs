using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanukaGame.Infrustructure.Collections
{
    /// <summary>
    /// This class give us the tools to use T[] as a List.
    /// This solves the problem with List<T>.ToArray() that returns a list not alaways in the right insertion order.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersonalArrayList<T>
    {
        private T[] m_Items;
        private int m_CurrentIndex = 0;

        public T[] ToArray() 
        { 
            return m_Items; 
        }

        public int Length 
        { 
            get { return m_CurrentIndex + 1; } 
        }

        public PersonalArrayList(int i_InitialSize = 5)
        {
            m_Items = new T[i_InitialSize];
        }

        public void Add(params T[] i_Items)
        {
            foreach(T item in i_Items)
            {
                if (m_Items.Length == m_CurrentIndex + 1)
                {
                    enlargeList();
                }

                m_Items[m_CurrentIndex] = item;
                m_CurrentIndex++;
            }
        }

        private void enlargeList()
        {
            T[] newList = new T[m_Items.Length + 5];
            for (int i = 0; i < m_Items.Length; i++)
            {
                newList[i] = m_Items[i];
            }

            m_Items = newList;
        }
    }
}
