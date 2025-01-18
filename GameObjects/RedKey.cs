using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.GameObjects
{
    public class RedKey : Key, IUseable , IPickupable
    {
        public string Name { get; set; }

        public Guid Id { get; private set; }

        public GameObjectType Type { get { return GameObjectType.Item; } }
        public RedKey(string name, Guid id) : base(name, id)
        {
            Name = name;
            Id = id;
        }

        public override void Use()
        {
            Console.WriteLine("Red key is used!");
        }
        public void Load(IGame game, BinaryReader reader)
        {
            Name = reader.ReadString();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
        }

        public void Pick()
        {
            Console.WriteLine("this red key u need to pickup asap!");
        }
    }
}
