using GameStateMachine.GameObjects;
using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Models
{
    public class Game :IGame
    {

        public Player Player { get; set; }
        public Dictionary<Guid,IGameObject> GameObjects { get; private set; }
        public Game()
        {
            GameObjects = new Dictionary<Guid, IGameObject>();

        }

        public void AddObjects(IGameObject obj)
        {
            GameObjects.Add(obj.Id,obj);
        }

        public IGameObject GetGameObject(Guid Id)
        {
            return GameObjects[Id];
        }
    }
}
