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
    /// There is a file directory with some example files that will be in a list of files and will be showed to user and user can choose one.
    /// </summary>
    public class LoadGameState : IState
    {
        private string[] _list;
        private StateManager _manager;
        private IState _lastState;
        private IGame _game;


        public LoadGameState(StateManager manager , IState lastState , IGame game)
        {
            _manager = manager;
            _lastState = lastState;
            _game = game;
        }

        public ICommand GetCommand()
        {
            var command = Console.ReadLine();
            if(command == "back")
            {
                return new SwitchStateCommand(_manager , _lastState);
            }
            else
            {
                int validCommandInInt;
                bool validCommand = int.TryParse(command , out validCommandInInt);
                if (validCommand)
                {
                    if (validCommandInInt < 0 || validCommandInInt > _list.Length)
                    {
                        return new InvalidCommand();
                    }
                    else
                    {
                        string input = _list[validCommandInInt - 1];
                        return new LoadGameCommand(input, this , _manager);
                    }
                }
                else
                {
                    return new InvalidCommand();
                }


            }

        }

        public void Render()
        {
            _list = Helper.LoadFile("G:\\GAME-DEV\\Projects\\RPGGame\\GameStateMachine\\bin\\Debug\\net8.0");


            Console.WriteLine("-----------------------");

            for (int i = 0; i < _list.Length; i++)
            {
                Console.WriteLine($"{i + 1}." + _list[i]);
            }


            Console.WriteLine("-----------------------");

            Console.WriteLine("Choose one number from the given list to load or type [back] to go back to previous menu:");



        }




    }

}
