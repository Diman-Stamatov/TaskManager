using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands.Contracts;

namespace TaskManager.Core.Interfaces
{
   public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}
