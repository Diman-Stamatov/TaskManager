using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;
using static TaskManager.Utilities.Validation;
using static TaskManager.Utilities.UtilityMethods;

namespace TaskManager.Models
{
    public class Team : ITeam
    {
        private const int TeamNameMinLength = 5;
        private const int TeamNameMaxLength = 15;

        private string name;
        private IList<IMember> members;
        private IList<IBoard> boards;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, TeamNameMinLength, TeamNameMaxLength);

                this.name = value;
            }
        }

        public IList<IMember> Members
        {
            get
            {
                return new List<IMember>(this.members);
            }
        }

        public IList<IBoard> Boards
        {
            get
            {
                return new List<IBoard>(this.boards);
            }
        }
    }
}
