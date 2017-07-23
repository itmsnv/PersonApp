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
    /// Interaction logic for Gender.xaml
    /// </summary>
    public partial class Gender : Window
    {
        public const string dbcon = "Data Source = C://Users//malbin//Desktop//peopleDB.db";
        public Gender()
        {
            try
            {
                InitializeComponent();

                //run query to remove the course
                SQLiteConnection conn = new SQLiteConnection(dbcon);
                conn.Open();
                lblMessage.Content = conn.State;
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                SQLiteCommand cmd = new SQLiteCommand();
                String str = "SELECT Id,Name FROM tblGender;";
                cmd.CommandText = str;
                ad.SelectCommand = cmd;
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                ad.Fill(ds);
                myList.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
                lblMessage.Content = ds.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }


    }

















//private void button1_Click_1(object sender, EventArgs e)
//{
//    conn.Open();
//    SQLiteCommand comm = new SQLiteCommand("Select * From Patients", conn);
//    using (SQLiteDataReader read = comm.ExecuteReader())
//    {
//        while (read.Read())
//        {
//            dataGridView1.Rows.Add(new object[] {
//            read.GetValue(0),  // U can use column index
//            read.GetValue(read.GetOrdinal("PatientName")),  // Or column name like this
//            read.GetValue(read.GetOrdinal("PatientAge")),
//            read.GetValue(read.GetOrdinal("PhoneNumber"))
//            });
//        }
//    }

//}