using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class SportListEnumarable : IEnumerable, IEnumerable<SportActivity>
    {
        public List<SportActivity> m_SportList;

        public SportListEnumarable()
        {
            m_SportList = MainFeed.m_MySportListProxy.m_SportList.SportActivities.Values.ToList<SportActivity>();
        }

        public IEnumerator<SportActivity> GetEnumerator()
        {
            for (int i = 0; i < m_SportList.Count; ++i)
            {
                yield return m_SportList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SportListIterator(this);
        }

        private class SportListIterator : IEnumerator
        {
            private SportListEnumarable m_SportList; // basic thing to do;
            private int m_CurrentIdx = 0;
            private int m_Count = 0;

            public SportListIterator(SportListEnumarable i_SportListEnumrable)
            {
                m_SportList = i_SportListEnumrable;
                m_Count = m_SportList.m_SportList.Count;
            }

            public void Reset()
            {
                m_CurrentIdx = 0;
            }

            public bool MoveNext()
            {
                if (m_Count != m_SportList.m_SportList.Count)
                {
                    throw new Exception("Sorry but you can't change the collection during iteration");
                }

                if (m_CurrentIdx >= m_Count)
                {
                    throw new Exception("End of collection");
                }

                return ++m_CurrentIdx < m_SportList.m_SportList.Count;
            }

            public object Current
            {
                get { return m_SportList.m_SportList[m_CurrentIdx]; }
            }

            public void Dispose()
            {
                Reset();
            }
        }
    }
}
