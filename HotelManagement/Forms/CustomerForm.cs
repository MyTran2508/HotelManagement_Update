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
using DTO.Entities;
using DTO;
using HotelManagement.Resources.Utils;

namespace HotelManagement.Forms
{
    public partial class CustomerForm : Form
    {
        CustomerController cc = null;

        public CustomerForm()
        {
            InitializeComponent();
            this.cc = new CustomerController();
        }

        private void ClearAllTextBox()
        {
            TBId.ResetText();
            TBName.ResetText();
            TBAddress.ResetText();  
            TBPhone.ResetText();    
            TBCustomerId.ResetText();   
            TBId.Focus();
        }

        // Get datatable fill in DataGrid
        private void FillDataGrid()
        {
            string error = "";
            var customers = cc.GetAllCustomer(ref error);

            if (customers != null)
            {
                DataTable dt = Common.GetDataTable(
                    "Mã KH",
                    "Họ Tên",
                    "CMND/CCCD",
                    "Địa Chỉ",
                    "Số ĐT"
                    );

                foreach (var cc in customers)
                {

                    dt.Rows.Add(cc.Id, cc.Name, cc.CustomerId, cc.Address, cc.Phonenumber);

                }
                // Return databale 
                this.GridViewCustomer.DataSource = dt;

                // Set Width Column
                this.GridViewCustomer.Columns[0].Width = 100;
                this.GridViewCustomer.Columns[1].Width = 180;
                this.GridViewCustomer.Columns[2].Width = 150;
                this.GridViewCustomer.Columns[3].Width = 150;
                this.GridViewCustomer.Columns[4].Width = 150;
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            ClearAllTextBox();
            this.FillDataGrid();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Common.GetValueTextBox(TBId);
                string Name = Common.GetValueTextBox(TBName);
                string CustomerId = Common.GetValueTextBox(TBCustomerId);
                string Address = Common.GetValueTextBox(TBAddress);
                string Phonenumber = Common.GetValueTextBox(TBPhone);

                string error = "";
                bool isCreated = cc.AddNewCustomer
                    (id, Name, CustomerId, Address, Phonenumber, ref error);
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current Index
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewCustomer);

                // Get Values
                string id = Common.
                    GetValueOfCellGridView(this.GridViewCustomer, rowIndex, 0);
                string Name = Common.GetValueTextBox(TBName);
                string CustomerId = Common.GetValueTextBox(TBCustomerId);
                string Address = Common.GetValueTextBox(TBAddress);
                string Phonenumber = Common.GetValueTextBox(TBPhone);

                string error = "";
                bool isUpdated = cc.UpdateCustomerById(id, Name, CustomerId, Address, Phonenumber, ref error);
                if (isUpdated)
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
            try
            {
                // Get current Index
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewCustomer);
                // Get Id
                string Id = Common.
                    GetValueOfCellGridView(this.GridViewCustomer, rowIndex, 0);

                // remove
                string error = "";
                bool isDeleted = cc.RemoveCustomerById(Id, ref error);
                if (isDeleted)
                {
                    this.FillDataGrid();
                }
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = Common.GetCurrentRowSelected(this.GridViewCustomer);

            // Get Values
            string id = Common.
                GetValueOfCellGridView(this.GridViewCustomer, rowIndex, 0);
            string Name = Common.GetValueOfCellGridView(this.GridViewCustomer, rowIndex, 1);
            string CustometId = Common.GetValueOfCellGridView(this.GridViewCustomer, rowIndex, 2);
            string Address = Common.GetValueOfCellGridView(this.GridViewCustomer, rowIndex, 3);
            string Phonenumber = Common.GetValueOfCellGridView(this.GridViewCustomer, rowIndex, 4);

            this.TBId.Text = id;
            this.TBName.Text = Name;
            this.TBCustomerId.Text = CustometId;
            this.TBAddress.Text = Address;
            this.TBPhone.Text = Phonenumber;
        }
    }
}
