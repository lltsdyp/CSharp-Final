using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Gobang
{
    public class Match
    {
        private Player player1;
        private Player player2;
        private Panel panel;

        public Match(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            panel = new Panel();
        }


    }
}
