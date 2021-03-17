using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDiscordBot.Modules
{
    public class ExampleCommand : ModuleBase
    {
        [Command("hello")]
        public async Task HelloCommand()
        {
            var sb = new StringBuilder();

            var user = Context.User;

            sb.AppendLine("You are " + user.Username);
        
            var avatarURL = user.GetAvatarUrl();
            if(avatarURL == null)
            {
                sb.AppendLine("You really need to update your profile picture.");
            }
            else
            {
                sb.AppendLine("Your avatar image is located: " + user.GetAvatarUrl());
            }
            

            await ReplyAsync(sb.ToString());
        }

        [Command("time")]
        public async Task GetCurrentTime()
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

            await ReplyAsync("The current time is now: " + now);
        }

        [Command("8ball")]
        [Alias("ask")]
        public async Task AskEightBall([Remainder]string args = null)
        {
            var reply = new StringBuilder();
            var replies = new List<string>();

            replies.Add("Yes");
            replies.Add("No");
            replies.Add("Maybe");
            replies.Add("Wouldn't you like to know...");

            if(args == null || !args.Contains("?"))
            {
                reply.AppendLine("Sorry, we can't answer a question you didn't ask.");
            }
            else
            {
                var question = args;

                int randomIndex = new Random().Next(replies.Count);
                var answer = replies[randomIndex];

                if (question.Contains("is real"))
                {
                    answer = "I think the better question is, are you real?";
                }else if (question.Contains("what"))
                {
                    answer = "Great question, can you define, what?";
                }

                reply.AppendLine(answer);
            }

            await ReplyAsync(reply.ToString());
        }

    }
}
