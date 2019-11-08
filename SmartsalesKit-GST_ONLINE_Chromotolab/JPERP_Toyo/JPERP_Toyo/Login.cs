using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Account.BusinessLogic;
using Account.Common;
using Utill.Common;
using System.Net.NetworkInformation;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;
using System.Globalization;

namespace Account
{
    public partial class Login : Form
    {
        #region "Variable Declaration...."


        int _CompId = 0;
        CommonListBL objList = new CommonListBL();

        #endregion

        public static int Tmp = 0;

        #region "Form Event...."

        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                ShowInTaskbar = true;
                lblVersion.Text = "Version: ".ToString() + Application.ProductVersion.Trim();
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    txtUserName.Text = "sa";
                    txtPassword.Text = "admin";
                }
                txtUserName.Focus();

                //frmMainMDI obj = new frmMainMDI();
                //obj.Close();
            }
            catch (Exception exc)
            {
                ExceptionLogger.writeException("User SignIn", exc.StackTrace);
            }
        }

        #endregion

        #region "Button Event...."

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            CompanyFYNSplash cfs = new CompanyFYNSplash();
            cfs.ShowDialog();

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (Validator.DataValidator.IsValid(this))
                {
                          // Console.WriteLine("'d' standard format string:");
                          //foreach (var customString in DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns('d'))
                          //Console.WriteLine("   {0}", customString);

                   // string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                 

                     //Check Date format
                     // if (System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern == "dd/MM/yyyy")
                    //{
                   
                        DataSet dsSignIN = new DataSet();
                        AutheticationBL objAuthentication = new AutheticationBL();


                        Common.Encryption Encry = new Encryption();
                        Encry.Decrypt();
                        _CompId = CurrentCompany.CompId;
                     
                        dsSignIN = objAuthentication.SignIN(_CompId, txtUserName.Text, txtPassword.Text, 1, lblVersion.Text, "usp_SignIn");
                        //if (objAuthentication.Exception == null)
                        //{
                        //    if (objAuthentication.ErrorMessage == "")
                        //    {
                        //        CurrentUser.UserID = Convert.ToInt32(dsSignIN.Tables[0].Rows[0]["UserID"]);
                        //        string Login = objAuthentication.GetLogIn();
                        //        if (Login.Equals("0") || Login == "")
                        //        {
                        //            objAuthentication.UpdateLogIn();
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("This User is already LogIn somewhere.", "Exception",
                        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("UserName or Password is incorrect.", "Warning",
                        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        return;
                        //    }
                        //}
                        if (objAuthentication.Exception == null)
                        {
                            if (objAuthentication.ErrorMessage == "")
                            {
                                CurrentUser.CompId = Convert.ToInt32(dsSignIN.Tables[0].Rows[0]["CompId"]);
                                CurrentUser.UserID = Convert.ToInt32(dsSignIN.Tables[0].Rows[0]["UserID"]);
                                CurrentUser.empId = Convert.ToInt32(dsSignIN.Tables[0].Rows[0]["EmpId"]);
                                CurrentUser.PhonNo = dsSignIN.Tables[0].Rows[0]["PhoneNo"].ToString();
                                CurrentUser.Address = dsSignIN.Tables[0].Rows[0]["Address"].ToString();
                                CurrentUser.EmaiId = dsSignIN.Tables[0].Rows[0]["Email"].ToString();
                                CurrentUser.UserName = dsSignIN.Tables[0].Rows[0]["UserName"].ToString();
                                CurrentUser.DispUserName = dsSignIN.Tables[0].Rows[0]["DispName"].ToString();
                                CurrentUser.FYStartDate = Convert.ToDateTime(dsSignIN.Tables[0].Rows[0]["StartDate"].ToString());
                                CurrentUser.FYEndDate = Convert.ToDateTime(dsSignIN.Tables[0].Rows[0]["EndDate"].ToString());
                                CurrentUser.FYID = 1;

                                // CurrentUser.ImagePath = @"E:\Account\Images\Board\";
                                //CurrentUser.ReportPath = System.IO.Directory.GetCurrentDirectory().ToString() + "/Reports/";

                                //CurrentUser.ImagePath = @"D:\Account\Images\";
                                //CurrentUser.ReportPath = @"D:\Account\Reports\";

                                DataTable dtPrivilegeList = new DataTable();
                                dtPrivilegeList = objAuthentication.GetUserWisePrivilegeList((int)CurrentUser.UserID);

                                CurrentUser.PrivilegeStr = dtPrivilegeList.Rows[0]["PrivilegeID"].ToString();

                                PrepareCurrentCompany();
                                this.Dispose(false);




                                frmMainMDI _defMDIMain = new frmMainMDI();
                                _defMDIMain.Show();

                            }
                            else
                            {
                                Tmp = Tmp + 1;
                                if (Tmp == 3)
                                {
                                    this.Dispose();
                                    Application.Exit();
                                }
                                MessageBox.Show(objAuthentication.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show(objAuthentication.Exception.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //else
                    //{

                    //    MessageBox.Show("Your computers regional setting has been changed." + "\n" + "\n" + "Change it back to UK Format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
              //  }
            }
            catch (Exception exc)
            {
                ExceptionLogger.writeException("User SignIn", exc.StackTrace);
            }
        }



        #endregion

        #region "Private Method..."

        private void PrepareCurrentCompany()
        {
            AutheticationBL objAuthentication = new AutheticationBL();
            //DataTable dtCompInfo = objAuthentication.GetCompanyInfo();

            NameValueCollection para1 = new NameValueCollection();
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataTable dtCompInfo = objList.ListOfRecord("usp_CompanyInfo_Select", para1, "Login - CompanyInfo");

            if (objAuthentication.Exception == null)
            {
                if (objAuthentication.ErrorMessage == "")
                {
                    if (dtCompInfo.Rows.Count > 0)
                    {
                        CurrentCompany.CompanyCode = dtCompInfo.Rows[0]["CompanyCode"].ToString();
                        CurrentCompany.CompanyName = dtCompInfo.Rows[0]["CompanyName"].ToString();
                        CurrentCompany.BusinessLine = dtCompInfo.Rows[0]["BusinessLine"].ToString();
                        CurrentCompany.Address1 = dtCompInfo.Rows[0]["Address1"].ToString();
                        CurrentCompany.Address2 = dtCompInfo.Rows[0]["Address2"].ToString();
                        CurrentCompany.State = dtCompInfo.Rows[0]["State"].ToString();
                        CurrentCompany.City = dtCompInfo.Rows[0]["CityName"].ToString();
                        CurrentCompany.Pincode = dtCompInfo.Rows[0]["Pincode"].ToString();
                        CurrentCompany.Phone1 = dtCompInfo.Rows[0]["Phone1"].ToString();
                        CurrentCompany.Phone2 = dtCompInfo.Rows[0]["Phone2"].ToString();
                        CurrentCompany.Mobile = dtCompInfo.Rows[0]["Mobile"].ToString();
                        CurrentCompany.Fax = dtCompInfo.Rows[0]["Fax"].ToString();
                        CurrentCompany.Email = dtCompInfo.Rows[0]["Email"].ToString();
                        CurrentUser.ReportPath = dtCompInfo.Rows[0]["ReportPath"].ToString();
                        CurrentUser.DocumentPath = dtCompInfo.Rows[0]["DocPath"].ToString();
                        CurrentCompany.Con_Email = dtCompInfo.Rows[0]["Con_Email"].ToString();
                        CurrentCompany.Con_Password = dtCompInfo.Rows[0]["Con_Password"].ToString();
                        CurrentCompany.Host = dtCompInfo.Rows[0]["Host"].ToString();
                        CurrentCompany.ServerIP = dtCompInfo.Rows[0]["ServerIP"].ToString();
                        CurrentCompany.UserName = dtCompInfo.Rows[0]["UserName"].ToString();
                        CurrentCompany.Password = dtCompInfo.Rows[0]["Password"].ToString();

                        CurrentCompany.FTPReportPath = dtCompInfo.Rows[0]["FTPReportPath"].ToString();


                        if (dtCompInfo.Rows[0]["ssl"] == null)
                        {
                            CurrentCompany.ssl = 0;
                        }

                        CurrentCompany.ssl = Convert.ToInt16(dtCompInfo.Rows[0]["ssl"].ToString());
                        CurrentCompany.Port = Convert.ToInt16(dtCompInfo.Rows[0]["Port"].ToString());
                        CurrentCompany.Logo = dtCompInfo.Rows[0]["Logo"].ToString();
                        CurrentCompany.Header = dtCompInfo.Rows[0]["Header"].ToString();
                        CurrentCompany.Sign = dtCompInfo.Rows[0]["Sign"].ToString();
                        CurrentCompany.Footer = dtCompInfo.Rows[0]["Footer"].ToString();
                        CurrentCompany.Name1 = dtCompInfo.Rows[0]["Name1"].ToString();
                        CurrentCompany.Name2 = dtCompInfo.Rows[0]["Name2"].ToString();
                        CurrentCompany.Name3 = dtCompInfo.Rows[0]["Name3"].ToString();
                        CurrentCompany.Name4 = dtCompInfo.Rows[0]["Name4"].ToString();
                        CurrentCompany.Name5 = dtCompInfo.Rows[0]["Name5"].ToString();
                        CurrentCompany.Name6 = dtCompInfo.Rows[0]["Name6"].ToString();
                        CurrentCompany.Value1 = dtCompInfo.Rows[0]["Value1"].ToString();
                        CurrentCompany.Value2 = dtCompInfo.Rows[0]["Value2"].ToString();
                        CurrentCompany.Value3 = dtCompInfo.Rows[0]["Value3"].ToString();
                        CurrentCompany.Value4 = dtCompInfo.Rows[0]["Value4"].ToString();
                        CurrentCompany.Value5 = dtCompInfo.Rows[0]["Value5"].ToString();
                        CurrentCompany.Value6 = dtCompInfo.Rows[0]["Value6"].ToString();
                        CurrentCompany.Com_Profile = dtCompInfo.Rows[0]["Com_Profile"].ToString();
                        CurrentCompany.DBName = dtCompInfo.Rows[0]["BackupDBName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show(objAuthentication.ErrorMessage);
                }
            }
            else
            {
                MessageBox.Show(objAuthentication.Exception.Message.ToString());
            }
            //CurrentCompany.CompanyCode = "Trisha";
            //CurrentCompany.CompanyName = "Trisha Teleservices";
            //CurrentCompany.BusinessLine = "";
            //CurrentCompany.Address1 = "F-64, City Mall, Nr. Kasumbi Plywood Center,";
            //CurrentCompany.Address2 = "Navhivan Mill Compound";
            //CurrentCompany.City = "Kalol(N.G.)";
            //CurrentCompany.Pincode = "382721";
            //CurrentCompany.Phone1 = "9825126378";
            //CurrentCompany.Phone2 = "";
            //CurrentCompany.Mobile = "9228008882";
            //CurrentCompany.Fax = "";
            //CurrentCompany.Email = "";
            //CurrentCompany.Web = "";
            //CurrentCompany.PAN = "";
            //CurrentCompany.RegNo = "";
            //CurrentCompany.CST = "";
            //CurrentCompany.ECC = "";
            //CurrentCompany.TIN = "";
            //CurrentCompany.State = "";
            //CurrentCompany.RegAddress1 = "";
            //CurrentCompany.RegAddress2 = "";
            //CurrentCompany.RegCity = "";
            //CurrentCompany.RegFax = "";
            //CurrentCompany.RegPhone = "";
        }

        #endregion

        #region "Textbox Event"

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            //            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        #endregion


    }
}
