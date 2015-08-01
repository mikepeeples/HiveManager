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

        public History()
        {
            Name = "name";
            Date = "date";
            Description = "description";
        }

        public History( string name, string date, string description )
        {
            Name = name;
            Date = date;
            Description = description;
        }

        public string toString()
        {
            return( Date + ", " +
                    Name + ", " + 
                    Description );
        }        
    }
}
