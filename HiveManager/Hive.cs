using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveManager
{    
    class Hive
    {
        //properties
        public bool Active { get; set; }
        public bool Marked { get; set; }
        public bool Clipped { get; set; }
        public int Frames { get; set; }
        public decimal Value { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string QueenName { get; set; }
        public string CoronationDate { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        
        public Hive( string name, string type, string date,
                     int frames, decimal value, string status, string source,
                     string queenName, string coronationDate, string breed,
                     string color, bool marked, bool clipped, bool active )
        {
            Name = name;
            Type = type;
            StartDate = date;
            Frames = Convert.ToInt16( frames );
            Value = Convert.ToDecimal( value );
            Status = status;
            Source = source;
            QueenName = queenName;
            CoronationDate = coronationDate;   // convert to DateTime
            Breed = breed;
            Color = color;
            Marked = Convert.ToBoolean( Convert.ToInt16( marked ) );
            Clipped = Convert.ToBoolean( Convert.ToInt16( clipped ) );
            Active = true;
        }

        public string toString()
        {
            return( Name + ", " +
                    Type + ", " +
                    StartDate + ", " +
                    Frames + ", " +
                    Value + ", " +
                    Status + ", " +
                    Source + ", " +
                    QueenName + ", " +
                    CoronationDate + ", " +
                    Breed + ", " +
                    Color + ", " +
                    Marked + ", " +
                    Clipped );
        }        
    }   
}
