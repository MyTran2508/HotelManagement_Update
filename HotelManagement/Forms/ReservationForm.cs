using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BUS.Controllers;
using HotelManagement.Resources.Utils;

namespace HotelManagement.Forms
{
    public partial class ReservationForm : Form
    {
        RoomController rc = null;
        CustomerController cc = null;
        EmployeeController ec = null;
        ReservationController rec = null;
        
        
        public ReservationForm()
        {
            InitializeComponent();
            this.rc = new RoomController();
            this.cc = new CustomerController();
            this.ec = new EmployeeController();
            this.rec = new ReservationController();
        }
        // Fill Data Grid View
        private void FillDataGridViewReservations()
        {
            string error = "";
            var reservations = rec.GetAllReservations(ref error);
            if (reservations != null)
            {
                DataTable dt = Common.GetDataTable(
                    "Mã DK",
                    "Tên NV",
                    "Số Phòng",
                    "Khách Hàng",
                    "Ngày Thuê",
                    "Ngày Trả",
                    "Trạng Thái"
                    );

                foreach (var re in reservations)
                {
                    dt.Rows.Add(re.Id, re.EmployeeId,re.RoomId, re.CustomerId, re.DateIn, re.DateOut, re.Status);    
                }
                GridViewReservation.DataSource = dt;
                this.GridViewReservation.Columns[4].Width = 170;
                this.GridViewReservation.Columns[5].Width = 170;
                this.GridViewReservation.Columns[6].Width = 180;

            }
        }
        // Fill ComboBox RoomId
        private void FillComboBoxRoomId()
        {
            string error = "";
            var roomname = rc.GetAllRooms(ref error);
            DataTable dt = Common.FillDataTable(roomname);
            if (dt != null)
            {
                CBRoomId.DataSource = dt;
                CBRoomId.DisplayMember = "Id";
                CBRoomId.ValueMember = "Id";
            }
        }

        //Fill ComboBox CustomerId
        private void FillComboBoxCustomerId()
        {
            string error = "";
            var customername = cc.GetAllCustomer(ref error);
            DataTable dt = Common.FillDataTable(customername);
            if (dt != null)
            {
                CBCustomerId.DataSource = dt;
                CBCustomerId.DisplayMember = "Id";
                CBCustomerId.ValueMember = "Id";
            }
        }


        //Fill ComboBox EmployeeId
        private void FillComboBoxEmployeeId()
        {
            string error = "";
            var employeename = ec.GetAllEmployees(ref error);
            DataTable dt = Common.FillDataTable(employeename);
            if (dt != null)
            {
                CBEmployeeId.DataSource = dt;
                CBEmployeeId.DisplayMember = "Id";
                CBEmployeeId.ValueMember = "Id";
            }
        }

        //Fill ComboBox Status
        private void FillComboBoxStatus()
        {
            string error = "";
            var status = rec.GetAllReservations(ref error);
            DataTable dt = Common.FillDataTableStatus(status);
            if (dt != null)
            {
                CBStatus.DataSource = dt;
                CBStatus.DisplayMember = "Status";
                CBStatus.ValueMember = "Id";
            }
        }
        //Fill textBox
        private void FillTextBox()
        {
            int currentRow = Common.GetCurrentRowSelected(this.GridViewReservation);
            if (currentRow != -1)
            {
                TBId.Text = Common.
                GetValueOfCellGridView(this.GridViewReservation, currentRow, 0);
            }
        }

        // Event handler
        private void ReservationForm_Load(object sender, EventArgs e)
        {
            this.ClearAllTextBox();
            this.FillComboBoxRoomId();
            this.FillComboBoxCustomerId();
            this.FillComboBoxEmployeeId();
            this.FillDataGridViewReservations();
            this.FillComboBoxStatus();
            this.FillTextBox();
        }
        private void ClearAllTextBox()
        {
            TBId.ResetText();
            CBCustomerId.ResetText();
            CBEmployeeId.ResetText();
            CBRoomId.ResetText();
        }

