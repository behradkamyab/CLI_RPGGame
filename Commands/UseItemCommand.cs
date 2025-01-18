using GameStateMachine.GameObjects;
using GameStateMachine.Interfaces;
using GameStateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Commands
{
    public class UseItemCommand : ICommand
    {
        private StateManager _manager;
        private IItem _item;

        private IGame _game;

        public UseItemCommand(StateManager manager, IItem item, IGame game)
        {
            _manager = manager;
            _item = item;

            _game = game;

        }
        public void Execute()
        {
            var item = _item as IUseable;
            if(item != null)
            {
                item.Use();
            }
            else
            {
                Console.WriteLine("This Item is not Usable!");
            }

        }
    }
}
