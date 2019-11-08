using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Configuration;

namespace Account.GUI.Country
{
    public partial class frmCSCAList : Account.GUIBase
    {

        #region "Public Variable Declaration...."

        CommonListBL CommList = new CommonListBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        DataTable dtblCountry = new DataTable();
        DataTable dtblState = new DataTable();
        DataTable dtblCity = new DataTable();
        DataTable dtblArea = new DataTable();
        DataView DV;
        int idgvPositionCountry = 0;
        int idgvPositionState = 0;
        int idgvPositionCity = 0;
        int idgvPositionArea = 0;
        string StrFilter = "";
        bool valCountry = false;
        bool valState = false;
        bool valCity = false;

        SortOrder CountrysortDirection;
        DataGridViewColumn CountrysortedColumn;
        SortOrder StatesortDirection;
        DataGridViewColumn StatesortedColumn;
        SortOrder CitysortDirection;
        DataGridViewColumn CitysortedColumn;
        SortOrder AreasortDirection;
        DataGridViewColumn AreasortedColumn;
        #endregion

        #region "Private Methods...."

        public void LoadCountryList()
        {
            try
            {

                NameValueCollection para = new NameValueCollection();
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblCountry = CommList.ListOfRecord("usp_Country_List", para, "Location - LoadCountryList");
                if (CommList.Exception != null)
                {
                    MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dgvCountry.CurrentRow != null)
                {
                    idgvPositionCountry = dgvCountry.CurrentRow.Index;
                }

                valCountry = false;
                ArrangeCountryGridView();
                dgvCountry.AutoGenerateColumns = false;
                dgvCountry.DataSource = dtblCountry;

                lblTotRecCountry.Text = Utill.Common.CommonMessage.TotalRecord + dgvCountry.RowCount.ToString();
                if (dgvCountry.CurrentRow != null && idgvPositionCountry <= dgvCountry.RowCount)
                {
                    if (dgvCountry.Rows.Count - 1 < idgvPositionCountry)
                    {
                        dgvCountry.CurrentCell = dgvCountry.Rows[idgvPositionCountry - 1].Cells[0];
                    }
                    else
                    {
                        dgvCountry.CurrentCell = dgvCountry.Rows[idgvPositionCountry].Cells[0];
                    }
                }

                ArrangeCountryGridView();
                valCountry = true;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeCountryGridView()
        {
            try
            {
                dgvCountry.Columns["CountryName"].DataPropertyName = dtblCountry.Columns["CountryName"].ToString();
                dgvCountry.Columns["CountryID"].DataPropertyName = dtblCountry.Columns["CountryID"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void LoadStateList()
        {
            try
            {
                if (dgvCountry.CurrentRow != null)
                {
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_CountryID", dgvCountry.CurrentRow.Cells["CountryID"].Value.ToString());

                    dtblState = CommList.ListOfRecord("usp_State_List", para, "Location - LoadStateList");
                    if (CommList.Exception != null)
                    {
                        MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (dgvState.CurrentRow != null)
                    {
                        idgvPositionState = dgvState.CurrentRow.Index;
                    }

                    valState = false;
                    ArrangeStateGridView();
                    dgvState.AutoGenerateColumns = false;
                    dgvState.DataSource = dtblState;

                    lblTotRecState.Text = Utill.Common.CommonMessage.TotalRecord + dgvState.RowCount.ToString();
                    if (dgvState.CurrentRow != null && idgvPositionState <= dgvState.RowCount)
                    {
                        if (dgvState.Rows.Count - 1 < idgvPositionState)
                        {
                            dgvState.CurrentCell = dgvState.Rows[idgvPositionState - 1].Cells[0];
                        }
                        else
                        {
                            dgvState.CurrentCell = dgvState.Rows[idgvPositionState].Cells[0];
                        }
                    }

                    ArrangeStateGridView();
                    valState = true;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeStateGridView()
        {
            try
            {
                dgvState.Columns["StateName"].DataPropertyName = dtblState.Columns["StateName"].ToString();
                dgvState.Columns["StateID"].DataPropertyName = dtblState.Columns["StateID"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void LoadCityList()
        {
            try
            {
                if (dgvState.CurrentRow != null)
                {
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_StateID", dgvState.CurrentRow.Cells["StateID"].Value.ToString());

                    dtblCity = CommList.ListOfRecord("usp_City_List", para, "Location - LoadCityList");
                    if (CommList.Exception != null)
                    {
                        MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (dgvCity.CurrentRow != null)
                    {
                        idgvPositionCity = dgvCity.CurrentRow.Index;
                    }

                    valCity = false;
                    ArrangeCityGridView();
                    dgvCity.AutoGenerateColumns = false;
                    dgvCity.DataSource = dtblCity;

                    lblTotRecCity.Text = Utill.Common.CommonMessage.TotalRecord + dgvCity.RowCount.ToString();
                    if (dgvCity.CurrentRow != null && idgvPositionCity <= dgvCity.RowCount)
                    {
                        if (dgvCity.Rows.Count - 1 < idgvPositionCity)
                        {
                            dgvCity.CurrentCell = dgvCity.Rows[idgvPositionCity - 1].Cells[0];
                        }
                        else
                        {
                            dgvCity.CurrentCell = dgvCity.Rows[idgvPositionCity].Cells[0];
                        }
                    }
                    ArrangeCityGridView();
                    valCity = true;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeCityGridView()
        {
            try
            {
                dgvCity.Columns["CityName"].DataPropertyName = dtblCity.Columns["CityName"].ToString();
                dgvCity.Columns["CityID"].DataPropertyName = dtblCity.Columns["CityID"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void LoadAreaList()
        {
            try
            {
                if (dgvCity.CurrentRow != null)
                {
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_CityID", dgvCity.CurrentRow.Cells["CityID"].Value.ToString());

                    dtblArea = CommList.ListOfRecord("usp_Area_List", para, "Location - LoadAreaList");
                    if (CommList.Exception != null)
                    {
                        MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (dgvArea.CurrentRow != null)
                    {
                        idgvPositionArea = dgvArea.CurrentRow.Index;
                    }

                    ArrangeAreaGridView();
                    dgvArea.AutoGenerateColumns = false;
                    dgvArea.DataSource = dtblArea;

                    lblTotRecArea.Text = Utill.Common.CommonMessage.TotalRecord + dgvArea.RowCount.ToString();
                    if (dgvArea.CurrentRow != null && idgvPositionArea <= dgvArea.RowCount)
                    {
                        if (dgvArea.Rows.Count - 1 < idgvPositionArea)
                        {
                            dgvArea.CurrentCell = dgvArea.Rows[idgvPositionArea - 1].Cells[0];
                        }
                        else
                        {
                            dgvArea.CurrentCell = dgvArea.Rows[idgvPositionArea].Cells[0];
                        }
                    }
                    ArrangeAreaGridView();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeAreaGridView()
        {
            try
            {
                dgvArea.Columns["AreaName"].DataPropertyName = dtblArea.Columns["AreaName"].ToString();
                dgvArea.Columns["AreaID"].DataPropertyName = dtblArea.Columns["AreaID"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void CountrySetSortedColumns()
        {
            try
            {
                if (dgvCountry.SortedColumn != null)
                {
                    CountrysortedColumn = dgvCountry.SortedColumn;
                    CountrysortDirection = dgvCountry.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void CountrysetDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                if (dgvState.CurrentRow != null)
                {
                    idgvPositionState = dgvState.CurrentRow.Index;
                }

                if (dgvCity.CurrentRow != null)
                {
                    idgvPositionCity = dgvCity.CurrentRow.Index;
                }
                if (dgvArea.CurrentRow != null)
                {
                    idgvPositionArea = dgvArea.CurrentRow.Index;
                }
                LoadCountryList();
                dgvCountry_SelectionChanged(sender, e);

                if (CountrysortedColumn != null)
                {
                    ListSortDirection LSD;
                    if (CountrysortDirection == SortOrder.Ascending)
                    {
                        LSD = System.ComponentModel.ListSortDirection.Ascending;
                    }
                    else
                    {
                        LSD = System.ComponentModel.ListSortDirection.Descending;
                    }

                    dgvCountry.Sort(dgvCountry.Columns[CountrysortedColumn.Name], LSD);
                }
                if (dgvCountry.CurrentRow != null && idgvPositionCountry <= dgvCountry.RowCount)
                {
                    if (dgvCountry.Rows.Count - 1 < idgvPositionCountry)
                    {
                        dgvCountry.CurrentCell = dgvCountry.Rows[idgvPositionCountry - 1].Cells[0];
                    }
                    else
                    {
                        dgvCountry.CurrentCell = dgvCountry.Rows[idgvPositionCountry].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void StateSetSortedColumns()
        {
            try
            {
                if (dgvState.SortedColumn != null)
                {
                    StatesortedColumn = dgvState.SortedColumn;
                    StatesortDirection = dgvState.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void StatesetDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                if (dgvCity.CurrentRow != null)
                {
                    idgvPositionCity = dgvCity.CurrentRow.Index;
                }
                if (dgvArea.CurrentRow != null)
                {
                    idgvPositionArea = dgvArea.CurrentRow.Index;
                }
                LoadStateList();
                dgvState_SelectionChanged(sender, e);

                if (StatesortedColumn != null)
                {
                    ListSortDirection LSD;
                    if (StatesortDirection == SortOrder.Ascending)
                    {
                        LSD = System.ComponentModel.ListSortDirection.Ascending;
                    }
                    else
                    {
                        LSD = System.ComponentModel.ListSortDirection.Descending;
                    }

                    dgvState.Sort(dgvState.Columns[StatesortedColumn.Name], LSD);
                }
                if (dgvState.CurrentRow != null && idgvPositionState <= dgvState.RowCount)
                {
                    if (dgvState.Rows.Count - 1 < idgvPositionState)
                    {
                        dgvState.CurrentCell = dgvState.Rows[idgvPositionState - 1].Cells[0];
                    }
                    else
                    {
                        dgvState.CurrentCell = dgvState.Rows[idgvPositionState].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void CitySetSortedColumns()
        {
            try
            {
                if (dgvCity.SortedColumn != null)
                {
                    CitysortedColumn = dgvCity.SortedColumn;
                    CitysortDirection = dgvCity.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void CitysetDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                if (dgvArea.CurrentRow != null)
                {
                    idgvPositionArea = dgvArea.CurrentRow.Index;
                }
                LoadCityList();
                dgvCity_SelectionChanged(sender, e);

                if (CitysortedColumn != null)
                {
                    ListSortDirection LSD;
                    if (CitysortDirection == SortOrder.Ascending)
                    {
                        LSD = System.ComponentModel.ListSortDirection.Ascending;
                    }
                    else
                    {
                        LSD = System.ComponentModel.ListSortDirection.Descending;
                    }

                    dgvCity.Sort(dgvCity.Columns[CitysortedColumn.Name], LSD);
                }
                if (dgvCity.CurrentRow != null && idgvPositionCity <= dgvCity.RowCount)
                {
                    if (dgvCity.Rows.Count - 1 < idgvPositionCity)
                    {
                        dgvCity.CurrentCell = dgvCity.Rows[idgvPositionCity - 1].Cells[0];
                    }
                    else
                    {
                        dgvCity.CurrentCell = dgvCity.Rows[idgvPositionCity].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void AreaSetSortedColumns()
        {
            try
            {
                if (dgvArea.SortedColumn != null)
                {
                    AreasortedColumn = dgvArea.SortedColumn;
                    AreasortDirection = dgvArea.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void AreasetDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadAreaList();

                if (AreasortedColumn != null)
                {
                    ListSortDirection LSD;
                    if (AreasortDirection == SortOrder.Ascending)
                    {
                        LSD = System.ComponentModel.ListSortDirection.Ascending;
                    }
                    else
                    {
                        LSD = System.ComponentModel.ListSortDirection.Descending;
                    }

                    dgvArea.Sort(dgvArea.Columns[AreasortedColumn.Name], LSD);
                }
                if (dgvArea.CurrentRow != null && idgvPositionArea <= dgvArea.RowCount)
                {
                    if (dgvArea.Rows.Count - 1 < idgvPositionArea)
                    {
                        dgvArea.CurrentCell = dgvArea.Rows[idgvPositionArea - 1].Cells[0];
                    }
                    else
                    {
                        dgvArea.CurrentCell = dgvArea.Rows[idgvPositionArea].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Form Event...."

        public frmCSCAList()
        {
            InitializeComponent();
        }

        private void frmCSCAList_Load(object sender, EventArgs e)
        {
            try{
                cmbreports.Items.Add("--Select Report--");
                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#3005#") != -1)
                        {
                            cmbreports.Items.Add("Location Register");
                        }
                    }
                    else
                    {
                        cmbreports.Items.Add("Location Register");
                    }
                }
                else if (CurrentUser.UserID == 1)
                {
                    cmbreports.Items.Add("Location Register");
                }
                cmbreports.SelectedIndex = 0;

            AddHandlers(this);
            SetControlsDefaults(this);
            dgvCountry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvState.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvArea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LoadCountryList();

                 if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#3002#") != -1)
                        { btnNewCountry.Enabled = true; }
                        else { btnNewCountry.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3003#") != -1)
                        { btnEditCountry.Enabled = true; }
                        else { btnEditCountry.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3004#") != -1)
                        { btnDeleteCountry.Enabled = true; }
                        else { btnDeleteCountry.Enabled = false; }

                        //if (CurrentUser.PrivilegeStr.IndexOf("#3005#") != -1)
                        //{ rptLocation.Visible = true; }
                        //else { rptLocation.Visible = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3002#") != -1)
                        { btnNewState.Enabled = true; }
                        else { btnNewState.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3003#") != -1)
                        { btnEditState.Enabled = true; }
                        else { btnEditState.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3004#") != -1)
                        { btnDeleteState.Enabled = true; }
                        else { btnDeleteState.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3002#") != -1)
                        { btnNewCity.Enabled = true; }
                        else { btnNewCity.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3003#") != -1)
                        { btnEditCity.Enabled = true; }
                        else { btnEditCity.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3004#") != -1)
                        { btnDeleteCity.Enabled = true; }
                        else { btnDeleteCity.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3002#") != -1)
                        { btnNewArea.Enabled = true; }
                        else { btnNewArea.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3003#") != -1)
                        { btnEditArea.Enabled = true; }
                        else { btnEditArea.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#3004#") != -1)
                        { btnDeleteArea.Enabled = true; }
                        else { btnDeleteArea.Enabled = false; }
                    }
                }

            }

            
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
          
        }

        #endregion

        #region "Button Events..."

        private void btnNewCountry_Click(object sender, EventArgs e)
        {
            try
            {
                frmCountryEntry fCountry = new frmCountryEntry((int)Common.Constant.Mode.Insert, 0);
                fCountry.ShowDialog();
                LoadCountryList();
                if (dgvCountry.Rows.Count > 0)
                {
                    dgvCountry.CurrentCell = dgvCountry.Rows[0].Cells[0];
                }
                dgvCountry_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEditCountry_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCountry.CurrentRow != null)
                {
                    CountrySetSortedColumns();
                    frmCountryEntry fCountry = new frmCountryEntry((int)Common.Constant.Mode.Modify, (Int64)dgvCountry.CurrentRow.Cells["CountryID"].Value);
                    fCountry.ShowDialog();
                    CountrysetDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDeleteCountry_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCountry.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to delete Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CountrySetSortedColumns();
                        CommDelRec.DeleteRecord((Int64)dgvCountry.CurrentRow.Cells["CountryID"].Value, "usp_Country_Delete", "Country - Delete");
                        if (CommDelRec.Exception == null)
                        {
                            if (CommDelRec.ErrorMessage != "")
                            {
                                MessageBox.Show(CommDelRec.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                CountrysetDefaultGridRecords(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNewState_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCountry.CurrentRow != null)
                {
                    frmStateEntry fState = new frmStateEntry((int)Common.Constant.Mode.Insert, 0, (long)dgvCountry.CurrentRow.Cells["CountryID"].Value, dgvCountry.CurrentRow.Cells["CountryName"].Value.ToString());
                    fState.ShowDialog();
                    LoadStateList();
                    if (dgvState.Rows.Count > 0)
                    {
                        dgvState.CurrentCell = dgvState.Rows[0].Cells[0];
                    }
                    dgvState_SelectionChanged(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEditState_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvState.CurrentRow != null)
                {
                    StateSetSortedColumns();
                    frmStateEntry fState = new frmStateEntry((int)Common.Constant.Mode.Modify, (Int64)dgvState.CurrentRow.Cells["StateID"].Value, (long)dgvCountry.CurrentRow.Cells["CountryID"].Value, dgvCountry.CurrentRow.Cells["CountryName"].Value.ToString());
                    fState.ShowDialog();
                    StatesetDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDeleteState_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvState.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to delete Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        StateSetSortedColumns();
                        CommDelRec.DeleteRecord((Int64)dgvState.CurrentRow.Cells["StateID"].Value, "usp_State_Delete", "State - Delete");
                        if (CommDelRec.Exception == null)
                        {
                            if (CommDelRec.ErrorMessage != "")
                            {
                                MessageBox.Show(CommDelRec.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                StatesetDefaultGridRecords(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNewCity_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvState.CurrentRow != null)
                {
                    frmCityEntry fCity = new frmCityEntry((int)Common.Constant.Mode.Insert, 0, dgvCountry.CurrentRow.Cells["CountryName"].Value.ToString(), (long)dgvState.CurrentRow.Cells["StateID"].Value, dgvState.CurrentRow.Cells["StateName"].Value.ToString());
                    fCity.ShowDialog();
                    LoadCityList();
                    if (dgvCity.Rows.Count > 0)
                    {
                        dgvCity.CurrentCell = dgvCity.Rows[0].Cells[0];
                    }
                    dgvCity_SelectionChanged(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEditCity_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCity.CurrentRow != null)
                {
                    CitySetSortedColumns();
                    frmCityEntry fCity = new frmCityEntry((int)Common.Constant.Mode.Modify, (Int64)dgvCity.CurrentRow.Cells["CityID"].Value, dgvCountry.CurrentRow.Cells["CountryName"].Value.ToString(), (long)dgvState.CurrentRow.Cells["StateID"].Value, dgvState.CurrentRow.Cells["StateName"].Value.ToString());
                    fCity.ShowDialog();
                    CitysetDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDeleteCity_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCity.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to delete Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CitySetSortedColumns();
                        CommDelRec.DeleteRecord((Int64)dgvCity.CurrentRow.Cells["CityID"].Value, "usp_City_Delete", "City - Delete");
                        if (CommDelRec.Exception == null)
                        {
                            if (CommDelRec.ErrorMessage != "")
                            {
                                MessageBox.Show(CommDelRec.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                CitysetDefaultGridRecords(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNewArea_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCity.CurrentRow != null)
                {
                    frmAreaEntry fArea = new frmAreaEntry((int)Common.Constant.Mode.Insert, 0, dgvCountry.CurrentRow.Cells["CountryName"].Value.ToString(), dgvState.CurrentRow.Cells["StateName"].Value.ToString(), (long)dgvCity.CurrentRow.Cells["CityID"].Value, dgvCity.CurrentRow.Cells["CityName"].Value.ToString());
                    fArea.ShowDialog();
                    LoadAreaList();
                    if (dgvArea.Rows.Count > 0)
                    {
                        dgvArea.CurrentCell = dgvArea.Rows[0].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEditArea_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArea.CurrentRow != null)
                {
                    AreaSetSortedColumns();
                    frmAreaEntry fArea = new frmAreaEntry((int)Common.Constant.Mode.Modify, (Int64)dgvArea.CurrentRow.Cells["AreaID"].Value, dgvCountry.CurrentRow.Cells["CountryName"].Value.ToString(), dgvState.CurrentRow.Cells["StateName"].Value.ToString(), (long)dgvCity.CurrentRow.Cells["CityID"].Value, dgvCity.CurrentRow.Cells["CityName"].Value.ToString());
                    fArea.ShowDialog();
                    AreasetDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnDeleteArea_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArea.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to delete Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AreaSetSortedColumns();
                        CommDelRec.DeleteRecord((Int64)dgvArea.CurrentRow.Cells["AreaID"].Value, "usp_Area_Delete", "Area - Delete");
                        if (CommDelRec.Exception == null)
                        {
                            if (CommDelRec.ErrorMessage != "")
                            {
                                MessageBox.Show(CommDelRec.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                AreasetDefaultGridRecords(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid Cell Paint Event"

        private void dgvCountry_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCountry, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCountry, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvState_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvState, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvState, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvCity_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCity, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCity, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvArea_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvArea, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvArea, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Grid Selection change Event..."

        private void dgvCountry_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (valCountry == true)
                {
                    LoadStateList();
                    dgvState_SelectionChanged(sender, e);
                    if (dgvState.CurrentRow != null)
                    {
                        idgvPositionState = dgvState.CurrentRow.Index;
                    }
                    else
                    {
                        idgvPositionState = 0;
                    }
                }
                else
                {
                    dgvState.DataSource = null;
                    lblTotRecState.Text = Utill.Common.CommonMessage.TotalRecord + "0";
                    dgvCity.DataSource = null;
                    lblTotRecCity.Text = Utill.Common.CommonMessage.TotalRecord + "0";
                    dgvArea.DataSource = null;
                    lblTotRecArea.Text = Utill.Common.CommonMessage.TotalRecord + "0";
                }


            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvState_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (valState == true)
                {
                    LoadCityList();
                    dgvCity_SelectionChanged(sender, e);
                    if (dgvCity.CurrentRow != null)
                    {
                        idgvPositionCity = dgvCity.CurrentRow.Index;
                    }
                    else
                    {
                        idgvPositionCity = 0;
                    }
                }
                else
                {
                    dgvCity.DataSource = null;
                    lblTotRecCity.Text = Utill.Common.CommonMessage.TotalRecord + "0";
                    dgvArea.DataSource = null;
                    lblTotRecArea.Text = Utill.Common.CommonMessage.TotalRecord + "0";
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvCity_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (valCity == true)
                {
                    LoadAreaList();
                    if (dgvArea.CurrentRow != null)
                    {
                        idgvPositionArea = dgvArea.CurrentRow.Index;
                    }
                    else
                    {
                        idgvPositionArea = 0;
                    }
                }
                else
                {
                    dgvArea.DataSource = null;
                    lblTotRecArea.Text = Utill.Common.CommonMessage.TotalRecord + "0";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        #endregion

        #region "Report Menu Event..."

            #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            ////Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
                try
                {
                    if (cmbreports.SelectedIndex > 0)
                    {
                        DataTable dtReport = new DataTable();


                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_UserID", CurrentUser.UserID.ToString());
                        para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                        dtReport = CommList.ListOfRecord("rpt_CountryStateCityArea", para, "Location - Report");
                        if (CommList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptLocationReg.rpt"))
                            {
                                //dtReport.TableName = "LocationRegister";
                                //dtReport.WriteXmlSchema(@"D:\Report\LocationRegister.xsd");

                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptLocationReg.rpt");

                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Location Register", true, true, true, true, false, true, true, false, false, false, true);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Location Register - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                            }
                        }
                    }
                    cmbreports.SelectedIndex = 0;
                  
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Location report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
        
       }

        
      

       

        




    }
}
