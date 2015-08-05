using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveManager
{
    class Formatter
    {
        

        /// <summary>
        /// expected input format: dd-MMM-yyyy
        /// </summary>
        /// <param name="dateString"></param>
        public static string dateSwapper( string dateString )
        {
            string [] tokens = dateString.Split( '-' );

            !!TODO

            //string year = "";
            //string day = "";
            //string month = "";

            string result = "?";

            return result;

        }

        public static int getMonth( string monthString )
        {
            switch( monthString.ToUpper() )
            {                
                case "JAN":
                    return 1;
                case "FEB":
                    return 2;
                case "MAR":
                    return 3;
                case "APR":
                    return 4;
                case "MAY":
                    return 5;
                case "JUN":
                    return 6;
                case "JUL":
                    return 7;
                case "AUG":
                    return 8;
                case "SEP":
                    return 9;
                case "OCT":
                    return 10;
                case "NOV":
                    return 11;
                case "DEC":
                    return 12;
                default:
                    return -1;
            }
        }
    }
}