        private void GirdViewReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get Value of current row
            int rowIndex = Common.GetCurrentRowSelected(this.GridViewReservation);
            if (rowIndex != -1)
            {
                string Id = Common.
                    GetValueOfCellGridView(GridViewReservation, rowIndex, 0);
                string EmployeeId = Common.GetValueOfCellGridView(GridViewReservation, rowIndex, 1);
                string RoomId = Common.GetValueOfCellGridView(GridViewReservation, rowIndex, 2);
                string CustomerId = Common.GetValueOfCellGridView(GridViewReservation, rowIndex, 3);
                string DateIn = Common.GetValueOfCellGridView(GridViewReservation, rowIndex, 4);
                string DateOut = Common.GetValueOfCellGridView(GridViewReservation, rowIndex, 5);


                this.TBId.Text = Id;
                this.CBEmployeeId.Text = EmployeeId;
                this.CBRoomId.Text = RoomId;
                this.CBCustomerId.Text = CustomerId;
                this.DTIn.Value = DateTime.Parse(DateIn);
                this.DTOut.Value = DateTime.Parse(DateOut);

            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = Common.GetValueTextBox(TBId);
                string EmployeeId = Common.GetValueComboBox(this.CBEmployeeId);
                string CustomerId = Common.GetValueComboBox(this.CBCustomerId);
                string RoomId = Common.GetValueComboBox(this.CBRoomId);
                DateTime DateIn = Common.GetValueDateTimePicker(DTIn);
                DateTime DateOut = Common.GetValueDateTimePicker(DTOut);
                string Status = "Chưa Thanh Toán";
   

                string error = "";
                bool isCreated = rec.InsertReservation(ref error,
                    Id, EmployeeId, RoomId, CustomerId, DateIn, DateOut, Status);
                if (isCreated)
                {
                    this.FillDataGridViewReservations();
                    this.ClearAllTextBox();
                    
                }
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current Index
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewReservation);

                // Get Values
                string id = Common.
                    GetValueOfCellGridView(this.GridViewReservation, rowIndex, 0);
                string EmployeeId = Common.GetValueComboBox(this.CBEmployeeId);
                string CustomerId = Common.GetValueComboBox(this.CBCustomerId);
                string RoomId = Common.GetValueComboBox(this.CBRoomId);
                DateTime DateIn = Common.GetValueDateTimePicker(DTIn);
                DateTime DateOut = Common.GetValueDateTimePicker(DTOut);

                string error = "";
                bool isUpdated = rec.UpdateReservation(ref error,
                    id, EmployeeId, RoomId, CustomerId, DateIn, DateOut);
                if (isUpdated)
                {
                    this.FillComboBoxRoomId();
                    this.FillComboBoxCustomerId();
                    this.FillComboBoxEmployeeId();
                    this.FillDataGridViewReservations();
                    this.FillTextBox();
                    this.ClearAllTextBox();
                }
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current Index
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewReservation);
                // Get Id
                string Id = Common.
                    GetValueOfCellGridView(this.GridViewReservation, rowIndex, 0);

                // remove
                string error = "";
                bool isDeleted = rec.RemoveReservation(ref error, Id);
                if (isDeleted)
                {
                    this.FillComboBoxRoomId();
                    this.FillComboBoxCustomerId();
                    this.FillComboBoxEmployeeId();
                    this.FillDataGridViewReservations();
                    this.FillTextBox();
                    this.ClearAllTextBox();
                }
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnFillter_Click(object sender, EventArgs e)
        {
            try
            {
                string Status = Common.GetValueComboBox(CBStatus);

                string error = "";
                var reservations = rec.GetAllReservationsByStatus(Status, ref error);

                if (reservations != null)
                {
                    DataTable dt = Common.GetDataTable(
                       "Mã DK",
                       "Tên NV",
                       "Số Phòng",
                       "Khách Hàng",
                       "Ngày Thuê",
                       "Ngày Trả",
                       "Trạng Thái"
                   );

                    foreach (var re in reservations)
                    {
                        dt.Rows.Add(re.Id, re.EmployeeId, re.RoomId, re.CustomerId, re.DateIn, re.DateOut, re.Status);
                    }
                    // Return databale 
                    this.GridViewReservation.DataSource = dt;

                    // Set Width Column
                    this.GridViewReservation.Columns[4].Width = 170;
                    this.GridViewReservation.Columns[5].Width = 170;
                    this.GridViewReservation.Columns[6].Width = 180;
                }
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.ClearAllTextBox();
            this.FillComboBoxRoomId();
            this.FillComboBoxCustomerId();
            this.FillComboBoxEmployeeId();
            this.FillDataGridViewReservations();
            this.FillTextBox();
        }
    }
}
