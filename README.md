# PersonApp
Person App Project, built as WPF application with SQLite Database

This is my first crack at building a functional WPF app with an SQLite database.

Below are some websites I used to construct the functionality off the app.

https://www.codeproject.com/Articles/22165/Using-SQLite-in-your-C-Application
https://stackoverflow.com/questions/10290746/wpf-listview-not-populating-with-sqlite 
https://stackoverflow.com/questions/23981424/get-data-of-specific-cell-from-selected-row-in-datagrid-wpf-c-sharp 
http://www.c-sharpcorner.com/uploadfile/syedshakeer/bind-combobox-in-wpf/  
https://stackoverflow.com/questions/5811105/wpf-selected-value-displaymember-path-inconsistency-with-listbox-and-combo-box 
https://stackoverflow.com/questions/7902095/how-to-pass-values-between-two-pages-in-wpf 
https://stackoverflow.com/questions/14113025/how-to-display-data-from-database-into-textbox-and-update-it 
https://stackoverflow.com/questions/4286092/set-selected-value-of-a-combo-box 
https://stackoverflow.com/questions/26773729/check-if-combobox-value-is-empty 


Using visual Studio 2017, you need to setup your environment.
1.  Install SQLite Toolbox
2.  Then install with Nuget Manager SQLite database engine.

Below are the differenct SQLite Querries I run in the app:

                //LOAD personList data-grid on startup.
                SQLiteConnection conn = new SQLiteConnection(dbcon);
                conn.Open();
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                SQLiteCommand cmd = new SQLiteCommand();
                String str = "SELECT tblPerson.Id, tblPerson.Name, tblGender.Name as Gender FROM tblPerson left outer join tblGender on   tblGender.ID = tblPerson.GenderId;";
                cmd.CommandText = str;
                ad.SelectCommand = cmd;
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                ad.Fill(ds);
                personList.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
