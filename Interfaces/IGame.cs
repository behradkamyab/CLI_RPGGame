using GameStateMachine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Interfaces
{
    public interface IGame
    {
        public Player Player { get; set; }
        public Dictionary<Guid, IGameObject> GameObjects { get; }

        void AddObjects(IGameObject obj);
        IGameObject GetGameObject(Guid Id);
    }
}
