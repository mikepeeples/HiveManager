using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveManager
{
    class History
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string EventKey { get; set; }    // this is what gets displayed in the combobox pulldown 
        public string SortKey { get; set; }     // this is what we sort by before writing to XML: yyyy-day of year

        public History()
        {
            Name = "name";
            Date = "date";
            Description = "description";
            EventKey = "eventKey";
            SortKey = "sortKey";
        }

        public History( string name, string date, string description, string eventKey, string sortKey )
        {
            Name = name;
            Date = date;
            Description = description;
            EventKey = eventKey;
            SortKey = sortKey;
        }

        public string toString()
        {
            return( Date + ", " +
                    Name + ", " + 
                    Description );
        }        
    }
}
