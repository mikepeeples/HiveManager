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
//        private String dbPath;
        private String xmlPathWithFileName;
        private XmlDocument doc = new XmlDocument();
        private XmlNodeList nodes;
        private List< Hive > hiveList = new List<Hive>();
        private List< History > historyList = new List<History>();
        private List< string > typeList = new List<string>();
        private List< string > colorList = new List<string>();

        
        public HiveData()
        {
//            dbPath = System.AppDomain.CurrentDomain.BaseDirectory;
            xmlPathWithFileName = System.AppDomain.CurrentDomain.BaseDirectory + "HiveDB.xml";            
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
//            string path = dbPath + "HiveDB.xml";
//            doc.Load( path );
            doc.Load( xmlPathWithFileName );

            hiveList.Clear();
            nodes = doc.DocumentElement.SelectNodes("/HiveList/Hive");
            foreach ( XmlNode node in nodes )
            {
                string name =   node.SelectSingleNode( "HiveName" ).InnerText;
                string type =   node.SelectSingleNode( "HiveType" ).InnerText;
                string date =   node.SelectSingleNode( "Date" ).InnerText;
                int frames =    Convert.ToInt32( node.SelectSingleNode( "Frames" ).InnerText );
                int number =    Convert.ToInt32( node.SelectSingleNode( "HiveNumber" ).InnerText );
                decimal value = Convert.ToDecimal( node.SelectSingleNode( "Value" ).InnerText );
                string status = node.SelectSingleNode( "Status" ).InnerText;
                string source = node.SelectSingleNode( "Source" ).InnerText;
                string queenName = node.SelectSingleNode( "QueenName" ).InnerText;
                string coronationDate = node.SelectSingleNode( "CoronationDate" ).InnerText;
                string breed =  node.SelectSingleNode( "Breed" ).InnerText;
                string color =  node.SelectSingleNode( "Color" ).InnerText;
                bool marked =   Convert.ToBoolean( node.SelectSingleNode( "Marked" ).InnerText );
                bool clipped =  Convert.ToBoolean( node.SelectSingleNode( "Clipped" ).InnerText );
                bool active =   Convert.ToBoolean( node.SelectSingleNode( "Active" ).InnerText );

                hiveList.Add( new Hive( number, name, type, date, frames, value, status, source,
                                        queenName, coronationDate, breed, color, marked, clipped, active ) );
            }

            typeList.Clear();
            nodes = doc.DocumentElement.SelectNodes( "/HiveList/Types/Type" );
            foreach ( XmlNode node in nodes )
            {
                string descr = node.SelectSingleNode( "Description" ).InnerText;
                typeList.Add( descr );
            }

            
            colorList.Clear();
            nodes = doc.DocumentElement.SelectNodes( "/HiveList/QueenColors/Marking" );
            foreach ( XmlNode node in nodes )
            {
                string descr = node.SelectSingleNode( "Color" ).InnerText;
                colorList.Add( descr );
            }
        }

        public void writeHiveData()
        {

            hiveList.Sort( 
                delegate( Hive h1, Hive h2) 
                { 
                    return h1.Name.CompareTo( h2.Name );
                }
            );
            
//            using ( XmlTextWriter writer = new XmlTextWriter( dbPath + "HiveDB2.xml", Encoding.UTF8 ) )
            using( XmlTextWriter writer = new XmlTextWriter( xmlPathWithFileName, Encoding.UTF8 ) )                        
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                writer.WriteStartDocument();

                writer.WriteStartElement( "HiveList" );
                foreach ( Hive hive in hiveList )
                {
                    writer.WriteStartElement( "Hive" );
                    writer.WriteElementString( "HiveNumber", hive.Number.ToString() );                                   
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
                    writer.WriteElementString( "Marked", hive.Marked.ToString() );
                    writer.WriteElementString( "Color", hive.Color );
                    writer.WriteElementString( "Clipped", hive.Clipped.ToString() );
                    writer.WriteElementString( "Active", hive.Active.ToString() );

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
                //    ..
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
