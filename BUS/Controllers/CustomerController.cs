using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DTO.Entities;

namespace BUS.Controllers
{
    public class CustomerController
    {
        // Make Customer 
        private Customer GetCustomer(string Id, string CustomerName,
            string CustomerID, string Address, string Phonenumber)
        {
            var customer = new Customer
            {
                Id = Id,
                Name = CustomerName,
                CustomerId = CustomerID,
                Address = Address,
                Phonenumber = Phonenumber,
            };
            return customer;
        }

        // Get All Customer
        public List<Customer> GetAllCustomer(ref string error)
        {
            using (var context = new Context())
            {
                try
                {
                    var customers = context.Customers.ToList();
                    error = "Get Customers Success!!!";
                    return customers;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
            }
        }

        // Get Customer By Id
        public Customer GetCustomerById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var customer = context.Customers.Where(cc => cc.Id == Id).FirstOrDefault();
                    if (customer != null)
                    {
                        error = "Get Customer Success!!!";
                    }
                    error = "Customer Is Not Exsit!!!";
                    return customer;
                }
            }
            catch
            {
                error = "Get Customer Failure!!!";
                return null;
            }
        }

        // Add New Customer
        public bool AddNewCustomer(
            string Id,
            string Name,
            string CustomerId,
            string Address,
            string Phonenumber,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    // Check service
                    var customer = this.GetCustomer(Id, Name, CustomerId, Address, Phonenumber);
                    if (customer != null)
                    {
                        context.Customers.Add(customer);
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Add Customer Success!!!";
                            return true;
                        }
                    }
                    error = "Customer Invalid!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Add Customer!!!";
                return false;
            }
        }

        // Update Customer
        public bool UpdateCustomerById(
            string Id,
            string NewName,
            string NewCustomerId,
            string NewAddress,
            string NewPhonenumber,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    var customer = context.Customers.
                         SingleOrDefault(c => c.Id == Id);
                    if (customer != null)
                    {
                        customer.Name = NewName;
                        customer.CustomerId = NewCustomerId;
                        customer.Phonenumber = NewPhonenumber;
                        customer.Address = NewAddress;
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Update Customer Success!!!";
                            return true;
                        }
                        error = "Customer Has No Change!!!";
                        return false;
                    }
                    error = "Customer Is Not Exsit!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong!!!";
                return false;
            }
        }

        // Delete Customer
        public bool RemoveCustomerById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var customer = context.Customers.
                        SingleOrDefault(s => s.Id == Id);
                    if (customer != null)
                    {
                        context.Customers.Remove(customer);
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Remove Customer Success!!!";
                            return true;
                        }
                        error = "Remove Customer Failure!!!";
                        return false;
                    }
                    error = "Customer Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Remove Customer!!!";
                return false;
            }
        }
    }
}
