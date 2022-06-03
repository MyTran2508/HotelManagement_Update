using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;
using DTO;

namespace BUS.Controllers
{
    // Service controller
    public class ServiceController
    {
        // Make Service
        private Service GetService(string Id, string Name, float Price)
        {
            Service service = new Service();
            service.Id = Id;
            service.Name = Name;
            service.Price = Price;
            return service;
        }

        // Get All Services
        public List<Service> GetAllServices(ref string error)
        {
            using (var context = new Context())
            {
                try
                {
                    var services = (from sv in context.Services.Include("BillDetails")
                                    select sv).ToList();
                    error = "Get Services Success!!!";
                    return services;
                }
                catch 
                {
                    error = "Something Was Wrong When Get Services!!!";
                    return null;
                }
            }
        }

        // Get Service By Id
        public Service GetServiceById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var service = context.Services.Where(sv => sv.Id == Id).FirstOrDefault();
                    if (service != null)
                    {
                        error = "Get Service Success!!!";
                    }
                    error = "Service Is Not Exsit!!!";
                    return service;
                }
            }
            catch
            {
                error = "Get Service Failure!!!";
                return null;
            }
        }

        // Add New Service
        public bool AddNewService(
            string Id,
            string Name,
            float Price,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    // Check service
                    var service = this.GetService(Id, Name, Price);
                    if (service != null)
                    {
                        context.Services.Add(service);
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Add Service Success!!!";
                            return true;
                        }
                    }
                    error = "Service Invalid!!!";
                    return false;
                }
            }
            catch
            {
                error = "Add Service Failure!!!";
                return false;
            }
        }

        //UpdataService
        public bool UpdateServiceById(
            string Id,
            string NewName,
            float NewPrice,
            ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var service = context.Services.
                         SingleOrDefault(s => s.Id == Id);
                    if (service != null)
                    {
                        service.Name = NewName;
                        service.Price = NewPrice;
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Update Service Success!!!";
                            return true;
                        }
                        error = "Service Has No Change!!!";
                        return false;
                    }
                    error = "Service Is Not Exsit!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Update Service!!!";
                return false;
            }
        }

        public bool RemoveServiceById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var sv = context.Services.
                        SingleOrDefault(s => s.Id == Id);
                    if (sv != null)
                    {
                        context.Services.Remove(sv);
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Remove Service Success!!!";
                            return true;
                        }
                        error = "Remove Service Failure!!!";
                        return false;
                    }
                    error = "Service Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Remove Service!!!";
                return false;
            }
        }
    }
}
