using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    [Serializable]
    class Experience:IDateAndCopy
    {
        public string NameOfOrganization { get; set; }
        public string OldPosition { get; set; }
        public DateTime Date { get; set; }
        public DateTime FireDate { get; set; }
        public Experience(string nameOfOrganization, string oldPosition, DateTime hireDate, DateTime fireDate)
        {
            this.NameOfOrganization = nameOfOrganization;
            this.OldPosition = oldPosition;
            this.Date = hireDate;
            this.FireDate = fireDate;
        }
        public Experience()
        {
            this.NameOfOrganization = "DNU";
            this.OldPosition = "Teacher";
            this.Date = new DateTime(1995, 06, 07);
            this.FireDate = new DateTime(2005, 06, 07);
        }
        public override string ToString()
        {
            return $"Name of organization: {NameOfOrganization}\nOld position: {OldPosition}\nHiring date: {Date}\nDate of dismissal: {FireDate}";
        }
        public object DeepCopy()
        {
            return new Experience(this.NameOfOrganization, this.OldPosition, this.Date, this.FireDate);
        }
    }
}
