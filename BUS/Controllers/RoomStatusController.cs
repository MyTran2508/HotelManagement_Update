using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DTO.Entities;

namespace BUS.Controllers
{
    public class RoomStatusController
    {
        // Create Room Status
        public RoomStatus CreateRoomStatus(string Id, string Name)
        {
            return new RoomStatus { Id = Id, Name = Name };
        }

        // Get All RoomStatus
        public List<RoomStatus> GetRoomStatuses(ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var roomStatuses = (from rs in context.RoomStatuses.Include("Rooms")
                                        select rs).ToList();
                    //context.Entry(roomStatuses).Collection()
                    error = "Get Room Statuses Success!!!";
                    return roomStatuses;
                }
            }
            catch
            {
                error = "Something Was Wrong When Get Room Statuses!!!";
                return null;
            }
        }

        // Create Room Status
        public bool InsertRoomStatus(string Id, string Name, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rs = CreateRoomStatus(Id, Name);
                    context.RoomStatuses.Add(rs);
                    context.SaveChanges();
                    error = "Room Status Has Created!!!";
                    return true;
                }
            }
            catch
            {
                error = "Something Was Wrong When Create Room Status!!!";
                return false;
            }

        }

        // Update Room Status
        public bool UpdateRoomStatusById(string Id, string NewName, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rs = context.RoomStatuses.Find(Id);
                    if (rs != null)
                    {
                        rs.Name = NewName;
                        context.SaveChanges();
                        error = "Room Status Has Updated!!!";
                        return true;
                    }
                    error = "Room Status Is Not Exist!!!";
                    return false;

                }
            }
            catch
            {
                error = "Something Was Wrong When Update Room Status!!!";
                return false;
            }
        }

        // Get Room Status By Id
        public RoomStatus GetRoomStatusById(string Id)
        {
            try
            {
                using (var context = new Context())
                {
                    var rs = context.RoomStatuses.
                        Where(r => r.Id == Id).FirstOrDefault();
                    return rs;
                }
            }
            catch
            {
                return null;
            }
        }


        // Delete Room Status
        public bool RemoveRoomStatusById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rs = context.RoomStatuses.Find(Id);
                    if (rs != null)
                    {
                        context.RoomStatuses.Remove(rs);
                        context.SaveChanges();
                        error = "Room Status Has Deleted!!!";
                        return true;
                    }
                    error = "Room Status Is Not Exist!!!";
                    return false;

                }
            }
            catch
            {
                error = "Something Was Wrong When Delete Room Status!!!";
                return false;
            }
        }

    }
}
