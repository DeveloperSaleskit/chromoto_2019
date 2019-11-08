using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Collections;
using System.Configuration;

namespace Account.DataAccess
{
    class DataAccess
    {
        #region "Private Fields ..."
        private Exception mException;
        private string mErrorMessage = "";
        public static string DatabaseName = "";

        #endregion

        #region "Public Properties ..."

        public Exception Exception
        {
            get { return mException; }
            set { mException = value; }
        }

        public string ErrorMessage
        {
            get { return mErrorMessage; }
            set { mErrorMessage = value; }
        }


        #endregion

        #region "Variable Declaration (Connection Strings)..."

        //Connection String for LocalHost
        //public static string SQLConnectionString = @"Data Source=Manoj;Initial Catalog=KarmaChemical;Integrated Security = true";

        //Connection String for Client
        //public static string SQLConnectionString = @"Data Source=TATA-DB6C8B4388;Initial Catalog=KarmaChemical;Integrated Security = true";
        //public static string SQLConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        public static string SQLConnectionString = Common.Encryption.Constr;

             
        // SQL Connection Object 
        public static SqlConnection cnnConnection = new SqlConnection(SQLConnectionString);

        #endregion

        #region "Method...."

        public DataSet ExecuteDataSetSP(string spName, NameValueCollection paramNameValue, Boolean withOutPara, ref Exception mException, ref  string mErrorMsg, string mModuleName)
        {

            SqlDataAdapter daDataAdapter = new SqlDataAdapter();
            DataSet dsDataSet = new DataSet();

            IEnumerator iEnum = default(IEnumerator);
            if (paramNameValue != null)
            {
                iEnum = paramNameValue.GetEnumerator();
            }
            // Initialize the Exception ... 
            this.Exception = null;
            try
            {
                // Prepare DataAdapter ... 
                daDataAdapter.SelectCommand = new SqlCommand();
                daDataAdapter.SelectCommand.Connection = cnnConnection;
                daDataAdapter.SelectCommand.CommandText = spName;
                daDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Pass Parameters ... 
                if (paramNameValue != null)
                {
                    while (iEnum.MoveNext())
                    {
                        daDataAdapter.SelectCommand.Parameters.AddWithValue(iEnum.Current.ToString(), paramNameValue.GetValues(iEnum.Current.ToString()).GetValue(0).ToString().Trim());
                    }
                }

                if (withOutPara == true)
                {
                    // Add output parameters ... 
                    daDataAdapter.SelectCommand.Parameters.Add("@o_ErrorMesg", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                }

                // Open Database Connection ... 
                cnnConnection.Open();

                // Fill the DataSet ... 
                daDataAdapter.Fill(dsDataSet);

                // Read values of Output Parameters 
                if (withOutPara == true)
                {
                    // Read Values of Output Paramters and Stored into Property 
                    mErrorMsg = (string)(daDataAdapter.SelectCommand.Parameters["@o_ErrorMesg"].Value);
                }
                else
                {
                    mErrorMsg = "";
                }
            }
            catch (Exception exception)
            {
                // Set the Exception ... 
                mException = exception;
                // Insert Exception
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
                BusinessLogic.Common ObjComm = new Account.BusinessLogic.Common();
                ObjComm.WriteExceptionLog(DateTime.Now, exception.Message, mModuleName);
                dsDataSet = null;
            }
            finally
            {
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
            }
            return dsDataSet;
        }

        public DataTable ExecuteDataTableSP(string spName, NameValueCollection paramNameValue, Boolean withOutPara, ref Exception mException, ref  string mErrorMsg, string mModuleName)
        {
            SqlDataAdapter daDataAdapter = new SqlDataAdapter();
            DataTable dtDataTable = new DataTable();
            IEnumerator iEnum = default(IEnumerator);
            DataColumn clmSrNo = new DataColumn("SrNo");

            if (paramNameValue != null)
            {
                iEnum = paramNameValue.GetEnumerator();
            }
            // Initialize the Exception ... 
            this.Exception = null;
            try
            {
                // Add SRNo in Table
                ////if (pSrNo)
                ////{
                ////    // AutoIncremented Serail Number Column ...
                ////    clmSrNo.AutoIncrement = true;
                ////    clmSrNo.AutoIncrementStep = 1;
                ////    clmSrNo.AutoIncrementSeed = 1;
                ////    // Add Column to DataTable ...
                ////    dtDataTable.Columns.Add(clmSrNo);
                ////}

                // Prepare DataAdapter ... 
                daDataAdapter.SelectCommand = new SqlCommand();
                daDataAdapter.SelectCommand.Connection = cnnConnection;
                daDataAdapter.SelectCommand.CommandText = spName;
                daDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Pass Parameters ... 
                if (paramNameValue != null)
                {
                    while (iEnum.MoveNext())
                    {
                        daDataAdapter.SelectCommand.Parameters.AddWithValue(iEnum.Current.ToString(), paramNameValue.GetValues(iEnum.Current.ToString()).GetValue(0).ToString().Trim());
                    }
                }
                if (withOutPara == true)
                {
                    // Add output parameters ... 
                    daDataAdapter.SelectCommand.Parameters.Add("@o_ErrorMesg", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                }
                // Open Database Connection ... 
                cnnConnection.Open();
                // Fill the DataSet ... 
                daDataAdapter.Fill(dtDataTable);
                // Read values of Output Parameters 
                if (withOutPara == true)
                {
                    // Read Values of Output Paramters and Stored into Property 
                    mErrorMsg = (string)(daDataAdapter.SelectCommand.Parameters["@o_ErrorMesg"].Value);
                }
                else
                {
                    mErrorMsg = "";
                }
            }
            catch (Exception exception)
            {
                // Set the Exception ... 
                mException = exception;
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
                // Insert Exception
                BusinessLogic.Common ObjComm = new Account.BusinessLogic.Common();
                ObjComm.WriteExceptionLog(DateTime.Now, exception.Message, mModuleName);
                dtDataTable = null;
            }
            finally
            {
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
            }
            return dtDataTable;
        }

        public void ExecuteSP(string spName, NameValueCollection paramNameValue, Boolean withOutPara, ref Exception mException, ref  string mErrorMsg, string mModuleName)
        {
            SqlCommand cmdSQLCommand = new SqlCommand();
            IEnumerator iEnum = default(IEnumerator);
            if (paramNameValue != null)
            {
                iEnum = paramNameValue.GetEnumerator();
            }

            // Initialize the Exception ... 
            this.Exception = null;
            this.ErrorMessage = "";

            try
            {
                // Prepare DataAdapter ... 
                cmdSQLCommand.Connection = cnnConnection;
                cmdSQLCommand.CommandText = spName;
                cmdSQLCommand.CommandType = CommandType.StoredProcedure;

                // Pass Parameters ... 
                if (paramNameValue != null)
                {
                    while (iEnum.MoveNext())
                    {
                        cmdSQLCommand.Parameters.AddWithValue(iEnum.Current.ToString(), paramNameValue.GetValues(iEnum.Current.ToString()).GetValue(0).ToString().Trim());
                    }
                }

                if (withOutPara == true)
                {
                    // Add output parameters ... 
                    cmdSQLCommand.Parameters.Add("@o_ErrorMesg", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                }
                //  cmdSQLCommand.Parameters.Add("@o_ErrorMesg", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                // Open Database Connection ... 
                cnnConnection.Open();
                cmdSQLCommand.ExecuteNonQuery();

                // Read values of Output Parameters 
                if (withOutPara == true)
                {
                    // Read Values of Output Paramters and Stored into Property 
                    mErrorMsg = (string)(cmdSQLCommand.Parameters["@o_ErrorMesg"].Value);
                }
                else
                {
                    mErrorMsg = "";
                }

            }
            catch (Exception exception)
            {
                // Set the Exception ... 
                mException = exception;
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
                // Insert Exception
                BusinessLogic.Common ObjComm = new Account.BusinessLogic.Common();
                ObjComm.WriteExceptionLog(DateTime.Now, exception.Message, mModuleName);

            }
            finally
            {
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
            }

        }

        public void ExecuteDeleteSP(string spName, NameValueCollection paramNameValue, Boolean withOutPara, ref Exception mException, ref  string mErrorMsg, string mModuleName)
        {
            SqlCommand cmdSQLCommand = new SqlCommand();
            IEnumerator iEnum = default(IEnumerator);
            if (paramNameValue != null)
            {
                iEnum = paramNameValue.GetEnumerator();
            }

            // Initialize the Exception ... 
            this.Exception = null;
            this.ErrorMessage = "";

            try
            {
                // Prepare DataAdapter ... 
                cmdSQLCommand.Connection = cnnConnection;
                cmdSQLCommand.CommandText = spName;
                cmdSQLCommand.CommandType = CommandType.StoredProcedure;

                // Pass Parameters ... 
                if (paramNameValue != null)
                {
                    while (iEnum.MoveNext())
                    {
                        cmdSQLCommand.Parameters.AddWithValue(iEnum.Current.ToString(), paramNameValue.GetValues(iEnum.Current.ToString()).GetValue(0).ToString().Trim());
                    }
                }

                if (withOutPara == true)
                {
                    // Add output parameters ... 
                    cmdSQLCommand.Parameters.Add("@o_ErrorMesg", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                }

                // Open Database Connection ... 
                cnnConnection.Open();
                cmdSQLCommand.ExecuteNonQuery();

                // Read values of Output Parameters 
                if (withOutPara == true)
                {
                    // Read Values of Output Paramters and Stored into Property 
                    mErrorMsg = (string)(cmdSQLCommand.Parameters["@o_ErrorMesg"].Value);
                }
                else
                {
                    mErrorMsg = "";
                }

            }
            catch (Exception exception)
            {
                // Set the Exception ... 
                mException = exception;
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
                // Insert Exception
                //BusinessLogic.Common ObjComm = new Account.BusinessLogic.Common();
                //ObjComm.WriteExceptionLog(DateTime.Now, exception.Message, mModuleName);

            }
            finally
            {
                if (cnnConnection.State == ConnectionState.Open) cnnConnection.Close();
            }

        }

        public void Upload(string Table_Name, string Path)
        {
           
                //string adhoc = "";
                //adhoc = "sp_configure 'Ad Hoc Distributed Queries', 1";
                //SqlCommand cmd = new SqlCommand(adhoc, cnnConnection);
                //cnnConnection.Open();
                //cmd.ExecuteNonQuery();
                cnnConnection.Open();
                string drop = "";
                drop = "if exists( select * from sysobjects where name='" + Table_Name + "') drop table " + Table_Name;
                SqlCommand cmddrop = new SqlCommand(drop, cnnConnection);
                cmddrop.ExecuteNonQuery();

                //string Upload_String = "";
                //Upload_String = "SELECT * into " + Table_Name + " FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0','Excel 8.0;HDR=YES;Database=" + Path + "','select * from [Sheet1$]')";
                //SqlCommand cmdSQLCommand = new SqlCommand(Upload_String, cnnConnection);
                //int p = cmdSQLCommand.ExecuteNonQuery();
                //cnnConnection.Close();

                string Upload_String = "";
                Upload_String = "SELECT * into " + Table_Name + " FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0','Excel 8.0;HDR=YES;Database="+Path+"','select * from [Sheet1$]')";
                SqlCommand cmdSQLCommand = new SqlCommand(Upload_String, cnnConnection);
                int p = cmdSQLCommand.ExecuteNonQuery();
                cnnConnection.Close();

            
        }


        #endregion
    }
}
