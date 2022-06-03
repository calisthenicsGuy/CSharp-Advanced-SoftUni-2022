using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    internal class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();
        }

        public List<Player> Roster 
        { 
            get => this.roster;
            set => this.roster = value;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count 
        { 
            get => this.Roster.Count;
        }

        public void AddPlayer(Player player)
        {
            if (this.Roster.Count + 1 > this.Capacity)
            {
                return;
            }

            this.Roster.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            Player targetPlayer = GetPlayer(this.Roster, name);

            if (targetPlayer == null)
            {
                return false;
            }

            this.Roster.Remove(targetPlayer);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player targetPlayer = GetPlayer(this.Roster, name);

            if (targetPlayer.Rank != "Member")
            {
                targetPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player targetPlayer = GetPlayer(this.Roster, name);

            if (targetPlayer.Rank != "Trial")
            {
                targetPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string cl)
        {
            Func<string, string, bool> predicate = (thisCl, givenCl) => thisCl == givenCl;

            var kickedPlayers = GetKickedPlayers(this.Roster, cl, predicate).ToList();
            this.Roster = GetPlayers(Roster, cl, predicate).ToList();

            return kickedPlayers.ToArray();
        }

        private List<Player> GetKickedPlayers(List<Player> roster, string cl, Func<string, string, bool> predicate)
        {
            var newList = new List<Player>();

            foreach (Player player in this.Roster)
            {
                if (predicate(player.Class, cl))
                {
                    newList.Add(player);
                }
            }

            return newList;
        }

        private List<Player> GetPlayers(List<Player> roster, string cl, Func<string, string, bool> predicate)
        {
            var newList = new List<Player>();

            foreach (Player player in this.Roster)
            {
                if (!predicate(player.Class, cl))
                {
                    newList.Add(player);
                }
            }

            return newList;
        }

        public string Report()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (Player player in this.Roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString();
        }

        private Player GetPlayer(List<Player> roster, string name)
        {
            return this.Roster.FirstOrDefault(n => n.Name == name);
        }
    }
}
