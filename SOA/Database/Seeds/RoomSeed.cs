using SOA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.Database.Seeds
{
    internal static class RoomSeed
    {
        internal static readonly ICollection<Room> DataToSeed;

        static RoomSeed()
        {
            DataToSeed = new Collection<Room>();

            for (int i = 0; i < 5; i++)
            {
                var room = new Room
                {
                    Id = ++i,
                    Number = i + 101,
                    Price = 300 + (i * 25),
                    Volume = "On two person"
                };

                DataToSeed.Add(room);
            }
        }
    }
}
