using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Gomoku
{
    public class Player
    {
        private string name;
        public string Name { get { return name; } }

        public Player(string name)
        {
            this.name = name;
        }
    }
}
