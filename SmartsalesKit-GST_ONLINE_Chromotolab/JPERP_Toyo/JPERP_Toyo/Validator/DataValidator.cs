using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using Account.Common;

namespace Account.Validator
{
    class DataValidator
    {
        public static string lblFormatMessage = "Enter number format should be in ";

        //public static bool IsValid(ref Object obj)
        public static bool IsValid(Control ControlColl)
        {
            //Control ctl = default(Control);
            string tagValue = "";
             
            for (int i = 0; i < ControlColl.Controls.Count; i++) // foreach (Control ctl in obj)
            {
                Control ctl = ControlColl.Controls[i];
                if (ctl is TextBox)
                {
                    TextBox tmpTextBox = (TextBox)ctl;

                    // Check for Must Enter fields ... 
                    if (tmpTextBox.Tag.ToString().IndexOf("@") > 0)
                    {
                        if (string.IsNullOrEmpty(tmpTextBox.Text.Trim()))
                         {
                            tagValue = tmpTextBox.Tag.ToString().Substring(0, tmpTextBox.Tag.ToString().IndexOf(";"));

                            // Search for lblErrMessage on the form ... 
                            if (ctl.FindForm().Controls.Find("lblErrorMessage", true).GetLength(0) > 0)
                            {
                                // Display Error on lblErrMessage ... 
                                ((Label)ctl.FindForm().Controls.Find("lblErrorMessage", true)[0]).Text = tagValue;
                            }
                            else
                            {
                                // Display Error on MessageBox ... 
                                MessageBox.Show(tagValue, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            ctl.Focus();
                            return false;
                        }
                    }

                    // Check for Decimal Validation ... 
                    if (tmpTextBox.Tag.ToString().IndexOf("#D") > 0)
                    {
                        if (!string.IsNullOrEmpty(tmpTextBox.Text.Trim()))
                        {
                            double temp;
                            if (double.TryParse(tmpTextBox.Text.Trim(), out temp))
                            {
                                if (temp <= 0)
                                {
                                    tagValue = tmpTextBox.Tag.ToString().Substring(0, tmpTextBox.Tag.ToString().IndexOf(";"));

                                    // Search for lblErrMessage on the form ... 
                                    if (ctl.FindForm().Controls.Find("lblErrorMessage", true).GetLength(0) > 0)
                                    {
                                        // Display Error on lblErrMessage ... 
                                        ((Label)ctl.FindForm().Controls.Find("lblErrorMessage", true)[0]).Text = tagValue;
                                    }
                                    else
                                    {
                                        // Display Error on MessageBox ... 
                                        MessageBox.Show(tagValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    ctl.Focus();
                                    return false;
                                }
                            }
                        }
                    }

                    // Check for Numeric Validation ... 
                    if (tmpTextBox.Tag.ToString().IndexOf("#N") > 0)
                    {
                        if (!string.IsNullOrEmpty(tmpTextBox.Text.Trim()))
                        {
                            int temp;
                            if (int.TryParse(tmpTextBox.Text.Trim(), out temp))
                            {
                                if (temp <= 0)
                                {
                                    tagValue = tmpTextBox.Tag.ToString().Substring(0, tmpTextBox.Tag.ToString().IndexOf(";"));

                                    if (ctl.FindForm().Controls.Find("lblErrorMessage", true).GetLength(0) > 0)
                                    {
                                        // Display Error on lblErrMessage ... 
                                        ((Label)ctl.FindForm().Controls.Find("lblErrorMessage", true)[0]).Text = tagValue;
                                    }
                                    else
                                    {
                                        // Display Error on MessageBox ... 
                                        MessageBox.Show(tagValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    ctl.Focus();
                                    return false;
                                }
                            }

                        }
                        else
                        {
                            tagValue = tmpTextBox.Tag.ToString().Substring(0, tmpTextBox.Tag.ToString().IndexOf(";"));
                            if (ctl.FindForm().Controls.Find("lblErrorMessage", true).GetLength(0) > 0)
                            {
                                // Display Error on lblErrMessage ... 
                                ((Label)ctl.FindForm().Controls.Find("lblErrorMessage", true)[0]).Text = tagValue;
                            }
                            else
                            {
                                // Display Error on MessageBox ... 
                                MessageBox.Show(tagValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            ctl.Focus();
                            return false;
                        }
                    }
                }
                else if (ctl is MaskedTextBox)
                {
                    MaskedTextBox tmpTextBox = (MaskedTextBox)ctl;

                    // Check for Must Enter fields ... 
                    if (tmpTextBox.Tag.ToString().IndexOf("@") > 0)
                    {
                        if (tmpTextBox.Text.Trim() == ":")
                        {
                            tagValue = tmpTextBox.Tag.ToString().Substring(0, tmpTextBox.Tag.ToString().IndexOf(";"));

                            // Search for lblErrMessage on the form ... 
                            if (ctl.FindForm().Controls.Find("lblErrorMessage", true).GetLength(0) > 0)
                            {
                                // Display Error on lblErrMessage ... 
                                ((Label)ctl.FindForm().Controls.Find("lblErrorMessage", true)[0]).Text = tagValue;
                            }
                            else
                            {
                                // Display Error on MessageBox ... 
                                MessageBox.Show(tagValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            ctl.Focus();
                            return false;
                        }
                    }
                }
                else if (ctl is ComboBox)
                {

                    ComboBox tmpCombo = (ComboBox)ctl;
                    if (tmpCombo.Tag.ToString().IndexOf("@") > 0)
                    {

                        if (tmpCombo.SelectedIndex == 0 & (tmpCombo.Text.ToUpper() == "--ALL--" | tmpCombo.Text.ToUpper() == "--SELECT--"))
                        {
                            tagValue = tmpCombo.Tag.ToString().Substring(0, tmpCombo.Tag.ToString().IndexOf(";"));

                            // Search for lblErrMessage on the form ... 
                            if (ctl.FindForm().Controls.Find("lblErrorMessage", true).GetLength(0) > 0)
                            {
                                // Display Error on lblErrMessage ... 
                                ((Label)ctl.FindForm().Controls.Find("lblErrorMessage", true)[0]).Text = tagValue;
                            }
                            else
                            {
                                // Display Error on MessageBox ... 
                                MessageBox.Show(tagValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            ctl.Focus();
                            return false;
                        }
                    }
                }
                // TODO: Add Contion for Other Controls ... 

                if (ctl.Controls.Count > 0)
                {
                    if (!IsValid(ctl))
                    {
                        return false;
                    }
                }
            }

            if (ControlColl.Controls.Find("lblErrorMessage", true).GetLength(0) > 0)
            {
                ControlColl.Controls.Find("lblErrorMessage", true)[0].Text = "No error";
            }


            return true;
        }

        // Set Decimal On Leave ... 
        public static void SetDecimalOnLeave(System.Object sender)
        {
            ((TextBox)sender).Text = String.Format("{0:0.00}", Convert.ToDecimal(((TextBox)sender).Text.Trim()));
        }

        // Set Integer on Leave ...
        public static void SetIntegerOnLeave(System.Object sender)
        {
            ((TextBox)sender).Text = String.Format("{0:0}", Convert.ToDecimal(((TextBox)sender).Text.Trim()));
        }

        // Allow Only NUmeric
        public static void AllowOnlyNumeric(KeyPressEventArgs e, string AllowedChar)
        {
            string[] strAllowed = AllowedChar.Split(',');
            IEnumerator ienum = strAllowed.GetEnumerator();
            while (ienum.MoveNext())
            {
                if ((e.KeyChar.ToString().ToLower() == ienum.Current.ToString().ToLower()))
                {
                    return;
                }
            }
            int ascii = e.KeyChar;
            if (!(DataValidator.IsNumeric(e.KeyChar.ToString()) || (ascii == 8)))
            {
                e.Handled = true;
            }
        }

       // Validate fields that accepts Numbers and Selected Characters ...
       //Code Commented by Roshni
       // public static void AllowOnlyNumeric(System.Windows.Forms.KeyPressEventArgs e) 
       // {
            //int temp;
            //if (!(int.TryParse(Convert.ToString(e.KeyChar), out temp)))
            //{
            //    if (temp <= 0)
            //    {
            //        e.Handled = true;
            //    }
            //}

       // }

        // Validate fields that accepts Numbers and Selected Characters ... 
        public static bool IsNumeric(string anyString)
        {
            if (anyString == null)
            {
                anyString = "";
            }
            if (anyString.Length > 0)
            {
                double dummyOut = new double();
                System.Globalization.CultureInfo cultureInfo =
                    new System.Globalization.CultureInfo("en-US", true);

                return Double.TryParse(anyString,
                      System.Globalization.NumberStyles.Any,
                    cultureInfo.NumberFormat, out dummyOut);
            }
            else
            {
                return false;
            }
        }

        //validation for Date
        public static bool IsDate(string anyString)
        {
            if (anyString == null)
            {
                anyString = "";
            }
            if (anyString.Length > 0)
            {
                DateTime dummyDate;
                try
                {
                    dummyDate = DateTime.Parse(anyString);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
         
        //validation for Character, No Special Character allowed
        public static void AllowOnlyCharacter(int ascii, KeyPressEventArgs e)
        {
            if (((ascii == 37) || ((ascii == 39) || ((ascii == 91) || ((ascii == 93) || (ascii == 42))))))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        //Hear to set for Conversion of DBNull or Nothing or any Value from Object to String...
        public static string SetString(System.Object Value)
        {
            DateTime TempDate;
            int Temp;
            string str = "";

            if (object.ReferenceEquals(Value, System.DBNull.Value))
            {
                return str;
            }
            else if (Value == null)
            {
                return str;
            }

            else if (int.TryParse(Convert.ToString(Value), out Temp))
            {
                str = Value.ToString();
            }

            else if (DateTime.TryParse(Convert.ToString(Value), out TempDate))
            {
                str = Value.ToString();
            }
            else
            {
                str = Value.ToString();
            }
            return str;
        }

        //Hear to set for Conversion of DBNull or Nothing or any Value from Object to Decimal... 
        public static string SetDecimal(ref System.Object Value)
        {
            decimal str = 0;
            int Temp;
            if (object.ReferenceEquals(Value, System.DBNull.Value))
            {
                return Convert.ToString(str);
            }
            else if (Value == null)
            {
                return Convert.ToString(str);
            }

            else if (int.TryParse(Convert.ToString(Value), out Temp))
            {
                str = Convert.ToDecimal(Value);
            }
            return Convert.ToString(str);
        }

        //Set Default Date
        public static void SetDefaultDate(DateTimePicker dtp, Nullable<DateTime> StartDate, Nullable<DateTime> EndDate)
        {
            if (StartDate != null && EndDate != null)
            {
                dtp.MinDate = StartDate.Value;
                dtp.MaxDate = EndDate.Value;

                if (! (dtp.Value >= StartDate.Value && dtp.Value <= EndDate.Value))
                {
                  dtp.Value = StartDate.Value;
                }                
            } 
            else
            {
                dtp.MinDate = CurrentUser.FYStartDate;
                dtp.MaxDate = CurrentUser.FYEndDate;

                if (DateTime.Now.Date >= CurrentUser.FYStartDate && DateTime.Now.Date <= CurrentUser.FYEndDate)
                {
                    dtp.Value = DateTime.Now.Date;
                }
                else
                {
                    dtp.Value = CurrentUser.FYStartDate;
                }
            }
        }
    }
}
