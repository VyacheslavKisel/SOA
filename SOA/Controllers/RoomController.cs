using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOA.Database;
using SOA.Models;

namespace SOA.Controllers
{
    [ApiController]
    public class RoomController : ControllerBase
    {
        public readonly DatabaseContext _database;

        public RoomController(DatabaseContext database)
        {
            _database = database;

            if (!_database.Rooms.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var room = new Room
                    {
                        Id = i + 1,
                        Number = i + 101,
                        Price = 300 + (i * 25),
                        Volume = "On two person"
                    };

                    database.Rooms.Add(room);
                }
            }

            _database.SaveChanges();
        }

        [HttpGet]
        [Route("rooms")]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            var rooms = _database.Rooms;

            return Ok(rooms);
        }

        [HttpGet]
        [Route("room/{id}")]
        public ActionResult<Room> GetRoom(int id)
        {
            var room = _database.Rooms.Find(id);

            return Ok(room);
        }

        [HttpPost]
        [Route("room/new")]
        public IActionResult AddRoom([FromBody] Room room)
        {
            _database.Add(room);
            _database.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("room/update")]
        public IActionResult UpdateRoom([FromBody] Room room)
        {
            _database.Entry(room).State = EntityState.Modified;
            _database.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("room/delete/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _database.Rooms.Find(id);

            _database.Entry(room).State = EntityState.Deleted;
            _database.SaveChanges();

            return Ok();
        }
    }
}
