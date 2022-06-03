using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS.Controllers
{
    public class ReservationController
    {
        //private Reservation CreateReservation(
        //   string Id,
        //   Employee employeeId,
        //   Room roomId,
        //   Customer customerId,
        //   DateTime DateIn,
        //   DateTime DateOut,
        //   string status = "Chưa Thanh Toán"
        // )
        //{
        //    var reservation = new Reservation
        //    {
        //        Id = Id,
        //        EmployeeId = employeeId,
        //        RoomId = roomId,
        //        CustomerId = customerId,
        //        DateIn = DateIn,
        //        DateOut = DateOut,
        //        Status = status

        //    };
        //    return reservation;
        //}

        private void LoadReference(Context c, Reservation reservation)
        {
            c.Entry(reservation).Reference("Employee").Load();
            c.Entry(reservation).Reference("Room").Load();
            c.Entry(reservation).Reference("Customer").Load();

        }

        // Get All Reservations
        public List<Reservation> GetAllReservations(ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var reservations = context.Reservations.ToList();
                    foreach (var re in reservations)
                    {
                        LoadReference(context, re);
                        /*var e = context.Entry(room);
                        e.Reference("KindOfRoom").Load();
                        e.Reference("RoomStatus").Load();*/
                    }
                    error = "Get Reservations Success!!!";
                    return reservations;
                }
            }
            catch
            {
                error = "Something Was Wrong When Get Reservations!!!";
                return null;
            }
        }
        // Insert Reservation
        public bool InsertReservation(
            ref string error,
            string Id,
            string EmployeeId,
            string RoomId,
            string CustomerId,
            DateTime DateIn,
            DateTime DateOut,
            string Status)
        {
            try
            {
                using (var context = new Context())
                {
                    var reservation = new Reservation
                    {
                        Id = Id,
                        EmployeeId = EmployeeId,
                        RoomId = RoomId,
                        CustomerId = CustomerId,
                        DateIn = DateIn,
                        DateOut = DateOut,
                        Status = Status

                    };
                    if (DateOut >= DateIn)
                    {
                        context.Reservations.Add(reservation);
                        var e = context.Entry(reservation);
                        e.Reference("Employee");
                        e.Reference("Room"); ;
                        e.Reference("Customer");
                        context.SaveChanges();
                        error = "Add Reservation Success!!!";
                        return true;
                    }
                    else
                        error = "Invalid DateIn!!!";
                        return false;
                }
            }
            catch 
            {
                error = "Something Was Wrong When Add Reservation!!!";
                return false;
            }
        }

        // Update Reservation
        public bool UpdateReservation
        (
            ref string error,
            string Id,
            string NewEmployeeId,
            string NewRoomId,
            string NewCustomerId,
            DateTime DateIn,
            DateTime DateOut
        )
        {
            try
            {
                using (var context = new Context())
                {
                    // Find Reservation
                    var reservation = context.Reservations.
                        Where(r => r.Id == Id).FirstOrDefault();


                    // Update Reservation
                    if (reservation != null)
                    {
                        reservation.EmployeeId = NewEmployeeId;
                        reservation.RoomId = NewRoomId;
                        reservation.CustomerId = NewCustomerId;
                        reservation.DateIn = DateIn;
                        reservation.DateOut = DateOut;
                        var numOfstauts = context.SaveChanges();
                        if (numOfstauts > 0)
                        {
                            error = "Update Reservation Success!!!";
                            return true;
                        }
                        error = "Reservation Has No Change!!!";
                        return false;
                    }
                    error = "Reservation Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Update Reservation!!!";
                return false;
            }
        }
        // Delete Reservation
        public bool RemoveReservation(ref string error, string Id)
        {
            try
            {
                using (var context = new Context())
                {
                    // Find Reservation
                    var reservation = context.Reservations.
                        Where(r => r.Id == Id).FirstOrDefault();


                    // Remove if Reservation exit
                    if (reservation != null)
                    {
                        context.Reservations.Remove(reservation);
                        context.SaveChanges();
                        error = "Reservion Has Delete!!!";
                        return true;
                    }
                    error = "Reservation Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Sonmething Was Wrong When Remove Reservation!!!";
                return false;
            }
        }
        //Get Reservation By Status
        public List<Reservation> GetAllReservationsByStatus(string Status, ref string error)
        {
            using (var context = new Context())
            {
                var reservation = context.Reservations.Where(re => re.Status == Status).ToList();

                if (reservation.Count() > 0)
                {
                    error = "Get Reservations By Status Success!!!";
                    return reservation;
                }
                else
                    error = "R Is Not Exsit!!!";
                return null;
            }
        }
    }
}
