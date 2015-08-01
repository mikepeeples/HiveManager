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
        public string EventKey { get; set; }

        public History()
        {
            Name = "name";
            Date = "date";
            Description = "description";
            EventKey = "eventKey";
        }

        public History( string name, string date, string description, string eventKey )
        {
            Name = name;
            Date = date;
            Description = description;
            EventKey = eventKey;
        }

        public string toString()
        {
            return( Date + ", " +
                    Name + ", " + 
                    Description );
        }        
    }
}
