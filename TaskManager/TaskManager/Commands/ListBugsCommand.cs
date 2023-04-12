using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;
using TaskManager.Models;

namespace TaskManager.Commands
{
    public class ListBugsCommand : BaseCommand
    {
        public ListBugsCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var test = Repository.Tasks.OfType<Bug>().ToList();
            List<Bug> bugsActive = test.
                Where(bug => bug.Status == BugStatusType.Active).
                OrderBy(bug => bug.Title).
                ThenBy(bug => bug.Priority == PriorityType.High).
                ThenBy(bug => bug.Priority == PriorityType.Medium).
                ThenBy(bug => bug.Priority == PriorityType.Low).
                ThenBy(bug => bug.Severity == SeverityType.Critical).
                ThenBy(bug => bug.Severity == SeverityType.Major).
                ThenBy(bug => bug.Severity == SeverityType.Minor).
                ToList();

            List<Bug> bugsFixed = test.
                Where(bug => bug.Status == BugStatusType.Fixed).
                OrderBy(bug => bug.Title).
                ThenBy(bug => bug.Priority == PriorityType.High).
                ThenBy(bug => bug.Priority == PriorityType.Medium).
                ThenBy(bug => bug.Priority == PriorityType.Low).
                ThenBy(bug => bug.Severity == SeverityType.Critical).
                ThenBy(bug => bug.Severity == SeverityType.Major).
                ThenBy(bug => bug.Severity == SeverityType.Minor).
                ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Bug bug in bugsActive)
            {
                stringBuilder.Append(bug);
                StringGenerator('*', 15);
            }

            foreach (Bug bug in bugsFixed)
            {
                stringBuilder.Append(bug);
                StringGenerator('*', 15);
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
