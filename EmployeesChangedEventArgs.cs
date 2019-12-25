using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab3
{
    class EmployeesChangedEventArgs<TKey> : EventArgs
    {
        public string CollectionName { get; set; }
        public Update UpdateType { get; set; }
        public string SourceType { get; set; }
        public TKey Key { get; set; }
        public EmployeesChangedEventArgs(string collectionName, Update updateType, string sourceType, TKey key)
        {
            this.CollectionName = collectionName;
            this.UpdateType = updateType;
            this.SourceType = sourceType;
            this.Key = key;
        }
        public EmployeesChangedEventArgs(string sourceType)
        {
            this.UpdateType = Update.Property;
            this.SourceType = sourceType;
        }
        public override string ToString()
        {
            return $"Collection name = {this.CollectionName} \nType of update = {this.UpdateType} \nType of source = {this.SourceType} \nKey = {this.Key}";
        }

    }
}
