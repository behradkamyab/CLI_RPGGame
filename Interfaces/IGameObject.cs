using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Interfaces
{
     public interface IGameObject
    {
        Guid Id { get;  }
        GameObjectType Type { get; }

        void Save(BinaryWriter writer);
        void Load(IGame game , BinaryReader reader);
    }
}
