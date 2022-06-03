using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DTO;
using DTO.Entities;

namespace BUS.Controllers
{
    // Room Controller
    public class RoomController
    {
        // Create Room Instance
        private Room CreateRoom(
            string Id,
            KindOfRoom kindOfRoom,
            RoomStatus roomStatus,
            string Name,
            string Description = ""
        )
        {
            var room = new Room
            {
                Id = Id,
                Name = Name,
                Description = Description,
                KindOfRoom = kindOfRoom,
                RoomStatus = roomStatus,
            };
            return room;
        }

        private void LoadReference(Context c, Room room)
        {
            c.Entry(room).Reference("KindOfRoom").Load();
            c.Entry(room).Reference("RoomStatus").Load();
        }

        // Get All Rooms
        public List<Room> GetAllRooms(ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rooms = context.Rooms.ToList();
                    foreach (var room in rooms)
                    {
                        LoadReference(context, room);
                        /*var e = context.Entry(room);
                        e.Reference("KindOfRoom").Load();
                        e.Reference("RoomStatus").Load();*/
                    }
                    error = "Get Rooms Success!!!";
                    return rooms;
                }
            }
            catch
            {
                error = "Something Was Wrong When Get Rooms!!!";
                return null;
            }
        }

        // Insert Room
        public bool InsertRoom(
            ref string error,
            string Id,
            string kindOfRoomId,
            string roomStatusId,
            string Name,
            string Description = "")
        {
            try
            {
                using (var context = new Context())
                {
                    // Create Room
                    //var room = GetRoom(Id, kindOfRoom, roomStatus, Name, Description);

                    var room = new Room
                    {
                        Id = Id,
                        Description = Description,
                        KindOfRoomId = kindOfRoomId,
                        RoomStatusId = roomStatusId,
                        Name = Name,
                    };
                    context.Rooms.Add(room);
                    var e = context.Entry(room);
                    e.Reference("KindOfRoom");
                    e.Reference("RoomStatus");
                    context.SaveChanges();
                    error = "Add Room Success!!!";
                    return true;
                }
            }
            catch
            {
                error = "Something Was Wrong When Add Room!!!";
                //error = ex.Message;
                return false;
            }
        }

        // Update Room
        public bool UpdateRoom
        (
            ref string error,
            string Id,
            string kindOfRoomId,
            string roomStatusId,
            string Name,
            string Description = ""
        )
        {
            try
            {
                using (var context = new Context())
                {
                    // Find Room
                    var room = context.Rooms.
                        Where(r => r.Id == Id).FirstOrDefault();

                    /*  var e = context.Entry(room);
                      e.State = System.Data.Entity.EntityState.Modified; */

                    // Update Room
                    if (room != null)
                    {
                        room.Name = Name;
                        room.Description = Description;
                        room.RoomStatusId = roomStatusId;
                        room.KindOfRoomId = kindOfRoomId;
                        var numOfstauts = context.SaveChanges();
                        if (numOfstauts > 0)
                        {
                            error = "Update Room Success!!!";
                            return true;
                        }
                        error = "Room Has No Change!!!";
                        return false;
                    }
                    error = "Room Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong When Update Room!!!";
                return false;
            }
        }

        // Delete Room
        public bool RemoveRoom(ref string error, string Id)
        {
            try
            {
                using (var context = new Context())
                {
                    // Find Room
                    var room = context.Rooms.
                        Where(r => r.Id == Id).FirstOrDefault();

                    // Remove If Room Exist
                    if (room != null)
                    {
                        context.Rooms.Remove(room);
                        context.SaveChanges();
                        error = "Room Has Deleted!!!";
                        return true;
                    }
                    error = "Room Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Sonmething Was Wrong When Remove Room!!!";
                return false;
            }
        }

        // Get Room By StatusId
        public List<Room> GetRoomsByRoomStatusId(string roomStatusId, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var rooms = context.Rooms.
                        Where(r => r.RoomStatusId == roomStatusId).ToList();
                    foreach (var room in rooms)
                    {
                        var e = context.Entry(room);
                        e.Reference("KindOfRoom").Load();
                        e.Reference("RoomStatus").Load();
                    }
                    error = "Get All Rooms Success!!!";
                    return rooms;
                }
            }
            catch
            {
                error = "Something Was Wrong When Get Rooms!!!";
                return null;
            }
        }
    }
}
