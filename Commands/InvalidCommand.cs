using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Commands
{
    public class InvalidCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Its an invalid command!");
        }
    }
}
