using GameStateMachine.Models;
using GameStateMachine.States;

namespace GameStateMachine
{
    /// <summary>
    /// This App uses state machines to stimulate the different sections of main menu of a game like main menu , load game , save game
    /// </summary>
    ///


    // allow a user to move from room to room!
    internal class Program
    {
        static void Main(string[] args)
        {


            var manager = new StateManager();
            var game = new Game();







            manager.Run(new MainMenuState(manager, game));

            //var game = new Game();

            //var room1 = new Room(Guid.NewGuid());
            //room1.Name = "Room 1";
            //room1.Description = "Room 1 Description";

            //var room2 = new Room(Guid.NewGuid());
            //room2.Name = "Room 2";
            //room2.Description = "Room 2 Description";


            //var player = new Player(Guid.NewGuid());
            //player.Name = "Behrad";
            //player.Health = 100;


            //game.Player = player;
            //game.Player.CurrentRoom = room1;


            //game.AddObjects(room1);
            //game.AddObjects(room2);
            //game.AddObjects(player);


            //var persistence = new GameFilePersistence();

            //persistence.SaveGame("game.file", game);
            //var gameLoaded = persistence.LoadGame("game.file");

            //foreach(var gameObj in gameLoaded.GameObjects.Values)
            //{
            //    var room = gameObj as Room;

            //    if(room != null)
            //    {
            //        Console.WriteLine(room.Name);
            //        Console.WriteLine(room.Description);
            //    }
            //    var thePlayer = gameObj as Player;
            //    if (thePlayer != null)
            //    {
            //        Console.WriteLine(thePlayer.Name);
            //        Console.WriteLine(thePlayer.Health);
            //        Console.WriteLine(player.CurrentRoom.Name);
            //    }
            //}



        }
    }
}
