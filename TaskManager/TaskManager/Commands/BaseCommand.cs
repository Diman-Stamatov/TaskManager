using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands.Interfaces;


namespace TaskManager.Commands
{
    internal class BaseCommand : ICommand
    {
        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
