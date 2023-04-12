﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ListAssigneesCommand : BaseCommand
    {
        public ListAssigneesCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var assignees = Repository.Members.
                Where(member => member.IsAssignedToATeam==true).
                OrderBy(member => member.Name).
                ToList();

            if (assignees.Count == 0 )
            {
                return "No Tasks are assigned!";
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var assignee in assignees)
            {
                stringBuilder.Append(assignee);
                StringGenerator('*', 15);
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
