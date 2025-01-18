using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Interfaces
{
    public interface IItem :IGameObject
    {
         string Name { get; set; }
    }
}
