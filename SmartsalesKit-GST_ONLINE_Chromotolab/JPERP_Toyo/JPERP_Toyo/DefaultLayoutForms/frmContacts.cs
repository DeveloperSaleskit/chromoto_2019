using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using Account.Validator;

namespace Account.DefaultLayout
{
    public partial class frmContacts : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region "Variable Declaration...."

        DataTable dtblCustomer = new DataTable();
        private Font NormalFont = new Font("Verdana", 8, FontStyle.Regular);
        CommonListBL objList = new CommonListBL();

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                dtblCustomer = objList.ListOfRecord("usp_Customer_List", null, "Customer - LoadList");
                if (objList.Exception == null)
                {
                    ArrangeDataGridView();
                    dgvContacts.AutoGenerateColumns = false;
                    dgvContacts.DataSource = dtblCustomer;
                    ArrangeDataGridView();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Contacts - LoadList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvContacts.Columns[0].DataPropertyName = dtblCustomer.Columns["CustomerID"].ToString();
                dgvContacts.Columns[1].DataPropertyName = dtblCustomer.Columns["Company"].ToString();
                dgvContacts.Columns[2].DataPropertyName = dtblCustomer.Columns["City"].ToString();
                dgvContacts.Columns[3].DataPropertyName = dtblCustomer.Columns["Phone1"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Contacts", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Form Event..."

        public frmContacts()
        {
            InitializeComponent();
        }

        private void frmContacts_Load(object sender, EventArgs e)
        {

            DataGridView t = ((DataGridView)dgvContacts);
            t.ForeColor = Color.Black;
            t.BackgroundColor = Color.White;
            t.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            t.StandardTab = true;
            t.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            t.AllowUserToAddRows = false;
            t.AllowUserToDeleteRows = false;
            t.MultiSelect = false;
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
            t.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            t.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 225); 
            LoadList();

        }

        #endregion

        #region "GridView Event"

        private void dgvContacts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvContacts, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvContacts, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Contacts", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

    }
}
