using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_cns1
{
    public class Msg_t
    {
        public string Command { get; set; }
        public string Text { get; set; }
        public Msg_t(string command, string text) {
            Command = command;
            Text = text;
        }
    }
}
