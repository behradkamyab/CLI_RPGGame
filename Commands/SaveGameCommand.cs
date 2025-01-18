using GameStateMachine.Interfaces;
using GameStateMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Commands
{
    public class SaveGameCommand : ICommand
    {
        private string _name;
        private IGame _game;
        public SaveGameCommand(string name , IGame game)
        {
            _name = name;
            _game = game;
        }

        public void Execute()
        {
            var gp = new GameFilePersistence();
            gp.SaveGame(_name, _game);
            Console.WriteLine("Game saved successfully!");

        }
    }
}
