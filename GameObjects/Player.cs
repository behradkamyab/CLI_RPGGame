using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.GameObjects
{
    public class Player : IGameObject
    {
        private readonly List<IPickupable> _inventory;
        public GameObjectType Type { get { return GameObjectType.Player; } }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public Room CurrentRoom { get; set; }

        public List<IPickupable> Inventory { get { return _inventory; } set { } }


        public Player(Guid id)
        {
            Id = id;
            _inventory = new List<IPickupable>();

        }
        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Health);
            writer.Write(CurrentRoom.Id.ToByteArray());
        }

        public void Load(IGame game, BinaryReader reader)
        {
            Name = reader.ReadString();
            Health = reader.ReadInt32();
            var currentRoomId = new Guid(reader.ReadBytes(16));
            CurrentRoom = (Room)game.GetGameObject(currentRoomId);
        }


        public void AddToinventory(IPickupable item)
        {
            _inventory.Add(item);
        }


        public IPickupable GetItemFromInventory(IPickupable item)
        {
            for (var i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i] == item)
                {
                    return _inventory[i];
                }
            }

            return null;
        }


    }
}
