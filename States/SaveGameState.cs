using GameStateMachine.Commands;
using GameStateMachine.Interfaces;
using GameStateMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.States
{
    public class SaveGameState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private IGame _game;


        public SaveGameState(StateManager manager, IState lastState , IGame game)
        {
            _manager = manager;
            _lastState = lastState;
            _game = game;
        }
        public ICommand GetCommand()
        {
            var command = Console.ReadLine();
            if(command == "back") return new SwitchStateCommand(_manager , _lastState);
            if (command == null) return new InvalidCommand();
            return new SaveGameCommand(command , _game);
        }

        public void Render()
        {
            Console.WriteLine("Enter the right name for save file or type [back] to take back to the previous menu: ");

        }
    }
}
