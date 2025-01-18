using GameStateMachine.Interfaces;
using GameStateMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.GameObjects
{
    public class Room : IGameObject
    {
        private  Dictionary<string, RoomConnection> _connections;
        private List<IItem> _items;


        public GameObjectType Type { get { return GameObjectType.Room; } }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public IEnumerable<RoomConnection> Connections { get { return _connections.Values; } }
        public List<IItem> Items { get { return _items; } }

        public Room(Guid id)
        {
            Id = id;
            _connections = new Dictionary<string, RoomConnection>();
            _items = new List<IItem>();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Description);
            writer.Write(_connections.Count);
            foreach(var connection in _connections)
            {

                writer.Write(connection.Key);
                writer.Write(connection.Value.Room.Id.ToByteArray());
            }

            writer.Write(_items.Count);

            foreach(var item in _items)
            {
                writer.Write(item.Id.ToByteArray());
            }
        }

        public void Load(IGame game, BinaryReader reader)
        {
            Name = reader.ReadString();
            Description = reader.ReadString();
            var connectionCount = reader.ReadInt32();
            _connections.Clear();
            for(var i = 0; i < connectionCount; i++)
            {
                string direction = reader.ReadString();
                var roomId = new Guid(reader.ReadBytes(16));
                var room = game.GetGameObject(roomId) as Room;
                RoomConnection roomConnection = new RoomConnection(room, direction);
                _connections.Add(direction, roomConnection);


            }



            var itemsCount = reader.ReadInt32();
            _items.Clear();
            for(var i = 0; i < itemsCount; i++)
            {
                var itemId = new Guid(reader.ReadBytes(16));
                Item item = game.GetGameObject(itemId) as Item;
                _items.Add(item);

            }


        }

        public void ConnectRoom(string direction, Room room)
        {
            _connections[direction] = new RoomConnection(room, direction);
        }


        public Room GetConnectedRoom(string direction)
        {
            return _connections[direction].Room;
        }


    }
}
