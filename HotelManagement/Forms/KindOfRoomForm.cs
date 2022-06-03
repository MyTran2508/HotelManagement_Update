using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HotelManagement.Resources.Utils;
using BUS.Controllers;

namespace HotelManagement.Forms
{
    public partial class KindOfRoomForm : Form
    {
        KindOfRoomController kor = null;

        public KindOfRoomForm()
        {
            InitializeComponent();
            kor = new KindOfRoomController();
        }

        private void ClearAllTextBox()
        {
            TBId.ResetText();
            TBName.ResetText();
            TbMax.ResetText();
            TBPrice.ResetText();
            TBId.Focus();
        }

        // Get datatable fill in DataGrid
        private void FillDataGrid()
        {
            string error = "";
            var rs = kor.GetAllKindOfRooms(ref error);
            if (rs != null)
            {
                DataTable dt = Common.GetDataTable("Mã LP", "Tên LP", "Số Người", "Đơn Giá");
                if (dt != null)
                {
                    foreach (var r in rs)
                    {
                        dt.Rows.Add(r.Id, r.Name, r.Max, r.Price);
                    }
                    this.GridViewKORooms.DataSource = dt;
                    /*this.GridViewRooms.Columns[0].Width = 70;
                    this.GridViewRooms.Columns[1].Width = 130;
                    this.GridViewRooms.Columns[2].Width = 150;
                    this.GridViewRooms.Columns[3].Width = 130;*/
                }

            }
        }

        private void KindOfRoomForm_Load(object sender, EventArgs e)
        {
            ClearAllTextBox();
            FillDataGrid();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = TBId.Text;
                string Name = TBName.Text;
                string Max = TbMax.Text;
                string Price = TBPrice.Text;
                string error = "";
                bool isUpdated = kor.
                    UpdateKindOfRoomById(Id, Name, Max, Price, ref error);

                if (isUpdated)
                {
                    this.ClearAllTextBox();
                    this.FillDataGrid();
                }
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GridViewKORooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get Value of current row
            int rowIndex = Common.GetCurrentRowSelected(this.GridViewKORooms);
            if (rowIndex != -1)
            {
                string Id = Common.
                    GetValueOfCellGridView(GridViewKORooms, rowIndex, 0);
                string Name = Common.
                    GetValueOfCellGridView(GridViewKORooms, rowIndex, 1);
                string Max = Common.
                    GetValueOfCellGridView(GridViewKORooms, rowIndex, 2);
                string Price = Common.
                    GetValueOfCellGridView(GridViewKORooms, rowIndex, 3);

                this.TBId.Text = Id;
                this.TBName.Text = Name;
                this.TbMax.Text = Max;  
                this.TBPrice.Text = Price;  
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = TBId.Text;
                string Name = TBName.Text;
                int Max = int.Parse(TbMax.Text);
                float Price = float.Parse(TBPrice.Text);

                string error = "";
                bool isCreated = kor.
                    InsertKindOfRooms(Id, Name, Max, Price, ref error);
                if (isCreated)
                {
                    // Refresh Data
                    this.FillDataGrid();

                    // Clear Text Box If Insert success
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
            // Get Value of current row
            int rowIndex = Common.GetCurrentRowSelected(this.GridViewKORooms);
            if (rowIndex != -1)
            {
                string Id = Common.
                    GetValueOfCellGridView(GridViewKORooms, rowIndex, 0);
                string error = "";
                bool isDeleted = kor.RemoveKindOfRoomById(Id, ref error);
                if (isDeleted)
                {
                    this.FillDataGrid();
                }
                MessageBox.Show(error);
            }
        }
    }
}
