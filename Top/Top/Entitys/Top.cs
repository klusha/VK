using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top.Entity
{
    class Top : Entity
    {
        private Dictionary<int, int> dictionaryTops;
        private String dateTop;
        private int userId;

        public Top()
        {
            this.dictionaryTops = new Dictionary<int, int>();
        }

        public Top(Dictionary<int, int> dictionaryTops, int userId)
        {
            this.SetDictionaryTops(dictionaryTops);
            this.userId = userId;
        }

        public Top(Dictionary<int, int> dictionaryTops, String dateTop)
        {
            this.SetDictionaryTops(dictionaryTops);
            this.SetDateTop(dateTop);
        }

        public void SetDictionaryTops(Dictionary<int, int> dictionaryTops)
        {
            this.dictionaryTops = dictionaryTops;
        }
        public Dictionary<int, int> GetDictionaryTops()
        {
            return this.dictionaryTops;
        }

        public String GetDateTop()
        {
            return this.dateTop;
        }
        public int GetUserID()
        {
            return this.userId;
        }
        public void SetDateTop(String dateTop)
        {
            this.dateTop = dateTop;
        }
    }
}
