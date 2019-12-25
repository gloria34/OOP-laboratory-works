using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Listener<TKey>
    {
        public delegate void EmployeeListHandler(object source, EmployeesChangedEventArgs<TKey> args);
       // public List<ListEntry> ChangeList = new List<ListEntry>();
        private List<ListEntry> ChangeDictionaryList = new List<ListEntry>();

        public void EventDescription (object source, EmployeesChangedEventArgs<TKey> args)
        {
            ListEntry le = new ListEntry(args.CollectionName, args.UpdateType, args.SourceType, args.Key.ToString());
            //ChangeList.Add(le);
            ChangeDictionaryList.Add(le);
        }
        //public override string ToString()
        //{
        //    string s = "";
        //    foreach (var c in ChangeList)
        //    {
        //        s += c.ToString();
        //        s += "\n";
        //    }
        //    return s;
        //}
        public override string ToString()
        {
            string s = "";
            foreach (var c in ChangeDictionaryList)
            {
                s += c.ToString();
                s += "\n";
            }
            return s;
        }
    }
}
