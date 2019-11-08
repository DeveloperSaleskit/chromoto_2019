using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Account.Common;
using System.Configuration;

namespace Account
{
    public partial class CompanyFYNSplash : Form
    {
        public static string MasterSQLConnectionString = Common.Encryption.ConstrMaster;
        public static string SQLConnectionString = Common.Encryption.Constr;
        public static string BackupSQLConnectionString = Common.Encryption.ConstrBackUP;
        #region "Variable Declaration..."

        
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        

        #endregion


       
        //public static SqlConnection MastercnnConnection = new SqlConnection(MasterSQLConnectionString);
       // public static SqlConnection cnnConnection = new SqlConnection(MasterSQLConnectionString);
        public CompanyFYNSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            //Common.Encryption Encry = new Encryption();

            //Encry.Decrypt();
            //Encry.DecryptMaster();
            //Encry.DecryptBackUP();

            //string MasterSQLConnectionString = Common.Encryption.ConstrMaster;

            //SqlConnection MastercnnConnection = new SqlConnection(MasterSQLConnectionString);

            //MastercnnConnection.Open();
            //// MessageBox.Show(Application.StartupPath.ToString());
            ////MessageBox.Show(ConfigurationManager.AppSettings["DBName"].ToString());
            //if (!File.Exists(Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Data.mdf"))
            //{
            //    //string Qry = "CREATE DATABASE "+ConfigurationManager.AppSettings["DBName"].ToString()+" ON  PRIMARY ( NAME = N'CRM', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'AutoTest_Log', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";
            //    string Qry = "CREATE DATABASE " + ConfigurationManager.AppSettings["DBName"].ToString() + " ON  PRIMARY ( NAME = N'" + ConfigurationManager.AppSettings["DBName"].ToString() + "', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Log', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";

            //    SqlCommand cmd = new SqlCommand(Qry, MastercnnConnection);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Database created successfully");
               

            //    //string script = File.ReadAllText(@"D:\createdb.sql");
            //    string SQLFilePath = Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["SQLFileName"].ToString();
            //    string CreateDB_script = File.ReadAllText(SQLFilePath);
                
            //    string SQLConnectionString = Common.Encryption.Constr;

            //    SqlConnection conn = new SqlConnection(SQLConnectionString);
            //    Server server = new Server(new ServerConnection(conn));
            //    server.ConnectionContext.ExecuteNonQuery(CreateDB_script);                
            //    MessageBox.Show("Database attached successfully");              

            //}

            ////MastercnnConnection.Open();
            //if (!File.Exists(Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Data.mdf"))
            //{
            //    //string Qry = "CREATE DATABASE "+ConfigurationManager.AppSettings["DBName"].ToString()+" ON  PRIMARY ( NAME = N'CRM', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'AutoTest_Log', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";
            //    string Qry = "CREATE DATABASE " + ConfigurationManager.AppSettings["BackupDBName"].ToString() + " ON  PRIMARY ( NAME = N'" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Log', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";

            //    SqlCommand cmd = new SqlCommand(Qry, MastercnnConnection);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Database created successfully");
            //   // MastercnnConnection.Close();

            //    //string script = File.ReadAllText(@"D:\createdb.sql");
            //    string BackupSQLFilePath = Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["JP_MasterDB"].ToString();

            //    string JP_MasterDB_script = File.ReadAllText(BackupSQLFilePath);

            //    string BackupSQLConnectionString = Common.Encryption.ConstrBackUP;
            //    SqlConnection connBackup = new SqlConnection(BackupSQLConnectionString);
            //    Server server = new Server(new ServerConnection(connBackup));                
            //    server.ConnectionContext.ExecuteNonQuery(JP_MasterDB_script);
            //    MessageBox.Show("Backup Database attached successfully");

            //}
            //MastercnnConnection.Close();

            Common.Encryption Encry = new Encryption();
            Encry.Decrypt();
            //cmbCompany.DropDownStyle = ComboBoxStyle.DropDown;
            //cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;

          
            //cmbCompany.Items.Add(" Register");
            //cmbCompany.SelectedIndex = 0;


            objCommon.FillCompanyCombo(cmbCompany);
            cmbCompany.SelectedIndex = 1;       
             

           
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
          
            //CurrentUser.CompId = Convert.ToInt64(cmbCompany.SelectedValue);
            CurrentCompany.CompId = Convert.ToInt16(cmbCompany.SelectedValue);
            CurrentCompany.CompanyName = cmbCompany.Text;
            this.Hide();
            Login lg = new Login();
            lg.ShowDialog();
                                                      
         }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();        
        }         
    }
}
