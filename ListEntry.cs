using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ListEntry
    {
        public string CollectionName { get; set; }
        public Update UpdateType { get; set; }
        public string SourceType { get; set; }
        public string Key { get; set; }
        public ListEntry()
        {
            this.CollectionName = "My collection";
            this.UpdateType = Update.Add;
            this.SourceType = "Position";
            this.Key = "000000";
        }
        public ListEntry(string collectionName, Update updateType, string sourceType, string key)
        {
            this.CollectionName = collectionName;
            this.UpdateType = updateType;
            this.SourceType = sourceType;
            this.Key = key;
        }
        public override string ToString()
        {
            return $"Collection name: {CollectionName} \nUpdate type: {UpdateType} \nSource type: {SourceType} \nKey: {Key}";
        }
    }
}
