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
    /// <summary>
    ///   Show the main menu of game that include save file , load game , help and start new game
    /// </summary>
    public class MainMenuState : IState
    {

        private StateManager _manager;
        private IGame _game;

        public MainMenuState(StateManager manager ,IGame game)
        {
            _manager = manager;
            _game = game;
        }

        public ICommand GetCommand()
        {
            var command = Console.ReadLine();
            if(command == "new")
            {
                return new SwitchStateCommand(_manager, new NewGameState(_manager, this , _game));
            }
            else if(command == "load")
            {
                return new SwitchStateCommand(_manager, new LoadGameState(_manager,this, _game));
            }else if(command == "save")
            {
                return new SwitchStateCommand(_manager, new SaveGameState(_manager, this , _game));
            }
            else if(command == "help")
            {
                return new HelpCommand();
            }
            else
            {
                return new InvalidCommand();
            }
        }

        public void Render()
        {
            Console.WriteLine("[new] - Start a new game");
            Console.WriteLine("[load] - Load Game");
            Console.WriteLine("[save] - Save Game");
            Console.WriteLine("[help] - Show Help!");
        }
    }
}
