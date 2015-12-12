using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.Entity
{
    class Tops : Entity
    {
        //private int IdGroup;
        //private int numberOfRepetitions;
        private Dictionary<int, int> dictionaryTops;
        private String dateTop;
        private int userId;

        public Tops()
        {
            this.dictionaryTops = new Dictionary<int, int>();
        }


        public Tops(Dictionary<int, int> dictionaryTops, int userId)
        {
            //this.SetIdGroup(IdGroup);
            //this.SetNumberOfRepetitions(numberOfRepetitions);
            this.SetDictionaryTops(dictionaryTops);
            this.userId = userId;
        }

        public Tops(Dictionary<int, int> dictionaryTops, String dateTop)
        {
            //this.SetIdGroup(IdGroup);
            //this.SetNumberOfRepetitions(numberOfRepetitions);
            this.SetDictionaryTops(dictionaryTops);
            this.SetDateTop(dateTop);
        }

        //public Tops(int ID, Dictionary<int, int> dictionaryTops, String dateTop)
        //{
        //    this.SetId(Id);
        //    //this.SetIdGroup(IdGroup);
        //    //this.SetNumberOfRepetitions(numberOfRepetitions);
        //    this.SetDictionaryTops(dictionaryTops);
        //    this.SetDateTop(dateTop);
        //}

        public void SetDictionaryTops(Dictionary<int, int> dictionaryTops)
        {
            this.dictionaryTops = dictionaryTops;
        }
        public Dictionary<int, int> GetDictionaryTops()
        {
            return this.dictionaryTops;
        }


        //public int GetIdGroup()
        //{
        //    return this.IdGroup;
        //}
        //public void SetIdGroup(int IdGroup)
        //{
        //    this.IdGroup = IdGroup;
        //}

        //public int GetNumberOfRepetitions()
        //{
        //    return this.numberOfRepetitions;
        //}
        //public void SetNumberOfRepetitions(int numberOfRepetitions)
        //{
        //    this.numberOfRepetitions = numberOfRepetitions;
        //}

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
