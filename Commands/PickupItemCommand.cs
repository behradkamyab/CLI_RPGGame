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
    public class PickupItemCommand : ICommand
    {
        private IGame _game;
        private StateManager _manager;
        private IPickupable _item;
        private Room _room;
        public PickupItemCommand(StateManager manager,IPickupable item , Room room, IGame game)
        {
            _manager = manager;
            _game = game;
            _item = item;
            _room = room;
        }
        public void Execute()
        {
            if(_item != null)
            {
                _item.Pick();
                Console.WriteLine("---------------");
                _game.Player.AddToinventory(_item);
                for(var i =0; i < _room.Items.Count; i++)
                {
                    if (_room.Items[i] == _item)
                    {
                        _room.Items.Remove(_item);
                    }
                }
                Console.WriteLine("the item added to your inventory!");
            }
        }
    }
}
