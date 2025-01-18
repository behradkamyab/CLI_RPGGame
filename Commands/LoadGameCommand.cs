using GameStateMachine.Interfaces;
using GameStateMachine.Models;
using GameStateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Commands
{
    public class LoadGameCommand : ICommand
    {
        private readonly string _fileName;
        private StateManager _manager;
        private IState _lastState;
        public LoadGameCommand(string input, IState lastState , StateManager manager)
        {
            _manager = manager;
            _fileName = input;
            _lastState = lastState;
        }
        public void Execute()
        {
            Console.WriteLine("Loading {0}..." , _fileName);
            var gameFile = new GameFilePersistence();
            var game = gameFile.LoadGame(_fileName);
            if (game != null)
            {
                var command = new SwitchStateCommand(_manager, new RoomState(_manager,_lastState ,game , game.Player.CurrentRoom));
                command.Execute();
            }
            else
            {
                Console.WriteLine("Something wrong happened!");
            }
        }
    }
}
