using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Account.Properties;
using System.Net;
using System.IO;
using Account.Common;

namespace Account
{
    public partial class GUIBase : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region"Form Event..."

        public GUIBase()
        {
            InitializeComponent();
        }

        private void GUIBase_Load(object sender, EventArgs e)
        {

        }

        private void GUIBase_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SelectNextControl(ActiveControl, true, true, true, true);
            //}
        }

        #endregion

        #region "Constant Declartion ..."

        // Variable for Color Constants ... 
        public Color allInColor = Color.White;
        public Color txtOutColor = Color.FromArgb(221, 217, 195);
        public Color txtReadOnlyColor = Color.LightGray;
        public Color btnOutcolor = Color.Transparent;
        bool Active = false;
        int X = 0, Y = 0;
        #endregion

        #region "Variable Declaration ..."
        private Font NormalFont = new Font("Verdana", 8, FontStyle.Regular);
        #endregion

        #region "Private helper Methid ..."

        public void SetReadOnlyControls(Control ctlObject)
        {
            foreach (Control ctl in ctlObject.Controls)
            {
                if (ctl is TextBox)
                {
                    TextBox t = ((TextBox)ctl);
                    t.ReadOnly = true;
                    t.TabStop = false;
                    //t.BackColor = Color.White;
                }
                if (ctl is DataGridView)
                {
                    DataGridView t = ((DataGridView)ctl);
                    t.ReadOnly = true;
                    t.TabStop = false;
                }

                if (ctl is DateTimePicker)
                {
                    DateTimePicker t = ((DateTimePicker)ctl);
                    t.Enabled = false;
                    t.TabStop = false;
                }

                if (ctl is ComboBox)
                {
                    ComboBox t = ((ComboBox)ctl);
                    t.Enabled = false;
                    // t.TabStop = false;
                }

                if (ctl is Button)
                {
                    // ERROR: Not supported in C#: OnErrorStatement 
                    Button t = ((Button)ctl);
                    t.Enabled = false;
                    t.TabStop = false;
                }

                if (ctl is CheckBox)
                {
                    // ERROR: Not supported in C#: OnErrorStatement 
                    CheckBox t = ((CheckBox)ctl);
                    t.Enabled = false;
                    t.TabStop = false;
                }
                if (ctl is RadioButton)
                {
                    // ERROR: Not supported in C#: OnErrorStatement 
                    RadioButton t = ((RadioButton)ctl);
                    t.Enabled = false;
                    t.TabStop = false;
                }
                if (ctl is Label)
                {
                    Label t = ((Label)ctl);
                    if (t.Name.StartsWith("Err"))
                    {
                        t.Visible = false;
                    }
                    else if (t.Name == "lblrequired")
                    {
                        t.Visible = false;
                    }
                }
                if (ctl.Controls.Count > 0)
                {
                    SetReadOnlyControls(ctl);
                }
            }
        }

        public void SetControlsDefaults(Control ctlObject)
        {
            foreach (Control ctl in ctlObject.Controls)
            {
                if (ctl is GroupBox)
                {
                    GroupBox t = ((GroupBox)ctl);
                    t.ForeColor = Color.Black;
                    t.BackColor = Color.Transparent;

                    t.Font = new Font("Verdana", 8, FontStyle.Bold);
                }

                if (ctl is Label)
                {
                    Label t = ((Label)ctl);
                    t.Font = new Font("Verdana", 8, FontStyle.Regular);
                    t.BackColor = Color.Transparent;

                    if (t.Name.StartsWith("lblError"))
                    {
                        t.ForeColor = Color.Red;
                        t.BackColor = Color.Transparent;
                    }
                    //else if (t.Name == "this")
                    //{
                    //    t.ForeColor = Color.White;
                    //    t.BackColor = Color.FromArgb(148, 139, 84);
                    //    t.Font = new Font("Verdana", 9, FontStyle.Bold);
                    //    t.Width = ctlObject.Width - 2;
                    //}
                    else if (t.Name.StartsWith("lblrequired"))
                    {
                        t.ForeColor = Color.Red;
                        t.Font = new Font("Verdana", 8);
                    }
                    else if (t.Name.StartsWith("lblDelMsg"))
                    {
                        t.ForeColor = Color.Red;
                        t.Font = new Font("Verdana", 8);
                    }
                    else if (t.Name.StartsWith("Err"))
                    {
                        t.ForeColor = Color.Red;
                        t.Font = new Font("Verdana", 8);
                    }
                    else
                    {
                        t.ForeColor = Color.Black;
                    }
                }

                if (ctl is CheckBox)
                {
                    CheckBox t = ((CheckBox)ctl);
                    t.BackColor = Color.Transparent;
                    t.ForeColor = Color.Black;// Color.FromArgb(166, 156, 98);
                    t.Font = new Font("Verdana", 8);
                }

                if (ctl is TextBox)
                {
                    TextBox t = ((TextBox)ctl);
                    t.Font = NormalFont;
                    //t.CharacterCasing = CharacterCasing.Upper;
                    t.CharacterCasing = CharacterCasing.Normal;
                    //  t.BackColor = Color.FromArgb(221, 217, 195);
                    t.BackColor = Color.White;
                    if (t.ReadOnly == true)
                    {
                        t.BackColor = Color.LightGray;
                    }
                }

                if (ctl is Button)
                {
                    // ERROR: Not supported in C#: OnErrorStatement 
                    Button t = ((Button)ctl);
                    t.Height = 24;
                    t.Cursor = Cursors.Hand;
                    // t.TextAlign = ContentAlignment.MiddleRight;
                    t.TextImageRelation = TextImageRelation.ImageBeforeText;
                    t.ImageAlign = ContentAlignment.MiddleLeft;
                    t.BackgroundImageLayout = ImageLayout.Stretch;
                    t.ForeColor = Color.Black;
                    t.Font = NormalFont;
                    if (t.Name.StartsWith("btnMinimize"))
                    {
                        t.FlatStyle = FlatStyle.Flat;
                    }
                    else if (t.Name.StartsWith("btnClose") || t.Name.StartsWith("btnclose") || t.Name.StartsWith("btnCancel"))
                    {
                        t.BackColor = Color.FromArgb(255, 192, 0);
                        t.FlatStyle = FlatStyle.Popup;
                        //t.BackgroundImage = Resources.On_Focus_Button;
                    }
                    else if (t.Name.StartsWith("btnfilter") || t.Name.StartsWith("btnFilter") || t.Name.StartsWith("btnFILTER"))
                    {
                        t.BackColor = Color.FromArgb(255, 192, 0);
                        t.FlatStyle = FlatStyle.Popup;
                        //t.BackgroundImage = Resources.On_Focus_Button;
                    }
                    else if (t.Name.StartsWith("btnRegenrate"))
                    {
                        t.BackgroundImage = Resources.stufftheme4;
                        t.Text = "";
                        t.Width = 24;
                        t.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        //  t.BackColor = Color.FromArgb(148, 139, 84);
                        // t.BackColor = Color.FromArgb(197, 190, 151);
                        t.BackColor = Color.FromArgb(213, 208, 181);
                        t.FlatStyle = FlatStyle.Popup;
                    }

                    //Set Images
                    if (t.Name.StartsWith("btnNew"))
                    {
                        t.Image = Properties.Resources.btnAdd_Image;
                    }
                    else if (t.Name.StartsWith("btnEdit"))
                    {
                        t.Image = Properties.Resources.btnEdit_Image;
                    }
                    else if (t.Name.StartsWith("btnDelete"))
                    {
                        t.Image = Properties.Resources.btnDelete_Image;
                    }
                    else if (t.Name.StartsWith("btnClose") || t.Name.StartsWith("btnclose") || t.Name.StartsWith("btnCancel"))
                    {
                        t.Image = Properties.Resources.btnCancel_Image;
                    }
                    else if (t.Name.StartsWith("btnApply"))
                    {
                        t.Image = Properties.Resources.btnApply_Image;
                    }
                    else if (t.Name.StartsWith("btnClear"))
                    {
                        t.Image = Properties.Resources.btnclear_Image;
                    }
                    else if (t.Name.StartsWith("btnSaveContinue"))
                    {
                        t.Image = Properties.Resources.btnSaveNew_Image;
                    }
                    else if (t.Name.StartsWith("btnSaveExit"))
                    {
                        t.Image = Properties.Resources.btnSaveExit_Image;
                    }
                    else if (t.Name.StartsWith("btnViewReport"))
                    {
                        t.Image = Properties.Resources.rtg_btn_print;
                    }

                }

                if (ctl is RadioButton)
                {
                    // ERROR: Not supported in C#: OnErrorStatement 
                    RadioButton t = ((RadioButton)ctl);
                    t.Height = 26;
                    // ctl.Cursor = Cursors.Hand 
                    t.ForeColor = Color.Black;
                    t.TextAlign = ContentAlignment.MiddleCenter;
                    t.FlatStyle = FlatStyle.Standard;
                }

                if (ctl is DateTimePicker)
                {
                    DateTimePicker t = ((DateTimePicker)ctl);
                    t.Font = new Font(NormalFont, FontStyle.Regular);
                    t.Format = DateTimePickerFormat.Custom;
                    t.CustomFormat = "dd/MM/yyyy";
                    //  t.CalendarTitleBackColor = Color.FromArgb(238, 236, 225);
                    t.CalendarTitleForeColor = Color.Black;
                    //   t.CalendarMonthBackground = Color.FromArgb(148, 139, 84);
                    t.CalendarTrailingForeColor = Color.Red;

                }

                if (ctl is DataGridView)
                {
                    DataGridView t = ((DataGridView)ctl);
                    t.ForeColor = Color.Black;
                    t.BackgroundColor = Color.White;
                    t.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    t.StandardTab = true;
                    t.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    t.AllowUserToAddRows = false;
                    t.AllowUserToDeleteRows = false;
                    t.MultiSelect = true;
                    t.ReadOnly = true;
                    t.RowHeadersWidth = 25;
                    t.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    t.ColumnHeadersDefaultCellStyle.Font = NormalFont;
                    t.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
                    t.RowsDefaultCellStyle.Font = NormalFont;
                    t.RowsDefaultCellStyle.BackColor = Color.FromArgb(253, 253, 253);
                    t.ColumnHeadersDefaultCellStyle.Font = NormalFont;
                    t.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    t.RowsDefaultCellStyle.Font = NormalFont;
                    t.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
                    t.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 225);    // Color.FromArgb(238, 236, 225);
                }

                if (ctl is ComboBox)
                {
                    ComboBox t = ((ComboBox)ctl);
                    t.DropDownStyle = ComboBoxStyle.DropDownList;
                    t.Font = NormalFont;
                    // t.BackColor = Color.FromArgb(238, 236, 225);
                    t.BackColor = Color.White;
                }

                if (ctl is ToolStrip)
                {
                    ToolStrip t = ((ToolStrip)ctl);
                    t.Font = new Font("Verdana", 8, FontStyle.Regular);
                    if (t.Name == "MsgBar")
                    {
                        t.TabStop = false;
                    }
                    else
                    {
                        t.TabStop = true;
                        t.Tag = "Click to show report;";
                        if (t.Items[0].Text.StartsWith("Reports"))
                        {
                            //  t.Items[0].BackColor = Color.FromArgb(238, 236, 225);
                            t.Items[0].BackColor = Color.FromArgb(230, 230, 225);

                            ToolStripDropDownButton t1 = ((ToolStripDropDownButton)t.Items[0]);
                            t1.Font = new Font("Verdana", 8, FontStyle.Regular);
                            t1.Dock = DockStyle.Top;
                            for (int i = 0; i < t1.DropDownItems.Count; i++)
                            {
                                //t1.DropDownItems[i].BackColor = Color.FromArgb(238, 236, 225);
                                t1.DropDownItems[i].BackColor = Color.FromArgb(230, 230, 225);
                                t1.DropDownItems[i].Font = new Font("Verdana", 8, FontStyle.Regular);
                            }
                        }
                    }
                }
                if (ctl.Controls.Count > 0)
                {
                    SetControlsDefaults(ctl);
                }
            }
        }

        // Procedure to Change the BackColor of Control on entering/leaving into the Control ... 
        public void ChangeColor(Control ctl, int Mode)
        {
            try
            {
                if (ctl is TextBox)
                {
                    switch (Mode)
                    {
                        case 1:
                            ((TextBox)ctl).SelectAll();
                            ctl.BackColor = allInColor;
                            break;
                        case 2:
                            if (((TextBox)ctl).ReadOnly == true)
                            {
                                ctl.BackColor = txtReadOnlyColor;
                            }
                            else
                            {
                                // ctl.BackColor = Color.FromArgb(221, 217, 195);
                                ctl.BackColor = Color.White;
                            }

                            break;
                    }
                }
                else if (ctl is Button)
                {
                    switch (Mode)
                    {
                        case 1:
                            ctl.BackColor = allInColor;
                            if (ctl.Name.StartsWith("btnMinimize"))
                            {
                                ctl.BackColor = Color.FromArgb(238, 236, 225);
                            }
                            else if (ctl.Name.StartsWith("btnClose") || ctl.Name.StartsWith("btnclose") || ctl.Name.StartsWith("btnCancel"))
                            {
                                ctl.BackColor = Color.FromArgb(255, 192, 0);
                            }
                            else
                            {
                                //  ctl.BackColor = Color.FromArgb(197, 190, 151);
                                ctl.BackColor = Color.FromArgb(200, 200, 200);

                            }
                            ctl.BackgroundImageLayout = ImageLayout.Stretch;
                            break;
                        case 2:
                            ctl.BackColor = Color.FromArgb(76, 173, 224);
                            if (ctl.Name.StartsWith("btnMinimize"))
                            {
                                ctl.BackColor = Color.FromArgb(238, 236, 225);
                            }
                            else if (ctl.Name.StartsWith("btnClose") || ctl.Name.StartsWith("btnclose") || ctl.Name.StartsWith("btnCancel"))
                            {
                                ctl.BackColor = Color.FromArgb(255, 192, 0);
                            }
                            else
                            {
                                // ctl.BackColor = Color.FromArgb(148, 139, 84);
                                //ctl.BackColor = Color.FromArgb(64, 64, 64);
                                ctl.BackColor = Color.FromArgb(213, 208, 181);
                                ctl.ForeColor = Color.Black;
                            }
                            break;
                    }
                }
                else if (ctl is ComboBox)
                {
                    switch (Mode)
                    {
                        case 1:
                            //   ctl.BackColor = allInColor;
                            ctl.BackColor = Color.White; //Color.FromArgb(238, 236, 225);
                            break;
                        case 2:
                            //  ctl.BackColor = txtOutColor;
                            ctl.BackColor = Color.White;// Color.FromArgb(238, 236, 225);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Paint Grid Color
        public static void GridDrawCustomHeaderColumns(DataGridView dgv, DataGridViewCellPaintingEventArgs e, Image img)
        {
            Graphics gr = e.Graphics;
            gr.FillRectangle(new SolidBrush(Color.FromArgb(238, 236, 225)), e.CellBounds);
            if (img != null)
            {
                gr.DrawImage(img, e.CellBounds.X, e.CellBounds.Y, e.ClipBounds.Width, e.CellBounds.Height);
            }
            e.PaintContent(e.CellBounds);
            e.Handled = true;
        }

        public void PaintGridRowAndColumns(DataGridView grd, object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                GridDrawCustomHeaderColumns(grd, e, Resources.Button_Gray_Stripe_01_050);
            }
            if (e.ColumnIndex == -1)
            {
                GridDrawCustomHeaderColumns(grd, e, Resources.Button_Gray_Stripe_01_050);
            }
        }

        #endregion

        #region "GotFocus/LostFocus Events ..."

        public void GotFocusEvent(object sender, System.EventArgs e)
        {
            string tagValue = Convert.ToString(((Control)sender).Tag);
            lblMsg.Text = tagValue.Substring(0, tagValue.IndexOf(";"));
            ChangeColor((Control)sender, 1);
        }

        public void LostFocusEvent(object sender, System.EventArgs e)
        {
            ChangeColor((Control)sender, 2);
        }

        #endregion

        #region "Add EventHandlers for Controls ..."

        public void AddHandlers(Control ctlObject)
        {

            foreach (Control ctrl in ctlObject.Controls)
            {
                if (ctrl is TextBox | ctrl is Button | ctrl is DateTimePicker | ctrl is DataGridView | ctrl is CheckBox | ctrl is RadioButton | ctrl is ComboBox | ctrl is ListBox | ctrl is CheckedListBox | ctrl is ToolStrip | ctrl is TreeView | ctrl is TabControl)
                {
                    ctrl.GotFocus += GotFocusEvent;
                    ctrl.LostFocus += LostFocusEvent;
                }

                if (ctrl.Controls.Count > 0)
                {
                    AddHandlers((Control)ctrl);
                }
            }
        }

        #endregion

        #region "Extra Function....."
        public string PrepareFilterString(string FilterString)
        {
            // Replace ' with ''
            FilterString = FilterString.Replace("'", "''");

            //Remove [
            FilterString = FilterString.Replace("[", "[[]");

            // Remove %
            FilterString = FilterString.Replace("%", "[%]");

            // Remove \
            //FilterString = FilterString.Replace("\\", "");

            // Remove *
            FilterString = FilterString.Replace("*", "[*]");

            // Remove +
            //FilterString = FilterString.Replace("+", "");

            // Remove _
            FilterString = FilterString.Replace("_", "[_]");

            //Remove $
            //FilterString = FilterString.Replace("$", "");

            //Remove ]
            //FilterString = FilterString.Replace("]", "");

            return FilterString;
        }
        #endregion

        #region "Form Title Event..."

        private void this_MouseDown(object sender, MouseEventArgs e)
        {
            Active = true;
            X = e.X;
            Y = e.Y;
        }

        private void this_MouseMove(object sender, MouseEventArgs e)
        {
            if (Active)
            {
                this.Location = new Point(this.Left + e.X - X, this.Top + e.Y - Y);
                Refresh();
            }
        }

        private void this_MouseUp(object sender, MouseEventArgs e)
        {
            Active = false;
        }

        #endregion

        public void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + CurrentCompany.ServerIP + CurrentCompany.FTPReportPath + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + CurrentCompany.ServerIP + "/" + CurrentCompany.FTPReportPath + "/" + fileInf.Name));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(CurrentCompany.UserName, CurrentCompany.Password);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        public void Download(string filePath, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + CurrentCompany.ServerIP + "/" + CurrentCompany.FTPReportPath + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UsePassive = false;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(CurrentCompany.UserName, CurrentCompany.Password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
