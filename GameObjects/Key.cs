using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.GameObjects
{
    public class Key : Item ,IUseable , IPickupable
    {
        public string Name { get; set; }

        public Guid Id { get; private set; }

        public GameObjectType Type { get { return GameObjectType.Item; } }



        public Key(string name, Guid id) : base(name , id)
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

        public virtual void Use()
        {
            Console.WriteLine("This key is used!");
        }

        public void Pick()
        {
            Console.WriteLine("U can pick this key!");
        }
    }
}
