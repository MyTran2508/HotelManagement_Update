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
    public partial class RoomForm : Form
    {
        KindOfRoomController kor = null;
        RoomController rc = null;
        RoomStatusController rsc = null;


        public RoomForm()
        {
            InitializeComponent();
            kor = new KindOfRoomController();
            rc = new RoomController();
            rsc = new RoomStatusController();

        }

        private void ClearAllTextBox()
        {
            TBId.ResetText();
            TBName.ResetText();
            TbDescription.ResetText();
            TBId.Focus();
        }



        // Fill ComboBox KindOfRooms
        private void FillComboBoxKindOfRooms()
        {
            string error = "";
            var kindOfRooms = kor.GetAllKindOfRooms(ref error);
            DataTable dt = Common.FillDataTable(kindOfRooms);
            if (dt != null)
            {
                CBKindOfRom.DataSource = dt;
                CBKindOfRom.DisplayMember = "Name";
                CBKindOfRom.ValueMember = "Id";
            }
        }

        // Fill ComboBox RoomStatus
        private void FillComboBoxRoomStatus()
        {
            string error = "";
            var roomSta = rsc.GetRoomStatuses(ref error);
            DataTable dt = Common.FillDataTable(roomSta);
            if (dt != null)
            {
                CBRoomStatus.DataSource = dt;
                CBRoomStatus.DisplayMember = "Name";
                CBRoomStatus.ValueMember = "Id";
            }
        }

        // Fill Data Grid View
        private void FillDataGridViewRooms()
        {
            string error = "";
            var rooms = rc.GetAllRooms(ref error);
            if (rooms != null)
            {
                DataTable dt = Common.GetDataTable(
                    "Mã TT",
                    "Loại Phòng",
                    "Tình Trạng",
                    "Tên Phòng",
                    "Ghi Chú");

                foreach (var ro in rooms)
                {
                    if (ro.KindOfRoom != null)
                    {
                        var kindOfRoom = ro.KindOfRoom.Name;
                        var roomStatus = ro.RoomStatus.Name;
                        dt.Rows.Add(ro.Id, kindOfRoom, roomStatus, ro.Name, ro.Description);
                    }
                }
                GridViewRooms.DataSource = dt;
                this.GridViewRooms.Columns[0].Width = 70;
                this.GridViewRooms.Columns[1].Width = 130;
                this.GridViewRooms.Columns[2].Width = 150;
                this.GridViewRooms.Columns[3].Width = 130;
            }
        }

        private void FillTextBox()
        {
            int currentRow = Common.GetCurrentRowSelected(this.GridViewRooms);
            if (currentRow != -1)
            {
                TBId.Text = Common.
                GetValueOfCellGridView(this.GridViewRooms, currentRow, 0);
                TBName.Text = Common.
                    GetValueOfCellGridView(this.GridViewRooms, currentRow, 3);
                TbDescription.Text = Common.
                    GetValueOfCellGridView(this.GridViewRooms, currentRow, 4);
            }
        }

        // Form Load
        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.FillComboBoxKindOfRooms();
            this.FillComboBoxRoomStatus();
            this.FillDataGridViewRooms();
            this.FillTextBox();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = Common.GetValueTextBox(TBId);
                string Name = Common.GetValueTextBox(TBName);
                string roomStatus = Common.GetValueComboBox(this.CBRoomStatus);
                string kindOfRoom = Common.GetValueComboBox(this.CBKindOfRom);
                string Desc = Common.GetValueTextBox(TbDescription);

                string error = "";
                bool isCreated = rc.
                    InsertRoom(ref error, Id, kindOfRoom, roomStatus, Name, Desc);
                if (isCreated)
                {
                    this.FillDataGridViewRooms();
                    ClearAllTextBox();
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
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewRooms);
                // Get Id
                string Id = Common.
                    GetValueOfCellGridView(this.GridViewRooms, rowIndex, 0);

                // remove
                string error = "";
                bool isDeleted = rc.RemoveRoom(ref error, Id);
                if (isDeleted)
                {
                    this.FillComboBoxKindOfRooms();
                    this.FillComboBoxRoomStatus();
                    this.FillDataGridViewRooms();
                    this.FillTextBox();
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
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewRooms);

                // Get Values
                string id = Common.
                    GetValueOfCellGridView(this.GridViewRooms, rowIndex, 0);
                string name = Common.GetValueTextBox(TBName);
                string description = Common.GetValueTextBox(TbDescription);
                string kindOfRoomId = Common.GetValueComboBox(CBKindOfRom);
                string roomStatusId = Common.GetValueComboBox(CBRoomStatus);

                string error = "";
                bool isUpdated = rc.UpdateRoom(ref error, id, kindOfRoomId, roomStatusId, name, description);
                if (isUpdated)
                {
                    this.FillDataGridViewRooms();
                    this.FillComboBoxKindOfRooms();
                    this.FillComboBoxRoomStatus();
                }
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get Value of current row
            int rowIndex = Common.GetCurrentRowSelected(this.GridViewRooms);
            if (rowIndex != -1)
            {
                string Id = Common.
                    GetValueOfCellGridView(GridViewRooms, rowIndex, 0);
                string kor = Common.GetValueComboBox(CBKindOfRom);
                string rs = Common.GetValueComboBox(CBRoomStatus);
                string Name = Common.
                    GetValueOfCellGridView(GridViewRooms, rowIndex, 3);
                string Desc = Common.
                    GetValueOfCellGridView(GridViewRooms, rowIndex, 4);

                this.TBId.Text = Id;
                this.TBName.Text = Name;
                this.TbDescription.Text = Desc;
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {

        }
    }
}
