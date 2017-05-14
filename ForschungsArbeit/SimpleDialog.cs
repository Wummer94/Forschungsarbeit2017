using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using ChatBotData;

namespace ForschungsArbeit
{
    [Serializable]
    public class SimpleDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ActivityReceivedAsync);
        }

        private async Task ActivityReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            Bundesliga bund = new Bundesliga();
            if (activity.Text.StartsWith("Wie") && activity.Text.Contains("viele") && activity.Text.Contains("Manschaften") || activity.Text.StartsWith("Wie") && activity.Text.Contains("viele") && activity.Text.Contains("Teams"))
            {             
                await context.PostAsync($"Es gibt { bund.GetTeamCount() } Teams");
            }
            else if (activity.Text.StartsWith("Welches") || activity.Text.StartsWith("Welche") || activity.Text.StartsWith("Wer"))
            {
                if (activity.Text.Contains("besten") || activity.Text.Contains("höchsten") || activity.Text.Contains("großartigsten") || activity.Text.Contains("ersten") || activity.Text.Contains("erster") || activity.Text.Contains("beste") || activity.Text.Contains("1 Platz") || activity.Text.Contains("erster Platz"))
                {
                    await context.PostAsync($"Auf dem ersten Platz ist {bund.GetHighestRatedTeam()}");
                }
                else if (activity.Text.Contains("schlechtesten") || activity.Text.Contains("tiefsten") || activity.Text.Contains("letzten") || activity.Text.Contains("letzter"))
                {
                    await context.PostAsync($"Diese Jahr ist {bund.GetLowestRatedTeam()} letzter.");
                }
            }
            //else if (activity.Text.Contains("Wer muss diese Jahr Relegation Spielen"))
            //{
            //    await context.PostAsync($"Diese Jahr muss {bund.GetSecondLowestTeam()} Relegation spielen");
            //}
            //else if (activity.Text.Contains("kommt"))
            //{
            //    await context.PostAsync($"In die Championsliga kommt {bund.GetTopFourTeams().ToString()}");
            //}

            context.Wait(ActivityReceivedAsync);
        }
    }
}