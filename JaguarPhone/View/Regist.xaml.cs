using JaguarPhone.Module;
using System.Collections.Generic;
using System.Text.Json;
using System;
using System.IO;
using System.Windows;

namespace JaguarPhone.View
{
    /// <summary>
    /// Interaction logic for Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    SqlConnection con = new SqlConnection();
            //    SqlConnectionStringBuilder conBuilder = new SqlConnectionStringBuilder();

            //    conBuilder.UserID = "register";
            //    conBuilder.Password = "regist";
            //    conBuilder.InitialCatalog = "JaguarPhoneDB";
            //    //conBuilder.DataSource = "RAVI";
            //    conBuilder.ConnectTimeout = 30;

            //    //SqlConnection con = new SqlConnection(conBuilder.ConnectionString);
            //    con.ConnectionString = conBuilder.ConnectionString;
            //    con.Open();

            //    MessageBox.Show($"{con.ConnectionString}"); 
            //    MessageBox.Show($"{con.State}"); 


            //    string loginRegist = telephoneRegist.Text;
            //    string passRegist = passwordTwoRegist.Password;

            //    string addData = $"create login {loginRegist} with password = {passRegist} ";
            //    SqlCommand cmd = new SqlCommand(addData, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show($"Error {ex}");
            //}
        }

    }
}
