using ChatBotData;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ForschungsArbeit
{
    [LuisModel("e06ff788-ffb6-4345-b41d-bdf5d73f40c3", "e83d8e82abe24481bf1b295c5e17390c")]
    [Serializable]
    public class SimpleLuisDialog : LuisDialog<object>
    {
        [LuisIntent("TeamCount")]
        public async Task getTeamCount(IDialogContext context, LuisResult result)
        {
            Bundesliga bund = new Bundesliga();
            await context.PostAsync($"Es gibt {bund.GetTeamCount()} Manschaften");
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Ich habe keine ahnung von was du sprichst");
            context.Wait(MessageReceived);
        }
    }
}