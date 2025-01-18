using GameStateMachine.Interfaces;
using GameStateMachine.GameObjects;
using GameStateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Commands
{
    public class NewGameCommand : ICommand
    {
        private string _name;
        private IGame _game;
        private StateManager _manager;
        private IState _lastState;

        public NewGameCommand(string name,IState lastState , StateManager manager ,IGame game)
        {
            _name = name;
            _manager = manager;
            _game = game;
            _lastState = lastState;
        }
        public void Execute()
        {
            var chair = new Chair("chair" , Guid.NewGuid());
            var bigChair = new Chair("big chair" , Guid.NewGuid());
            var key = new Key("basic key", Guid.NewGuid());
            var redKey = new RedKey("red key", Guid.NewGuid());



            var home = new Room(Guid.NewGuid()) { Name = "Home", Description = " This is your Home!" };
            home.Items.Add(chair);
            home.Items.Add(bigChair);
            home.Items.Add(key);
            home.Items.Add(redKey);
            _game.AddObjects(home);
            _game.AddObjects(chair);
            _game.AddObjects(bigChair);
            _game.AddObjects(key);
            _game.AddObjects(redKey);


            var engineering = new Room(Guid.NewGuid()) { Name = "Engineering", Description = "This is Engineering room" };
            _game.AddObjects(engineering);

            var bridge = new Room(Guid.NewGuid()) { Name = "Bridge", Description = "This is the bridge that u can pass!" };
            _game.AddObjects(bridge);

            var commonRoom = new Room(Guid.NewGuid()) { Name = "Common Room", Description = "nothing fancy here in this room!" };
            _game.AddObjects(commonRoom);






            var player = new Player(Guid.NewGuid());
            player.CurrentRoom = home;
            player.Name = _name;
            _game.Player = player;


            _game.AddObjects(player);


            home.ConnectRoom("north", bridge);
            home.ConnectRoom("south", engineering);
            bridge.ConnectRoom("south", home);
            bridge.ConnectRoom("east", commonRoom);
            engineering.ConnectRoom("north", home);
            commonRoom.ConnectRoom("west", bridge);

            var command = new SwitchStateCommand(_manager, new RoomState(_manager,_lastState, _game , home));
            command.Execute();


        }
    }
}
