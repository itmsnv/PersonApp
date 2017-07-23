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
    /// Interaction logic for CreatePerson.xaml
    /// </summary>
    public partial class CreatePerson : Window
    {
        public const string dbcon = "Data Source = C://Users//malbin//Desktop//peopleDB.db";
        public CreatePerson()
        {
            InitializeComponent();
            lblMessage.Content = "";
            //Load Gender Combo-box.
            showGenders(cmbGender);
        }
        private void btnCreatePerson_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "" /*|| cmbGender.SelectedIndex == -1*/)
            {
                try
                {

                    //INSERT person from the data-grid.
                    SQLiteConnection conn = new SQLiteConnection(dbcon);
                    conn.Open();
                    SQLiteDataAdapter ad = new SQLiteDataAdapter();
                    SQLiteCommand cmd = new SQLiteCommand();
                    String str = "INSERT INTO tblPerson ( Name,GenderId) VALUES ('" + txtFirstName.Text.ToString() + "', " + cmbGender.SelectedValue.ToString() + ")";
                    cmd.CommandText = str;
                    ad.SelectCommand = cmd;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblMessage.Content = "Person Added";
                    txtFirstName.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You must enter you name.");
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
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
