using GameStateMachine.Commands;
using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.States
{
    public class NewGameState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private IGame _game;


        public NewGameState(StateManager manager, IState lastState , IGame game)
        {
            _manager = manager;
            _lastState = lastState;
            _game = game;
        }
        public ICommand GetCommand()
        {
            var name = Console.ReadLine();
            if (name == null) return new InvalidCommand();

            return new NewGameCommand(name, this, _manager ,_game);
        }

        public void Render()
        {
            Console.WriteLine("Enter your name to start the game: ");
        }
    }
}
