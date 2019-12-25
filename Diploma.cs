using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    [Serializable]
    class Diploma:IDateAndCopy
    {
        public string OrganizationName { get; set; }
        public string Qualification { get; set; }
        public DateTime Date { get; set; }
        public Diploma(string organizationName, string qualification, DateTime date)
        {
            this.OrganizationName = organizationName;
            this.Qualification = qualification;
            this.Date = date;
        }
        public Diploma()
        {
            this.OrganizationName = "DNU";
            this.Qualification = "Bachelor";
            this.Date = new DateTime(2018, 06, 01);
        }
        public override string ToString()
        {
            return $"Organization name = {OrganizationName}, Qualification = {Qualification}, Date of graduation = {Date.ToShortDateString()}";
        }
        public object DeepCopy()
        {
            return new Diploma(this.OrganizationName, this.Qualification, this.Date);
        }
    }
}
