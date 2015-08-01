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
//        public bool NewlyAdded = { get; set = false; }
        public bool Active { get; set; }
        public bool Marked { get; set; }
        public bool Clipped { get; set; }             
        public string Value { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string QueenName { get; set; }
        public string CoronationDate { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Frames { get; set; }
        public string Number { get; set; }
        public List< History > HistoryList { get; set; } 

        public Hive ()
        {
            Active = true;
        }

        public Hive( string number, string name, string type, string date,
                     string frames, string value, string status, string source,
                     string queenName, string coronationDate, string breed,
                     string color, bool marked, bool clipped, bool active,
                     List<History> historyList )
        {
            Number = number;
            Name = name;
            Type = type;
            StartDate = date;
            Frames = frames;
            Value = value;
            Status = status;
            Source = source;
            QueenName = queenName;
            CoronationDate = coronationDate;   // convert to DateTime
            Breed = breed;
            Color = color;
            Marked = Convert.ToBoolean( Convert.ToInt16( marked ) );
            Clipped = Convert.ToBoolean( Convert.ToInt16( clipped ) );
            Active = true;
            HistoryList = historyList;
        }

        public string toString()
        {
            return( Number + ", " +
                    Name + ", " +
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
