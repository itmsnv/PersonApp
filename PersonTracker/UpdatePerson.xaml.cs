using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonTracker
{
    /// <summary>
    /// Interaction logic for UpdatePerson.xaml
    /// </summary>
    public partial class UpdatePerson : Window
    {
        public const string dbcon = "Data Source = C://Users//malbin//Desktop//peopleDB.db";
        public UpdatePerson()
        {
            try
            {
                InitializeComponent();
                //Load Gender Combo-box.
                
                PopulateFields();

                showGenders(cmbGender);
                string updatePersonId = (App.Current as App).updatePersonId;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool IsPostBack { get; private set; }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string updatePersonId = (App.Current as App).updatePersonId;
            try
            {
                //UPDATE person from the data-grid.
                SQLiteConnection conn = new SQLiteConnection(dbcon);
                conn.Open();
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                SQLiteCommand cmd = new SQLiteCommand();
                String str = "UPDATE tblPerson SET Name = '"+ txtName.Text +"' WHERE Id = " + txtId.Text + ";";
                cmd.CommandText = str;
                ad.SelectCommand = cmd;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMessage.Content = "Person Updated";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateFields()
        {

            try
            {
                string updatePersonId = (App.Current as App).updatePersonId;
                using (SQLiteConnection con1 = new SQLiteConnection("Data Source = C://Users//malbin//Desktop//peopleDB.db"))
                {
                    DataTable dt = new DataTable();
                    con1.Open();
                    SQLiteDataReader myReader = null;
                    SQLiteCommand myCommand = new SQLiteCommand("SELECT tblPerson.Id, tblPerson.Name, tblGender.Id AS GenderId, tblGender.Name AS Gender FROM tblPerson left outer join tblGender on tblGender.ID = tblPerson.GenderId where tblPerson.Id = " + updatePersonId.ToString() + ";", con1);
                    //
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        //SET the selected values from the data-grid to the update form.
                        txtId.Text = (myReader["Id"].ToString());
                        txtName.Text = (myReader["Name"].ToString());
                        cmbGender.SelectedValue = (myReader["GenderId"].ToString());

                    }
                    con1.Close();
                }//end using
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void showGenders(ComboBox cmbGender)
        {
            //INSERT Genders into combo-box.
            cmbGender.Items.Clear();
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dbcon);
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT Id,Name FROM tblGender", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblGender");
                cmbGender.ItemsSource = ds.Tables[0].DefaultView;
                cmbGender.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
                cmbGender.SelectedValuePath = ds.Tables[0].Columns["Id"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}


