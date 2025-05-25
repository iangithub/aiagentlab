using System.ComponentModel;
using Azure.AI.Agents.Persistent;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.AzureAI;
using Microsoft.SemanticKernel.ChatCompletion;
using Azure.Identity;

namespace AgentKM
{
    public static class KnowledgeManager
    {
        public static async Task RunAgentConversation(string question)
        {
            var endpoint = new Uri(AppConfiguration.Azure_AI_Foundry_Endpoint);
            PersistentAgentsClient agentsClient = AzureAIAgent.CreateAgentsClient(AppConfiguration.Azure_AI_Foundry_Endpoint, new AzureCliCredential());

            // Define the agent
            PersistentAgent definition = await agentsClient.Administration.GetAgentAsync("asst_dCDNonr1mSEEkV8lGkLVfD5w");
            AzureAIAgent agent = new(definition, agentsClient);
            AzureAIAgentThread agentThread = new(agentsClient);

            ChatMessageContent message = new(AuthorRole.User, question);

            await foreach (ChatMessageContent response in agent.InvokeAsync(message, agentThread))
            {
                Console.WriteLine(response.Content);
            }
        }
    }
}