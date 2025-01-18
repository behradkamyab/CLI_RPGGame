//using GameStateMachine.Interfaces;
//using GameStateMachine.Models;
//using GameStateMachine.States;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameStateMachine.Commands
//{
//    public class StartGameCommand : ICommand
//    {
//        private string _playerName;
//        private StateManager _manager;

//        public StartGameCommand( StateManager manager ,string name)
//        {
//            _playerName = name;
//            _manager = manager;
//        }

//        public void Execute()
//        {
//            var game = new Game();
//            var player = new Player(Guid.NewGuid());
//            player.Name = _playerName;


//            var room1 = new Room(Guid.NewGuid());
//            room1.Name = "Room 1";
//            room1.Description = " This Is Room 1";

//            var room2 = new Room(Guid.NewGuid());
//            room2.Name = "Room 2";
//            room2.Description = " This Is Room 2";

//            game.Player = player;
//            game.Player.CurrentRoom = room1;


//            game.AddObjects(player);
//            game.AddObjects(room1);
//            game.AddObjects(room2);

//            var command = new SwitchStateCommand(_manager, new RoomState(_manager, room1));

//        }
//    }
//}
