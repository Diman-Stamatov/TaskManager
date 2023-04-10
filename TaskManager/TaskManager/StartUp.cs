using TaskManager.Models;


namespace TaskManager
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Member m = new Member("rrr");
            Console.WriteLine(m);
        }
    }
};