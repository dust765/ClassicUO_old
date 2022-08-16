using System;
using System.Collections.Generic;
using System.Net;

namespace ClassicUO.Dust765.Lobby
{
    public sealed class CommandArgs
    {
        private List<String> m_Arguments = new List<string>();
        
        public int Count => m_Arguments.Count;

        public CommandArgs(string text)
        {
            int i = 0;

            while(i < text.Length)
            {
                char c = text[i];
                if(c != ' ')
                {
                    // start reading text argument

                    int j = i;
                    while(j < text.Length && (text[j] != ' '))
                        j++;

                    int len = j - i - 1;

                    m_Arguments.Add(text.Substring(i, j - i));

                    i = j + 1; // stopped reading text argument
                }
                else
                {
                    i++;
                }
            }
        }

        public string GetArgument(int i)
        {
            if(i < 0 || i > m_Arguments.Count)
                return string.Empty;

            return m_Arguments[i];
        }

        public IPAddress GetIPAddress(int i)
        {
            IPAddress res = IPAddress.None;
            String ipString = GetArgument(i);
            
            if(ipString != null)
                IPAddress.TryParse(ipString, out res);
            
            return res;
        }
    }
}