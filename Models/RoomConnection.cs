using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStateMachine.GameObjects;

namespace GameStateMachine.Models
{
    public class RoomConnection
    {
        public Room Room { get; set; }
        public string Direction { get; set; }

        public RoomConnection(Room room, string direction)
        {
            Room = room;
            Direction = direction;
        }
    }
}
