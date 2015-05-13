using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


namespace HiveManager
{
    class HiveData
    {
        private String dbPath;
        private String xmlPathWithFileName;
        private XmlDocument doc = new XmlDocument();
        private XmlNodeList nodes;
        private List< Hive > hiveList = new List<Hive>();
        private List< History > historyList = new List<History>();
        private List< string > typeList = new List<string>();
        private List< string > colorList = new List<string>();

        
        public HiveData()
        {
            dbPath = System.AppDomain.CurrentDomain.BaseDirectory;
            //xmlPathWithFileName = System.AppDomain.CurrentDomain.BaseDirectory + "HiveDB.xml";            
        }

        public List<Hive> getHiveList()
        {
            return hiveList;
        }

        public List<string> getTypeList()
        {
            return typeList;
        }

        public List<string> getColorList()
        {
            return colorList;
        }

        public void readHiveData()
        {
            string path = dbPath + "HiveDB.xml";

            doc.Load( path );
            //doc.Load( xmlPathWithFileName );            

            int index = 0;
            nodes = doc.DocumentElement.SelectNodes( "/HiveList/Hive" );

            foreach ( XmlNode node in nodes )
            {
                ++index;
                string name =   node.SelectSingleNode( "HiveName" ).InnerText;
                string type =   node.SelectSingleNode( "HiveType" ).InnerText;
                string date =   node.SelectSingleNode( "Date" ).InnerText;
                string frames = node.SelectSingleNode( "Frames" ).InnerText;
                string value =  node.SelectSingleNode( "Value" ).InnerText;
                string status =  node.SelectSingleNode( "Status" ).InnerText;
                string source = node.SelectSingleNode( "Source" ).InnerText;
                string queenName = node.SelectSingleNode( "QueenName" ).InnerText;
                string coronationDate = node.SelectSingleNode( "CoronationDate" ).InnerText;
                string breed =  node.SelectSingleNode( "Breed" ).InnerText;
                string color =  node.SelectSingleNode( "Color" ).InnerText;
                string marked = node.SelectSingleNode( "Marked" ).InnerText;
                string clipped = node.SelectSingleNode( "Clipped" ).InnerText;

                hiveList.Add( new Hive( index, name, type, date, frames, value, status, source,
                                        queenName, coronationDate, breed, color, marked, clipped ) );
            }

            nodes = doc.DocumentElement.SelectNodes( "/HiveList/Types/Type" );
            foreach ( XmlNode node in nodes )
            {
                string descr = node.SelectSingleNode( "Description" ).InnerText;
                typeList.Add( descr );
            }

            nodes = doc.DocumentElement.SelectNodes( "/HiveList/QueenColors/Marking" );
            foreach ( XmlNode node in nodes )
            {
                string descr = node.SelectSingleNode( "Color" ).InnerText;
                colorList.Add( descr );
            }
        }

        public void writeHiveData()
        {
            using ( XmlTextWriter writer = new XmlTextWriter( dbPath + "HiveDB2.xml", Encoding.UTF8 ) )
            //using( XmlTextWriter writer = new XmlTextWriter( xmlPathWithFileName, Encoding.UTF8 ) )                        
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                writer.WriteStartDocument();

                writer.WriteStartElement( "HiveList" );
                foreach ( Hive hive in hiveList )
                {
                    writer.WriteStartElement( "Hive" );
                    writer.WriteElementString( "HiveName", hive.Name );
                    writer.WriteElementString( "HiveType", hive.Type );
                    writer.WriteElementString( "Date", hive.StartDate );
                    writer.WriteElementString( "Frames", hive.Frames.ToString() );
                    writer.WriteElementString( "Value", hive.Value.ToString() );
                    writer.WriteElementString( "Source", hive.Source );
                    writer.WriteElementString( "Status", hive.Status );
                    writer.WriteElementString( "QueenName", hive.QueenName );
                    writer.WriteElementString( "CoronationDate", hive.CoronationDate );
                    writer.WriteElementString( "Breed", hive.Breed );
                    if ( hive.Marked == true )
                        writer.WriteElementString( "Marked", "1" );
                    else
                        writer.WriteElementString( "Marked", "0" );
                    writer.WriteElementString( "Color", hive.Color );
                    if ( hive.Clipped == true )
                        writer.WriteElementString( "Clipped", "1" );
                    else
                        writer.WriteElementString( "Clipped", "0" );
                    writer.WriteEndElement();
                }
               
                // <Types>
                //     <Type>
                //         <Description>8 Frame Langstroth</Description>
                //     </Type>
                //     ...
                //     <Type>
                //         <Description>Warre</Description>
                //     </Type>
                // </Types>
                //
                writer.WriteStartElement( "Types" );
                foreach ( string s in typeList )
                {
                    writer.WriteStartElement( "Type" );
                    writer.WriteElementString( "Description", s );
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                // <QueenColors>
                //    <Marking>
                //        <Color>Blue</Color>
                //    </Marking>
                //    <Marking>
                //        <Color>White</Color>
                //    </Marking>
                //    <Marking>
                //        <Color>Yellow</Color>
                //    </Marking>
                //    <Marking>
                //        <Color>Red</Color>
                //    </Marking>
                //    <Marking>
                //        <Color>Green</Color>
                //    </Marking>
                //    <Marking>
                //        <Color>Unknown</Color>
                //    </Marking>
                // </QueenColors>
                //
                writer.WriteStartElement( "QueenColors" );
                foreach ( string s in colorList )
                {
                    writer.WriteStartElement( "Marking" );
                    writer.WriteElementString( "Color", s );
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
