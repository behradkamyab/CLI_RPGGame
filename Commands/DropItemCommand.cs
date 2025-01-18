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
    public class DropItemCommand : ICommand
    {
        private IGame _game;
        private StateManager _manager;
        private IPickupable _item;
        private Room _currentRoom;
        public DropItemCommand(StateManager manager, IPickupable item, Room currentRoomPlayer, IGame game)
        {
            _manager = manager;
            _game = game;
            _item = item;
            _currentRoom = currentRoomPlayer;
        }
        public void Execute()
        {
            for(var i = 0; i < _game.Player.Inventory.Count; i++)
            {
                if (_game.Player.Inventory[i] == _item)
                {
                    _game.Player.Inventory.Remove(_item);
                    _currentRoom.Items.Add(_item);
                }
            }


            Console.WriteLine("Item dropped to the {0}!" , _currentRoom);

        }
    }
}
