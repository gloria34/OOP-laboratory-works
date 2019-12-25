using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class EmployeeListHandlerEventArgs : System.EventArgs
    {
        public string CollectionName { get; set; }
        public string CollectionType { get; set; }
        public int ElemNumber { get; set; }
        public EmployeeListHandlerEventArgs()
        {
            this.CollectionName = "My collection";
            this.CollectionType = "My type";
            this.ElemNumber = 7;
        }
        public EmployeeListHandlerEventArgs(string collectionName, string collectionType, int elemNumber)
        {
            this.CollectionName = collectionName;
            this.CollectionType = collectionType;
            this.ElemNumber = elemNumber;
        }
        public override string ToString()
        {
            return $"Collection name: {CollectionName} \nCollection type: {CollectionType} \nElement number: {ElemNumber}";
        }
    }
}
