using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Entities;

namespace BUS.Controllers
{

    // Kind Of Room  Controller
    public class KindOfRoomController
    {

        // Create Kind Of Room
        public KindOfRoom CreateKindOfRoom(string Id, String Name, int Max, float Price)
        {
            KindOfRoom k = new KindOfRoom
            {
                Id = Id,
                Name = Name,
                Price = Price,
                Max = Max
            };
            return k;
        }

        // Get All Kind Of Rooms
        public List<KindOfRoom> GetAllKindOfRooms(ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var kindOfRooms = (from kor in context.KindOfRooms.Include("Rooms")
                                       select kor).ToList();
                    error = "Get Kind Of Rooms Success!!!";
                    return kindOfRooms;
                }
            }
            catch
            {
                error = "Something Was Wrong When Get Kind Of Rooms";
                return null;
            }
        }

        // Insert New Kind Of Rom 
        public bool InsertKindOfRooms
        (
            string Id,
            string Name,
            int Max,
            float Price,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    var k = CreateKindOfRoom(Id, Name, Max, Price);
                    context.KindOfRooms.Add(k);
                    context.SaveChanges();
                    error = "Add Kind Of Room Success!!!";
                    return true;
                }
            }
            catch
            {
                error = "Something Was Wrong When Add Kind Of Room!!!";
                return false;
            }
        }

        // Update Customer
        public bool UpdateKindOfRoomById
        (
            string Id,
            string Name,
            string Max,
            string Price,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    var kor = context.KindOfRooms.
                         SingleOrDefault(k => k.Id == Id);
                    if (kor != null)
                    {
                        // Change Data
                        kor.Id = Id;
                        kor.Name = Name;
                        kor.Max = int.Parse(Max);
                        kor.Price = float.Parse(Price);

                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Update Kind Of Room Success!!!";
                            return true;
                        }
                        error = "Kind Of Room Has No Change!!!";
                        return false;
                    }
                    error = "Kind Of Room Is Not Exsit!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Update Kind Of Room!!!";
                return false;
            }
        }

        // Delete KindOfRoom
        public bool RemoveKindOfRoomById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var kor = context.KindOfRooms.
                        SingleOrDefault(k => k.Id == Id);
                    if (kor != null)
                    {
                        context.KindOfRooms.Remove(kor);
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Remove Kind Of Room Success!!!";
                            return true;
                        }
                        error = "Remove Kind Of Room Failure!!!";
                        return false;
                    }
                    error = "Kind Of Room Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Remove Kind Of Room!!!";
                return false;
            }
        }

    }
}
