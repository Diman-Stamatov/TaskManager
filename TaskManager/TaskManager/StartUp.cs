using TaskManager.Models;


namespace TaskManager
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Member member = new Member("Ivan");
            member.AddActivityHistory("Join the team");
            Console.WriteLine(member);
            Console.WriteLine(String.Join (" ",member.ActivityHistory));

        }
    }
};