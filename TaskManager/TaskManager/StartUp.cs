using System.Net.Http.Headers;
using TaskManager.Models;


namespace TaskManager
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Member m = new Member("rfffffffr");
            Console.WriteLine(m);
            Comment coment = new Comment(m.Name, String.Empty);
        }
    }
};