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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string dbcon = "Data Source = C://Users//malbin//Desktop//peopleDB.db";


        public MainWindow()
        { 
            try
            {
                InitializeComponent();
                lblMessage.Content = "";
                //LOAD Person data-grid on startup.
                SQLiteConnection conn = new SQLiteConnection(dbcon);
                conn.Open();
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                SQLiteCommand cmd = new SQLiteCommand();
                String str = "SELECT tblPerson.Id, tblPerson.Name, tblGender.Name as Gender FROM tblPerson left outer join tblGender on tblGender.ID = tblPerson.GenderId;";
                cmd.CommandText = str;
                ad.SelectCommand = cmd;
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                ad.Fill(ds);
                personList.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Gender genderwindow = new Gender();
            genderwindow.Show();
            //this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void personList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DataRowView)personList.SelectedItem != null)
            {
                try
                {
                    DataRowView drv = (DataRowView)personList.SelectedItem;
                    String result = (drv["Id"]).ToString();
                    //MessageBox.Show(result);
                    (App.Current as App).updatePersonId = result;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           

        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            //Grab the Id field from the personList data-grid and store it in the result variable.
            DataRowView dataRowView = (DataRowView)personList.SelectedItem;
            String result = (dataRowView["Id"]).ToString();
            //MessageBox.Show(result);

            try
            { 
                //DELETE person from the data-grid.
                SQLiteConnection conn = new SQLiteConnection(dbcon);
                conn.Open();
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                SQLiteCommand cmd = new SQLiteCommand();
                String str = "DELETE FROM tblPerson WHERE Id = " + result + ";";
                cmd.CommandText = str;
                ad.SelectCommand = cmd;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMessage.Content = "Person Deleted";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //personList.Items.Refresh();
                //REFRESH person from the data-grid.
                SQLiteConnection conn = new SQLiteConnection(dbcon);
                conn.Open();
                lblMessage.Content = conn.State;
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                SQLiteCommand cmd = new SQLiteCommand();
                String str = "SELECT tblPerson.Id, tblPerson.Name, tblGender.Name as Gender FROM tblPerson left outer join tblGender on tblGender.ID = tblPerson.GenderId;";
                cmd.CommandText = str;
                ad.SelectCommand = cmd;
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                ad.Fill(ds);
                personList.ItemsSource = ds.Tables[0].DefaultView;
                lblMessage.Content = "Person has been removed and list has been refreshed!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdatePerson personWindow = new UpdatePerson();
                personWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreatePerson createPerson = new CreatePerson();
            createPerson.Show();
        }

        private void personList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((DataRowView)personList.SelectedItem != null)
            {
                lblDelete.Content = "";
                DataRowView drv = (DataRowView)personList.SelectedItem;
                String result = (drv["Name"]).ToString();
                lblDelete.Content = "You have double clicked " + result + " click the update button to edit the person.";
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

            //REFRESH person from the data-grid.
            SQLiteConnection conn = new SQLiteConnection(dbcon);
            conn.Open();
     
            SQLiteDataAdapter ad = new SQLiteDataAdapter();
            SQLiteCommand cmd = new SQLiteCommand();
            String str = "SELECT tblPerson.Id, tblPerson.Name, tblGender.Name as Gender FROM tblPerson left outer join tblGender on tblGender.ID = tblPerson.GenderId;";
            cmd.CommandText = str;
            ad.SelectCommand = cmd;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            personList.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close();
            lblMessage.Content = "Data Grid has been refreshed!";

        }
    }

}

