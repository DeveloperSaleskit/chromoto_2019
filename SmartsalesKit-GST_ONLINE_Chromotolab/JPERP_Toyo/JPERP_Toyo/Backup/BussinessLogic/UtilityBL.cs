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

namespace Account.BusinessLogic
{
    class UtilityBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public UtilityBL()
        {
            this.Exception = null;
            this.ErrorMessage = "";
            mException = null;
            mErrorMsg = "";
        }
        //Created By Manoj Savalia on 04-09-2010
        public void GetBackUp(string spName, NameValueCollection paramNameValue, bool withOutPara, string mModuleName)
        {


            //Connection String for Local
            //  string SQLConnectionString = @"Data Source=Manoj;Initial Catalog=Account_Master;Integrated Security = true";
            Account.Common.Encryption Encry = new Account.Common.Encryption();
            Encry.DecryptBackUP();
            //Connection String for Development
            string SQLConnectionString = Account.Common.Encryption.ConstrBackUP;



            // SQL Connection Object 
            SqlConnection cnnConnection = new SqlConnection(SQLConnectionString);
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
                    this.ErrorMessage = (string)(cmdSQLCommand.Parameters["@o_ErrorMesg"].Value);
                }
                else
                {
                    this.ErrorMessage = "";
                }
            }
            catch (Exception exception)
            {
                // Set the Exception ... 
                this.Exception = exception;
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

    }
}
