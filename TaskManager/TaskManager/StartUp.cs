using System.Net.Http.Headers;
using TaskManager.Models;
using TaskManager.Models.Enums;


namespace TaskManager
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var story = new Story("sadsdyhoiuhkjh", "fsdkjnklkfd", PriorityType.Low, SizeType.Small, StoryStatusType.Done);
            story.AdvanceSize();
            story.AdvancePriority();
            story.AdvanceStatus();
            
            
            Console.WriteLine(story.Priority);
        }
    }
}