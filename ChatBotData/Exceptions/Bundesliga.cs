using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotData
{
    public class Bundesliga
    {
        private static Dictionary<string, int> Teams;

        public Bundesliga()
        {
            if (Teams == null || Teams.Count == 0)
            {
                InitalizeTeams(); 
            }
        }

        private void InitalizeTeams()
        {
            Teams = new Dictionary<string, int>();
            Teams.Add("Bayern Münschen", 1);
            Teams.Add("RB Leipzig", 2);
            Teams.Add("1899 Hoffenheim", 3);
            Teams.Add("Borussia Dortmund", 4);
            Teams.Add("Hertha BSC", 5);
            Teams.Add("Werder Bremen", 6);
            Teams.Add("SC Freiburg", 7);
            Teams.Add("1. FC Köln", 8);
            Teams.Add("Bor. Mönchengladbach", 9);
            Teams.Add("FC Schalke 04", 10);
            Teams.Add("Eintracht Frankfurt", 11);
            Teams.Add("Bayer Leverkusen", 12);
            Teams.Add("FC Augsburg", 13);
            Teams.Add("1. FSV Mainz 05", 14);
            Teams.Add("VfL Wolfsburg", 15);
            Teams.Add("Hamburger SV", 16);
            Teams.Add("FC Ingolstadt 04", 17);
            Teams.Add("SV Darmstadt 98", 18);
        }

        public List<string> GetTeams()
        {
            var sorted = Teams.OrderBy(x => x.Value);
            List<string> orderdTeams = new List<string>();
            foreach (var e in sorted)
            {
                orderdTeams.Add(e.Key);
            }

            return orderdTeams;
        }

        public int GetTeamCount()
        {
            return Teams.Count;
        }

        public string GetHighestRatedTeam()
        {
            var sorted = Teams.OrderBy(x => x.Value);
            return sorted.First().Key;
        }

        public List<string> GetTopFourTeams()
        {
            var sorted = Teams.OrderBy(x => x.Value);
            List<string> firstFour = new List<string>();
            firstFour.Add(sorted.ElementAt(0).Key);
            firstFour.Add(sorted.ElementAt(1).Key);
            firstFour.Add(sorted.ElementAt(2).Key);
            firstFour.Add(sorted.ElementAt(3).Key);
            return firstFour;
        }

        public List<string> GetSecondLowestTeam()
        {
            var sorted = Teams.OrderBy(x => x.Value);
            List<string> rele = new List<string>();
            rele.Add(sorted.ElementAt(16).Key);
            return rele;
        }

        public string GetLowestRatedTeam()
        {
            var sorted = Teams.OrderBy(x => x.Value);
            return sorted.Last().Key;
        }

    }
}
