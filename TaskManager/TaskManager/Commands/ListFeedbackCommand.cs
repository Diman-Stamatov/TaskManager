using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class ListFeedbackCommand :BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0;
        //Трябва да решим, колко параметъра ще приема тази команда

        public ListFeedbackCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            return "";
        }
    }
}
