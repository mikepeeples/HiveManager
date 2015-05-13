using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiveManager
{
    public partial class Form1 : Form
    {
        HiveData hiveData = new HiveData();
        List< Hive > hiveList;
        List< string > typeList;
        List< string > colorList;

        public Form1()
        {
            InitializeComponent();
            hiveData.readHiveData();
            initializeForm();
        }

        private void initializeForm()
        {
            initializeHiveComboBox();
            initializeColorComboBox();
            initializeTypeComboBox();
            
        }

        private void initializeColorComboBox()
        {
            colorList = hiveData.getColorList();
            foreach ( string s in colorList )
            {
                colorComboBox.Items.Add( s );
            }
        }

        private void initializeHiveComboBox()
        {
            hiveList = hiveData.getHiveList();
            for ( int i = 0; i < hiveList.Count; i++ )
            {
                string summary = String.Format( "{0,-16} {1,-20} {2,-16} {3,-16}", 
                                                hiveList[ i ].Name, 
                                                hiveList[ i ].Type, 
                                                hiveList[ i ].StartDate, 
                                                hiveList[ i ].Breed );

                hiveComboBox.Items.Add( summary );
            }

            hiveComboBox.SelectedIndex = 0;
            hiveComboBox.Text = String.Format( " {0,-16} {1,-20} {2,-16} {3,-16}", 
                                                hiveList[ 0 ].Name,
                                                hiveList[ 0 ].Type,
                                                hiveList[ 0 ].StartDate,
                                                hiveList[ 0 ].Breed );

            populateHiveDetails( hiveList[ 0 ].Name,
                                 hiveList[ 0 ].Type,
                                 hiveList[ 0 ].StartDate,
                                 hiveList[ 0 ].Frames,
                                 hiveList[ 0 ].Breed,
                                 hiveList[ 0 ].Source,
                                 hiveList[ 0 ].Status,
                                 hiveList[ 0 ].QueenName,
                                 hiveList[ 0 ].CoronationDate,
                                 hiveList[ 0 ].Clipped,
                                 hiveList[ 0 ].Marked,
                                 hiveList[ 0 ].Active,
                                 hiveList[ 0 ].Color );
        }

        private void initializeTypeComboBox()
        {
            typeList = hiveData.getTypeList();
            foreach ( string s in typeList )
            {
                typeComboBox.Items.Add( s );
            }
        }

        private void populateHiveDetails( string name, string type, string date, int frames, string breed, string source, string status,
                                          string queen, string coronation, bool clipped, bool marked, bool active, string color )
        {
            hiveNameTextBox.Text = name;
            typeComboBox.Text = type;
            startDateTimePicker.Text = date;
            framesTextBox.Text = frames.ToString();
            breedTextBox.Text = breed;
            sourceTextBox.Text = source;
            statusTextBox.Text = status;
            queenTextBox.Text = queen;
            coronationDateTimePicker.Text = coronation;
            clippedCheckBox.Checked = clipped;
            markedCheckBox.Checked = marked;
            colorComboBox.Text = color;
            activeCheckBox.Checked = active;
        }

        private void toolStripButtonSave_Click( object sender, EventArgs e )
        {
            hiveData.writeHiveData();
        }

        private void hiveComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            int i = hiveComboBox.SelectedIndex;
            populateHiveDetails( hiveList[ i ].Name, 
                                 hiveList[ i ].Type, 
                                 hiveList[ i ].StartDate, 
                                 hiveList[ i ].Frames, 
                                 hiveList[ i ].Breed,
                                 hiveList[ i ].Source, 
                                 hiveList[ i ].Status, 
                                 hiveList[ i ].QueenName, 
                                 hiveList[ i ].CoronationDate,
                                 hiveList[ i ].Clipped, 
                                 hiveList[ i ].Marked, 
                                 hiveList[ i ].Active,
                                 hiveList[ i ].Color );            
        }
        
        private void startDateTimePicker_CloseUp( object sender, EventArgs e )
        {
            if ( hiveComboBox.SelectedIndex > -1 )
            {
                hiveList[ hiveComboBox.SelectedIndex ].StartDate = startDateTimePicker.Text;
            }
        }

        private void toolStripButtonNew_Click( object sender, EventArgs e )
        {
            // clear data
            populateHiveDetails( "",    //Name,
                                 "",    //Type,
                                 "",    //StartDate,
                                 0,    //Frames,
                                 "",    //Breed,
                                 "",    //Source,
                                 "",    //Status,
                                 "",    //QueenName,
                                 "",    //CoronationDate,
                                 false,    //Clipped,
                                 false,    //Marked,
                                 false,    //Active,
                                 ""  );  //Color );   

            Hive hive = new Hive( "",   //Name,
                                 "",    //Type,
                                 "",    //StartDate,
                                 0,     //Frames,
                                 0,     //Value
                                 "",    //Breed,
                                 "",    //Source,
                                 "",    //Status,
                                 "",    //QueenName,
                                 "",    //CoronationDate,
                                 "",   //Color ); 
                                 false, //Clipped,
                                 false, //Marked,
                                 false ); //Active, 

            hiveList.Add( hive );

            int i = hiveList.Count - 1;
            string summary = String.Format( "{0,-16} {1,-20} {2,-16} {3,-16}",
                                                hiveList[ i ].Name,
                                                hiveList[ i ].Type,
                                                hiveList[ i ].StartDate,
                                                hiveList[ i ].Breed );

            hiveComboBox.Items.Add( summary );
        }
    }
}
