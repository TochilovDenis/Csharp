using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping_Pong
{
    internal class P_Server
    {
        public string Command { get; set; }
        public string Text { get; set; }

        public P_Server(string command, string text)
        {
            Command = command;
            Text = text;
        }
    }
}
