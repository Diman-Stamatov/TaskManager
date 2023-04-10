using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public class Comment : IComment
    {
        public Comment(string author, string content)
        {
            Author = author;
            Content = content;
        }
        public string Author { get; }
        //Тук ще подаваме Member.Name, за да идва като string
        public string Content { get; }
    }
}
