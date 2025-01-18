using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.GameObjects
{
    public class Item : IItem
    {
        public string Name { get; set; }

        public Guid Id { get; private set; }

        public GameObjectType Type { get { return GameObjectType.Item; } }

        public Item(string name , Guid id)
        {
            Name = name;
            Id = id;
        }
        public void Load(IGame game, BinaryReader reader)
        {
            Name = reader.ReadString();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
        }
    }
}
