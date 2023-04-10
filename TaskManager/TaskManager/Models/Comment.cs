using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public class Comment : IComment
    {
        public string Author => throw new NotImplementedException();

        public string Content => throw new NotImplementedException();
    }
}
