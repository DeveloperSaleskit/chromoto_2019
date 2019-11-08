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
using System.Xml;
using Microsoft.Win32;

namespace Account
{
    public partial class SplashProgress : Form
    {
        //public static string MasterSQLConnectionString = Common.Encryption.ConstrMaster;
        //public static string SQLConnectionString = Common.Encryption.Constr;
        //public static string BackupSQLConnectionString = Common.Encryption.ConstrBackUP;

        //-------------------
        public string AppConfigPath = "";
        XmlDocument xmlDoc = new XmlDocument();

        #region "Variable Declaration (Connection Strings)..."

        string connStr = "";
        string keyName, ISIKey, ISIValue = "";

        ListViewItem lvi = new ListViewItem();
        string MasterConn, MainConn, BackupConn = "";
        #endregion
        //-------------------
        public SplashProgress()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
             
        }   
              
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string registryKey = @"SmartSalesKit";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey);
                if (key != null)
                {
                    while (progressBar1.Value < 100)
                        progressBar1.Value += 5;

                    if (checkInstalled("SmartSalesKit"))
                    {
                        //if (ISIKey == null)
                        //{
                        //    MessageBox.Show("Configuration for database has already been completed.");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Configuration for database has been completed successfully.");
                        //}
                        MessageBox.Show("SaleKit Installed successfully.");

                        while (progressBar1.Value == 600)
                            progressBar1.Value = 700;

                        //Application.Exit();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Restart SmartSalesKit.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Application.Exit();
                    }
                }
                //else
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //public static -default
        public bool checkInstalled(string c_name)
        {
            //try
            //{
            //try
            //{
            string displayName;
            string SPath;
            string SInstallationLocation;

            #region Win 32 bit

            //  string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            string registryKey = @"SmartSalesKit";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey);
            if (key != null)
            {
                SInstallationLocation = (string)key.GetValue("InstallPath");

                if (SInstallationLocation != null)
                {
                    //int p;

                    //progressBar1.Minimum = 0;
                    ////progressBar1.Maximum = 200;

                    //for (p = 0; p <= 200; p++)
                    //{
                    //    progressBar1.Value = p;

                    #region App config location and load nodes data

                   // MessageBox.Show(SInstallationLocation.ToString());
                    AppConfigPath = SInstallationLocation + @"Application\";

                    //----------------code for get App config file n edit start----------------

                    //-----------------working fine---------
                   // MessageBox.Show(AppConfigPath.ToString());
                    xmlDoc.Load(AppConfigPath + "\\SmartSalesKit.exe.config");

                    while (progressBar1.Value == 100)
                        progressBar1.Value = 200;

                    //MessageBox.Show(AppConfigPath.ToString());
                    #endregion
                    //---------------check if software app config settings and db creation has been done or not------------
                    #region set flag for check wether Software loading first time or not
                    XmlNode appSettingsNodeISI = xmlDoc.SelectSingleNode("configuration/appSettings");
                   // MessageBox.Show("Finding XML nodes");
                    foreach (XmlNode node in appSettingsNodeISI.ChildNodes)
                    {
                        if (node.Attributes["key"].Value.ToString() == "ISI" && node.Attributes["value"].Value.ToString() == "False")
                        {
                            ISIKey = "True";
                          //  MessageBox.Show("ISI False");
                        }
                    }

                    #endregion
                    //-------------------------------------
                    #region check SQL server existance in registry
                    //-------------get instance name by check sql instance in registry -------

                    //RegistryKey rkSQL = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                    //String[] instances = (String[])rkSQL.GetValue("InstalledInstances");

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("SQLInstance", typeof(string));

                    //if (instances.Length > 0)
                    //{
                    //    foreach (string element in instances)
                    //    {
                   // MessageBox.Show(System.Environment.MachineName.ToString());
                    DataRow dr = dataTable.NewRow();
                    dr["SQLInstance"] = System.Environment.MachineName + @"\" + "SQLEXPRESS";
                    dataTable.Rows.Add(dr);
                    //MessageBox.Show(dataTable.Rows.Count.ToString());

                    //---------------
                    #region code for default instance of sql--not in use

                    //if (element == "MSSQLSERVER")
                    //{
                    //    MessageBox.Show(System.Environment.MachineName);
                    //    DataRow dr = dataTable.NewRow();
                    //    dr["SQLInstance"] = System.Environment.MachineName.ToString();
                    //    dataTable.Rows.Add(dr);
                    //}
                    //else
                    //{
                    //    MessageBox.Show(System.Environment.MachineName + @"\" + element);
                    //    DataRow dr = dataTable.NewRow();
                    //    dr["SQLInstance"] = System.Environment.MachineName.ToString();
                    //    dataTable.Rows.Add(dr);
                    //}

                    #endregion

                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No SQL instances found");
                    //}

                    #endregion

                    #region get SQL first instance name
                    string SqlName = "";
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                        //MessageBox.Show(dataTable.Rows[0][0].ToString());
                        SqlName = dataTable.Rows[0][0].ToString();
                       // MessageBox.Show(SqlName.ToString());
                    }
                    #endregion
                    //------------------------------------------
                    #region run code if software get installed first time only
                    XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/connectionStrings");
                    string UpdatedConn = "";

                    if (ISIKey == "True")
                    {
                        #region check nodes Master conn,CRM conn, Backup conn strings

                        foreach (XmlNode node in appSettingsNode.ChildNodes)
                        {
                           
                            #region Master Node code
                            if (node.Attributes["name"].Value.ToString() == "Master_DBConnectionString")
                            {
                                keyName = node.Attributes["name"].Value.ToString();
                                connStr = node.Attributes["connectionString"].Value.ToString();

                                MasterConn = Decrypt(connStr);
                                //MessageBox.Show(MasterConn.ToString());
                                //-----------------Get Instance from decrypted string n update client pc SQL Instance-----------------

                                // This string is also separated by Windows line breaks.
                                string value = MasterConn;
                                char[] delimiters = new char[] { '=', ';' };
                                string[] parts = value.Split(delimiters,
                                                 StringSplitOptions.RemoveEmptyEntries);
                                parts = value.Split(new string[] { ";" }, StringSplitOptions.None);
                                string DI = parts[0].ToString();
                                string[] parts1 = DI.Split(new string[] { "=" }, StringSplitOptions.None);
                                //MessageBox.Show(parts1[1].ToString());
                                string Instance = parts1[1].ToString();
                                parts1[1] = SqlName.ToString();
                                //MessageBox.Show(parts1[1].ToString());
                                UpdatedConn = value.Replace(Instance, SqlName);
                              //  MessageBox.Show(UpdatedConn.ToString());
                                string UpdatedEncConn = "";
                                //----------------------------------------------------------------
                                //-------------------------Encrypt updated conn string ----------

                                string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                string test = "";
                                int MainLength = Main.Length;
                                int SubIndex;
                                string ch;
                                if (UpdatedConn.Trim() != "")
                                {
                                    foreach (char c in UpdatedConn.Trim().ToString())
                                    {
                                        SubIndex = Main.IndexOf(c) + 11 - 2;
                                        if (SubIndex >= MainLength)
                                        {
                                            ch = Main.Substring(SubIndex - MainLength, 1);
                                        }
                                        else
                                        {
                                            ch = Main.Substring(SubIndex, 1);
                                        }
                                        test = test + ch;

                                    }
                                    UpdatedEncConn = test;
                                }
                              //  MessageBox.Show(UpdatedEncConn);
                                //---------------------------------------------------------------------
                                UpdateKey("Master_DBConnectionString", UpdatedEncConn.ToString());

                                Common.Encryption Encry = new Encryption();

                                Encry.Decrypt();
                                Encry.DecryptMaster();
                                Encry.DecryptBackUP();

                                //  string MasterSQLConnectionString = Common.Encryption.Constr;
                                try
                                {
                                    SqlConnection MastercnnConnection = new SqlConnection(UpdatedConn);

                                    MastercnnConnection.Open();
                                    // MessageBox.Show(Application.StartupPath.ToString());
                                    //MessageBox.Show(ConfigurationManager.AppSettings["DBName"].ToString());
                                    if (!File.Exists(Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Data.mdf"))
                                    {
                                        string Qry = "CREATE DATABASE " + ConfigurationManager.AppSettings["DBName"].ToString() + " ON  PRIMARY ( NAME = N'" + ConfigurationManager.AppSettings["DBName"].ToString() + "', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Log', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";

                                        SqlCommand cmd = new SqlCommand(Qry, MastercnnConnection);
                                        cmd.ExecuteNonQuery();
                                        UpdateKeyAppsettings("ISI", "True");
                                        //MessageBox.Show("Database created successfully");
                                    }

                                    //======================= create JP_MasterDB ----------

                                    if (!File.Exists(Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Data.mdf"))
                                    {
                                        string BackupQry = "CREATE DATABASE " + ConfigurationManager.AppSettings["BackupDBName"].ToString() + " ON  PRIMARY ( NAME = N'" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Log', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";

                                        SqlCommand cmd = new SqlCommand(BackupQry, MastercnnConnection);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Backup Database created successfully");
                                    }

                                    //-------------------------------JP_MasterDB end -------

                                    while (progressBar1.Value == 200)
                                        progressBar1.Value = 300;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);

                                }
                            }
                            #endregion                            

                            #region CRM Database Node
                            try
                            {
                                if (node.Attributes["name"].Value.ToString() == "DBConnectionString")
                                {
                                    keyName = node.Attributes["name"].Value.ToString();
                                    connStr = node.Attributes["connectionString"].Value.ToString();

                                    MainConn = Decrypt(connStr);

                                    //-----------------Get Instance from decrypted string n update client pc SQL Instance-----------------

                                    // This string is also separated by Windows line breaks.
                                    string value = MainConn;
                                    char[] delimiters = new char[] { '=', ';' };
                                    string[] parts = value.Split(delimiters,
                                                     StringSplitOptions.RemoveEmptyEntries);
                                    parts = value.Split(new string[] { ";" }, StringSplitOptions.None);
                                    string DI = parts[0].ToString();
                                    string[] parts1 = DI.Split(new string[] { "=" }, StringSplitOptions.None);
                                   // MessageBox.Show(parts1[1].ToString());
                                    string Instance = parts1[1].ToString();
                                    parts1[1] = SqlName.ToString();
                                   // MessageBox.Show(parts1[1].ToString());
                                    string MainUpdatedConn = value.Replace(Instance, SqlName);
                                    string UpdatedEncConn1 = "";
                                    //----------------------------------------------------------------
                                    //-------------------------Encrypt updated conn string ----------

                                    string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                    string test = "";
                                    int MainLength = Main.Length;
                                    int SubIndex;
                                    string ch;
                                    if (MainUpdatedConn.Trim() != "")
                                    {
                                        foreach (char c in MainUpdatedConn.Trim().ToString())
                                        {
                                            SubIndex = Main.IndexOf(c) + 11 - 2;
                                            if (SubIndex >= MainLength)
                                            {
                                                ch = Main.Substring(SubIndex - MainLength, 1);
                                            }
                                            else
                                            {
                                                ch = Main.Substring(SubIndex, 1);
                                            }
                                            test = test + ch;

                                        }
                                        UpdatedEncConn1 = test;
                                    }
                                    //MessageBox.Show(UpdatedEncConn1);
                                    //---------------------------------------------------------------------
                                    UpdateKey("DBConnectionString", UpdatedEncConn1.ToString());

                                    //----------add code to run create db script & dbinitialize

                                    Common.Encryption Encry = new Encryption();

                                    Encry.Decrypt();
                                    Encry.DecryptMaster();
                                    Encry.DecryptBackUP();

                                    string MasterSQLConnectionString = Common.Encryption.Constr;

                                    SqlConnection MastercnnConnection = new SqlConnection(UpdatedConn);
                                    SqlConnection MaincnnConnection = new SqlConnection(MainUpdatedConn);

                                    MastercnnConnection.Open();
                                    // MessageBox.Show(Application.StartupPath.ToString());
                                    //MessageBox.Show(ConfigurationManager.AppSettings["DBName"].ToString());
                                    if (File.Exists(Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Data.mdf"))
                                    {
                                        string SQLFilePath = Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["SQLFileName"].ToString();
                                        string CreateDB_script = File.ReadAllText(SQLFilePath);
                                        string SQLConnectionString = Common.Encryption.Constr;

                                        ExecuteBatchNonQuery(CreateDB_script, MaincnnConnection);
                                        MaincnnConnection.Open();

                                        //-------execute dbinitialize============

                                        string DBInitializeQry = "Exec [proc_DBInitialize] 1,1";

                                        SqlCommand DBIcmd = new SqlCommand(DBInitializeQry, MaincnnConnection);
                                        DBIcmd.ExecuteNonQuery();

                                        //MessageBox.Show("Database Default Data initialized successfully");

                                        //--------------------------

                                        #region set adhoc query execute
                                        //------- set adhoc ============

                                        string SysSettingsInsQry1 = "EXEC sp_configure 'show advanced options', 1\n";
                                        SysSettingsInsQry1 = SysSettingsInsQry1 + "RECONFIGURE\n";

                                        string SysSettingsInsQry2 = "EXEC sp_configure 'ad hoc distributed queries', 1\n";
                                        SysSettingsInsQry2 = SysSettingsInsQry2 + "RECONFIGURE\n";

                                        SysSettingsInsQry1 = SysSettingsInsQry1.Replace("\n", Environment.NewLine);
                                        SqlCommand SysInscmd1 = new SqlCommand(SysSettingsInsQry1, MaincnnConnection);
                                        SysInscmd1.ExecuteNonQuery();

                                        SysSettingsInsQry2 = SysSettingsInsQry2.Replace("\n", Environment.NewLine);
                                        SqlCommand SysInscmd2 = new SqlCommand(SysSettingsInsQry2, MaincnnConnection);
                                        SysInscmd2.ExecuteNonQuery();

                                        //--------------------------
                                        #endregion
                                    }

                                    MastercnnConnection.Close();

                                    while (progressBar1.Value == 300)
                                        progressBar1.Value = 400;
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                            }
                            #endregion

                            #region Backup Database Node
                            try
                            {
                                if (node.Attributes["name"].Value.ToString() == "DBConnectionString_Backup")
                                {
                                    keyName = node.Attributes["name"].Value.ToString();
                                    connStr = node.Attributes["connectionString"].Value.ToString();

                                    BackupConn = Decrypt(connStr);
                                    //-----------------Get Instance from decrypted string n update client pc SQL Instance-----------------

                                    // This string is also separated by Windows line breaks.
                                    string value = BackupConn;
                                    char[] delimiters = new char[] { '=', ';' };
                                    string[] parts = value.Split(delimiters,
                                                     StringSplitOptions.RemoveEmptyEntries);
                                    parts = value.Split(new string[] { ";" }, StringSplitOptions.None);
                                    string DI = parts[0].ToString();
                                    string[] parts1 = DI.Split(new string[] { "=" }, StringSplitOptions.None);
                                    //MessageBox.Show(parts1[1].ToString());
                                    string Instance = parts1[1].ToString();
                                    parts1[1] = SqlName.ToString();
                                    //MessageBox.Show(parts1[1].ToString());
                                    string BACKPUpdatedConn = value.Replace(Instance, SqlName);
                                    string UpdatedEncConn2 = "";
                                    //----------------------------------------------------------------
                                    //-------------------------Encrypt updated conn string ----------

                                    string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                    string test = "";
                                    int MainLength = Main.Length;
                                    int SubIndex;
                                    string ch;
                                    if (BACKPUpdatedConn.Trim() != "")
                                    {
                                        foreach (char c in BACKPUpdatedConn.Trim().ToString())
                                        {
                                            SubIndex = Main.IndexOf(c) + 11 - 2;
                                            if (SubIndex >= MainLength)
                                            {
                                                ch = Main.Substring(SubIndex - MainLength, 1);
                                            }
                                            else
                                            {
                                                ch = Main.Substring(SubIndex, 1);
                                            }
                                            test = test + ch;

                                        }
                                        UpdatedEncConn2 = test;
                                    }
                                    //MessageBox.Show(UpdatedEncConn2);
                                    //---------------------------------------------------------------------
                                    UpdateKey("DBConnectionString_Backup", UpdatedEncConn2.ToString());

                                    //----------add code to run create db script & dbinitialize

                                    Common.Encryption Encry = new Encryption();

                                    Encry.Decrypt();
                                    Encry.DecryptMaster();
                                    Encry.DecryptBackUP();

                                    string MasterSQLConnectionString = Common.Encryption.Constr;

                                    SqlConnection MastercnnConnection = new SqlConnection(UpdatedConn);
                                    SqlConnection BackupcnnConnection = new SqlConnection(BACKPUpdatedConn);

                                    MastercnnConnection.Open();
                                    //  MessageBox.Show(Application.StartupPath.ToString());
                                    //MessageBox.Show(ConfigurationManager.AppSettings["DBName"].ToString());
                                    string BackupSQLFilePath = Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["JP_MasterDB"].ToString();
                                    string BACKUPCreateDB_script = File.ReadAllText(BackupSQLFilePath);

                                    ExecuteBatchNonQuery(BACKUPCreateDB_script, BackupcnnConnection);
                                    BackupcnnConnection.Open();

                                    //-------execute dbinitialize============

                                    string DBInitializeQry = "Exec [usp_DBInitialize] 1,1,1";

                                    SqlCommand DBIcmd = new SqlCommand(DBInitializeQry, BackupcnnConnection);
                                    DBIcmd.ExecuteNonQuery();
                                   // MessageBox.Show("Database Default Data initialized successfully");
                                    //--------------------------

                                    DirectoryInfo root;
                                    var drives = DriveInfo.GetDrives();
                                    foreach (var drive in drives)
                                    {
                                        if (drive.DriveType != DriveType.CDRom)
                                            if (drive.VolumeLabel.Contains(ConfigurationManager.AppSettings["BackupFolder"].ToString()))
                                            {
                                                root = drive.RootDirectory;
                                                //String path = root + @"DB_Backup\Backup\";
                                                String path_Data = root + @"DB_Backup\";
                                                String path_Backup = root + @"DB_Backup\Backup\";
                                                String Destination_Path = "/";
                                                //break;
                                               // string SysSettingsInsQry = "Insert into SysSettings (Path_BackUp) values('" + path + "')";
                                                string SysSettingsInsQry = "Insert into SysSettings (Path_Data,Path_BackUp,Destination_Path) values('" + path_Data + "','" + path_Backup + "','" + Destination_Path + "')";
                                                SqlCommand SysInscmd = new SqlCommand(SysSettingsInsQry, BackupcnnConnection);
                                                SysInscmd.ExecuteNonQuery();
                                                BackupcnnConnection.Close();
                                                break;
                                            }
                                    }

                                 
                                    // MessageBox.Show("Database Default Data initialized successfully");

                                    MastercnnConnection.Close();

                                    while (progressBar1.Value == 400)
                                        progressBar1.Value = 500;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                            }

                            #endregion

                            #region Change Date Time to UK Format

                            //--------------
                            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
                            rkey.SetValue("sShortDate", "dd/MM/yyyy");
                            rkey.SetValue("sLongDate", "dd MMMM yyyy");
                            rkey.Close();

                            while (progressBar1.Value == 500)
                                progressBar1.Value = 600;
                            //----------------

                            #endregion                          

                        }
                        #endregion
                    }
                    #endregion

                    //  }
                }

                #region code for get LocalMachine installed softwares loop
                //foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                //{
                //    displayName = subkey.GetValue("DisplayName") as string;
                //    if (displayName != null && displayName.Contains(c_name))//check insalled software name in registry
                //    {   //check insalled software name in registry
                //        if (subkey.Name == @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{12345678-1234-1234-1234-123456789012}")
                //        {
                //            SInstallationLocation = subkey.GetValue("InstallLocation") as string;

                //        }
                //        return true;//return true on successfully creation of databases CRM & JP_MatserDB
                //    }//end of check Software existance
                //}//end of registry key comparing
                #endregion

            }//end of fing main regedit location
            key.Close();// end of 32 bit system code

            #endregion

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}
            return false;

        }


        private void GenerateDatabase()
        {
            //----------------------by script code -----------

            Common.Encryption Encry = new Encryption();

            Encry.Decrypt();
            Encry.DecryptMaster();
            Encry.DecryptBackUP();

            string MasterSQLConnectionString = Common.Encryption.ConstrMaster;

            SqlConnection MastercnnConnection = new SqlConnection(MasterSQLConnectionString);

            MastercnnConnection.Open();
            // MessageBox.Show(Application.StartupPath.ToString());
            //MessageBox.Show(ConfigurationManager.AppSettings["DBName"].ToString());
            if (!File.Exists(Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Data.mdf"))
            {
                //string Qry = "CREATE DATABASE "+ConfigurationManager.AppSettings["DBName"].ToString()+" ON  PRIMARY ( NAME = N'CRM', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'AutoTest_Log', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";
                string Qry = "CREATE DATABASE " + ConfigurationManager.AppSettings["DBName"].ToString() + " ON  PRIMARY ( NAME = N'" + ConfigurationManager.AppSettings["DBName"].ToString() + "', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Log', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["DBName"].ToString() + "_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";

                SqlCommand cmd = new SqlCommand(Qry, MastercnnConnection);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Database created successfully");
                //  RestoreDB();
                //string script = File.ReadAllText(@"D:\createdb.sql");
                string SQLFilePath = Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["SQLFileName"].ToString();
                string CreateDB_script = File.ReadAllText(SQLFilePath);
                string SQLConnectionString = Common.Encryption.Constr;
                SqlConnection conn = new SqlConnection(SQLConnectionString);
                //Server server = new Server(new ServerConnection(conn));
                //server.ConnectionContext.ExecuteNonQuery(CreateDB_script);
                ExecuteBatchNonQuery(CreateDB_script, conn);
                conn.Open();

                //-------execute dbinitialize============

                string DBInitializeQry = "Exec [proc_DBInitialize] 1,1";

                SqlCommand DBIcmd = new SqlCommand(DBInitializeQry, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DBIcmd.ExecuteNonQuery();

                //MessageBox.Show("Database Default Data initialized successfully");

                //--------------------------

                conn.Close();

                //MessageBox.Show("Database attached successfully");
            }

            //MastercnnConnection.Open();
            if (!File.Exists(Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Data.mdf"))
            {
                //string Qry = "CREATE DATABASE "+ConfigurationManager.AppSettings["DBName"].ToString()+" ON  PRIMARY ( NAME = N'CRM', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'AutoTest_Log', FILENAME = N'" + Application.StartupPath + "\\db\\CRM_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";
                string Qry = "CREATE DATABASE " + ConfigurationManager.AppSettings["BackupDBName"].ToString() + " ON  PRIMARY ( NAME = N'" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) LOG ON ( NAME = N'" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Log', FILENAME = N'" + Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["BackupDBName"].ToString() + "_Log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )";

                SqlCommand cmd = new SqlCommand(Qry, MastercnnConnection);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Database created successfully");
                // MastercnnConnection.Close();

                string BackupSQLFilePath = Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["JP_MasterDB"].ToString();
                string BACKUPCreateDB_script = File.ReadAllText(BackupSQLFilePath);

                string BackupSQLConnectionString = Common.Encryption.ConstrBackUP;

                SqlConnection connBackup = new SqlConnection(BackupSQLConnectionString);
                //Server server = new Server(new ServerConnection(conn));
                //server.ConnectionContext.ExecuteNonQuery(CreateDB_script);

                ExecuteBatchNonQuery(BACKUPCreateDB_script, connBackup);
                connBackup.Open();

                //-------execute dbinitialize============

                string DBInitializeQry = "Exec [usp_DBInitialize] 1,1,1";

                SqlCommand DBIcmd = new SqlCommand(DBInitializeQry, connBackup);
                cmd.CommandType = CommandType.StoredProcedure;
                DBIcmd.ExecuteNonQuery();
                //MessageBox.Show("Database Default Data initialized successfully");
                //--------------------------

                //string script = File.ReadAllText(@"D:\createdb.sql");
                //string BackupSQLFilePath = Application.StartupPath + "\\db\\" + ConfigurationManager.AppSettings["JP_MasterDB"].ToString();

                //string JP_MasterDB_script = File.ReadAllText(BackupSQLFilePath);

                //string BackupSQLConnectionString = Common.Encryption.ConstrBackUP;
                //SqlConnection connBackup = new SqlConnection(BackupSQLConnectionString);
                //Server server = new Server(new ServerConnection(connBackup));
                //server.ConnectionContext.ExecuteNonQuery(JP_MasterDB_script);
                //MessageBox.Show("Backup Database attached successfully");

            }
            MastercnnConnection.Close();
            //-----------------------
        }

        private void ExecuteBatchNonQuery(string sql, SqlConnection conn)
        {
            string sqlBatch = string.Empty;
            SqlCommand cmd = new SqlCommand(string.Empty, conn);
            conn.Open();
            sql += "\nGO";   // make sure last batch is executed.
            try
            {
                foreach (string line in sql.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.ToUpperInvariant().Trim() == "GO")
                    {
                        cmd.CommandText = sqlBatch;
                        cmd.ExecuteNonQuery();
                        sqlBatch = string.Empty;
                    }
                    else
                    {
                        sqlBatch += line + "\n";
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        //--For App config file data load
        private void loadFromConfig()
        {
            //this.lstDatabases.Items.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppConfigPath + "\\SmartSalesKit.exe.config");
            //XmlNode appSettingsNode =
            //  xmlDoc.SelectSingleNode("configuration/appSettings");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/connectionStrings");
            foreach (XmlNode node in appSettingsNode.ChildNodes)
            {
                //ListViewItem lvi = new ListViewItem();
                connStr = node.Attributes["connectionString"].Value.ToString();
                keyName = node.Attributes["name"].Value.ToString();
                lvi.Text = keyName;
                lvi.SubItems.Add(connStr);
                //this.lvDatabases.Items.Add(lvi);
            }
        }

        //--For update data in App config
        public void UpdateKey(string strKey, string newValue)
        {
            if (!KeyExists(strKey))
                throw new ArgumentNullException("Key", "<" + strKey +
                      "> does not exist in the configuration. Update failed.");
            XmlNode appSettingsNode1 =
               xmlDoc.SelectSingleNode("configuration/connectionStrings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode1)
            {
                if (childNode.Attributes["name"].Value == strKey)
                    childNode.Attributes["connectionString"].Value = newValue;
            }
            xmlDoc.Save(AppConfigPath + "\\SmartSalesKit.exe.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("geoSettings/summary");

        }

        //--For update data in App config
        public void UpdateKeyAppsettings(string strKey, string newValue)
        {
            if (!KeyExistsAppsettings(strKey))
                throw new ArgumentNullException("Key", "<" + strKey +
                      "> does not exist in the configuration. Update failed.");
            XmlNode appSettingsNode =
               xmlDoc.SelectSingleNode("configuration/appSettings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                    childNode.Attributes["value"].Value = newValue;
            }
            xmlDoc.Save(AppConfigPath + "\\SmartSalesKit.exe.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("geoSettings/summary");
        }

        //check if key exists or not
        public bool KeyExists(string strKey)
        {
            XmlNode appSettingsNode =
              xmlDoc.SelectSingleNode("configuration/connectionStrings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["name"].Value == strKey)
                    return true;
            }
            return false;
        }

        //check if key exists or not
        public bool KeyExistsAppsettings(string strKey)
        {
            XmlNode appSettingsNode =
              xmlDoc.SelectSingleNode("configuration/appSettings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                    return true;
            }
            return false;
        }

        //define con string variable
        private static string mConstr, mConstrBackUP, mConstrMaster;

        public static string ConstrMaster
        {
            get
            { return mConstrMaster; }
            set
            { mConstrMaster = value; }
        }

        public static string Constr
        {
            get
            { return mConstr; }
            set
            { mConstr = value; }
        }

        public static string ConstrBackUP
        {
            get
            { return mConstrBackUP; }
            set
            { mConstrBackUP = value; }
        }

        public void DecryptMaster()
        {
            string Con = ConfigurationManager.ConnectionStrings["Master_DBConnectionString"].ConnectionString;
            string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string test = "";
            int MainLength = Main.Length;
            int SubIndex;
            string ch;
            if (Con.Trim() != "")
            {
                foreach (char c in Con.Trim().ToString())
                {
                    SubIndex = Main.IndexOf(c) - 11 + 2;

                    if (SubIndex < 0)
                    {
                        ch = Main.Substring(SubIndex + MainLength, 1);
                    }
                    else
                    {

                        {
                            ch = Main.Substring(SubIndex, 1);
                        }
                    }
                    test = test + ch;

                }
                ConstrMaster = test;
            }
        }

        //get connstring and update SQL instance
        public string Decrypt(string DBConnectionString)
        {
            //DBConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string test = "";
            int MainLength = Main.Length;
            int SubIndex;
            string ch;
            if (DBConnectionString.Trim() != "")
            {
                foreach (char c in DBConnectionString.Trim().ToString())
                {
                    SubIndex = Main.IndexOf(c) - 11 + 2;

                    if (SubIndex < 0)
                    {
                        ch = Main.Substring(SubIndex + MainLength, 1);
                    }
                    else
                    {

                        {
                            ch = Main.Substring(SubIndex, 1);
                        }
                    }
                    test = test + ch;

                }
                Constr = test;
            }
            return Constr;
        }

        public void DecryptBackUP()
        {
            string Con = ConfigurationManager.ConnectionStrings["DBConnectionString_Backup"].ConnectionString;
            string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string test = "";
            int MainLength = Main.Length;
            int SubIndex;
            string ch;
            if (Con.Trim() != "")
            {
                foreach (char c in Con.Trim().ToString())
                {
                    SubIndex = Main.IndexOf(c) - 11 + 2;

                    if (SubIndex < 0)
                    {
                        ch = Main.Substring(SubIndex + MainLength, 1);
                    }
                    else
                    {

                        {
                            ch = Main.Substring(SubIndex, 1);
                        }
                    }
                    test = test + ch;

                }
                ConstrBackUP = test;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }


    }
}
