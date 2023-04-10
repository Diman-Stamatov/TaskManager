using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager.Core.Interfaces
{
    internal interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}
