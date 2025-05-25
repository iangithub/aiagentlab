using System.Threading.Tasks;

namespace SK_Sample;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        await AgentKM.KnowledgeManager.RunAgentConversation("黃仁勳是怎麼創造輝達的？");
    }
}
