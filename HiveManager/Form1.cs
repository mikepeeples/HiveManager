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
        Hive hive = null;
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
            hiveComboBox.Items.Clear();
            for ( int i = 0; i < hiveList.Count; i++ )
            {
                string summary = String.Format( "{0, -8} {1,-16} {2,-20} {3,-16} {4,-16}",
                                                hiveList[ i ].Number,
                                                hiveList[ i ].Name,
                                                hiveList[ i ].Type,
                                                hiveList[ i ].StartDate,
                                                hiveList[ i ].Breed );

                hiveComboBox.Items.Add( summary );
            }

            hiveComboBox.SelectedIndex = 0;
            hiveComboBox.Text = String.Format( " {0, -8} {1,-16} {2,-20} {3,-16} {4,-16}",
                                                hiveList[ 0 ].Number,
                                                hiveList[ 0 ].Name,
                                                hiveList[ 0 ].Type,
                                                hiveList[ 0 ].StartDate,
                                                hiveList[ 0 ].Breed );

            populateHiveDetails( hiveList[ 0 ] );
        }

        private void initializeTypeComboBox()
        {
            typeList = hiveData.getTypeList();
            foreach ( string s in typeList )
            {
                typeComboBox.Items.Add( s );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hive"></param>
        private void populateHiveDetails( Hive hive )
        {
            hiveNumberTextBox.Text = hive.Number.ToString();
            hiveNameTextBox.Text = hive.Name;
            typeComboBox.Text = hive.Type;
            startDateTimePicker.Text = hive.StartDate;
            framesTextBox.Text = hive.Frames.ToString();
            breedTextBox.Text = hive.Breed;
            sourceTextBox.Text = hive.Source;
            statusTextBox.Text = hive.Status;
            queenTextBox.Text = hive.QueenName;
            coronationDateTimePicker.Text = hive.CoronationDate;
            clippedCheckBox.Checked = hive.Clipped;
            markedCheckBox.Checked = hive.Marked;
            colorComboBox.Text = hive.Color;
            activeCheckBox.Checked = hive.Active;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="date"></param>
        /// <param name="frames"></param>
        /// <param name="breed"></param>
        /// <param name="source"></param>
        /// <param name="status"></param>
        /// <param name="queen"></param>
        /// <param name="coronation"></param>
        /// <param name="clipped"></param>
        /// <param name="marked"></param>
        /// <param name="active"></param>
        /// <param name="color"></param>
        private void populateHiveDetails( int number, string name, string type, string date, int frames, string breed, string source, string status,
                                          string queen, string coronation, bool clipped, bool marked, bool active, string color )
        {
            hiveNumberTextBox.Text = number.ToString();         
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

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSave_Click( object sender, EventArgs e )
        {
            // if it's a newly created hive, add it to the list
            if ( hive != null )
            {
                hive.Number = hiveNumberTextBox.Text;
                hive.Name = hiveNameTextBox.Text;
                hive.Type = typeComboBox.Text;
                hive.StartDate = startDateTimePicker.Text;
                hive.Frames = framesTextBox.Text;
                hive.Breed = breedTextBox.Text;
                hive.Source = sourceTextBox.Text;
                hive.Status = statusTextBox.Text;
                hive.QueenName = queenTextBox.Text;
                hive.CoronationDate = coronationDateTimePicker.Text;
                hive.Clipped = clippedCheckBox.Checked;
                hive.Marked = markedCheckBox.Checked;
                hive.Color = colorComboBox.Text;
                hive.Active = activeCheckBox.Checked;

                hiveList.Add( hive );
                hive = null;
            }
            else
            {
                // if it's an existing hive, update the text box 
                // info into the existing hive objects properties
                int i = hiveComboBox.SelectedIndex;

                hiveList[ i ].Number = hiveNumberTextBox.Text;                                
                hiveList[ i ].Name = hiveNameTextBox.Text;
                hiveList[ i ].Type = typeComboBox.Text;
                hiveList[ i ].StartDate = startDateTimePicker.Text;
                hiveList[ i ].Frames = framesTextBox.Text;
                hiveList[ i ].Breed = breedTextBox.Text;
                hiveList[ i ].Source = sourceTextBox.Text;
                hiveList[ i ].Status = statusTextBox.Text;
                hiveList[ i ].QueenName = queenTextBox.Text;
                hiveList[ i ].CoronationDate = coronationDateTimePicker.Text;
                hiveList[ i ].Clipped = clippedCheckBox.Checked;
                hiveList[ i ].Marked = markedCheckBox.Checked;
                hiveList[ i ].Color = colorComboBox.Text;
                hiveList[ i ].Active = activeCheckBox.Checked;
            }

            updateHiveList();
        }

        private void hiveComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            int i = hiveComboBox.SelectedIndex;
            populateHiveDetails( hiveList[ i ] );
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
            // clear data entry text boxes
            populateHiveDetails( 0,     //Number
                                 "",    //Name,
                                 "",    //Type,
                                 "",    //StartDate,
                                 8,     //Frames,
                                 "",    //Breed,
                                 "",    //Source,
                                 "",    //Status,
                                 "",    //QueenName,
                                 "",    //CoronationDate,
                                 false, //Clipped,
                                 false, //Marked,
                                 false, //Active,
                                 "" );  //Color );   

            // create an empty hive object
            hive = new Hive( "",     //Number
                             "",    //Name,
                             "",    //Type,
                             "",    //StartDate,
                             "",     //Frames,
                             "",     //Value
                             "",    //Breed,
                             "",    //Source,
                             "",    //Status,
                             "",    //QueenName,
                             "",    //CoronationDate,
                             "",   //Color ); 
                             false, //Clipped,
                             false, //Marked,
                             false ); //Active, 

            //hiveList.Add( hive );

            //int i = hiveList.Count - 1;
            //string summary = String.Format( "{0,-16} {1,-20} {2,-16} {3,-16}",
            //                                    hiveList[ i ].Name,
            //                                    hiveList[ i ].Type,
            //                                    hiveList[ i ].StartDate,
            //                                    hiveList[ i ].Breed );

            //hiveComboBox.Items.Add( summary );
        }

        /// <summary>
        /// delete the selected hive object from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDelete_Click( object sender, EventArgs e )
        {
            int i = hiveComboBox.SelectedIndex;
            hiveList.RemoveAt( i );
            updateHiveList();
        }

        /// <summary>
        /// writes hive data to XML, re-reads it and updates the comboBox and view
        /// </summary>
        private void updateHiveList()
        {
            hiveData.writeHiveData();
            hiveData.readHiveData();
            initializeHiveComboBox();
        }
    }        
}
