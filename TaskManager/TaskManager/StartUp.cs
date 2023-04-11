using System.Net.Http.Headers;
using TaskManager.Models;
using TaskManager.Models.Enums;


namespace TaskManager
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var story = new Story("sadsd", "fsdfd", PriorityType.Low, SizeType.Small, StoryStatusType.Done);
            story.RevertSize();
            
            
            Console.WriteLine(story.Priority);
        }
    }
}