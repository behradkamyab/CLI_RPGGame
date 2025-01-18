using GameStateMachine.Interfaces;
using GameStateMachine.GameObjects  ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Models
{
    public class GameFilePersistence
    {
        public void SaveGame(string fileName , IGame game)
        {
            using(var bw = new BinaryWriter(File.Open(fileName + ".game", FileMode.OpenOrCreate)))
            {
                bw.Write(game.GameObjects.Count);

                foreach(var gameObj in game.GameObjects.Values)
                {
                    bw.Write((int)gameObj.Type);
                    bw.Write(gameObj.Id.ToByteArray());
                }

                foreach(var gameObj in game.GameObjects.Values)
                {
                    gameObj.Save(bw);
                }
            }
        }


        public Game LoadGame(string fileName)
        {
            var game = new Game();

            using(var br = new BinaryReader(File.Open(fileName , FileMode.Open)))
            {
                var gameObjects = new List<IGameObject>();

                var gameObjCount = br.ReadInt32();

                for(var i = 0; i < gameObjCount; i++)
                {
                    var type = (GameObjectType)br.ReadInt32();
                    var id = new Guid(br.ReadBytes(16));
                    //var name = br.ReadString();
                    IGameObject obj = null;

                    switch (type)
                    {
                        case GameObjectType.Room: obj = new Room(id); break;
                        case GameObjectType.Player: obj = game.Player = new Player(id); break;
                        case GameObjectType.Item: obj = new Item("",id); break;
                    }
                    gameObjects.Add(obj);
                    game.AddObjects(obj);
                }
                foreach(var gameObj in gameObjects)
                {
                    gameObj.Load(game, br);
                }
            }

            return game;
        }
    }
}
