using UnityEngine;

namespace Nebukam.Utils
{
    static public class Strings
    {

        public static char[] dot_delimiter = { '.' };
        public static string string_dot_delimiter = ".";

        public static char[] comma_delimiter = { ',' };
        public static string string_comma_delimiter = ",";

        public static char[] colon_delimiter = { ':' };
        public static string string_colon_delimiter = ":";

        public static char[] pipe_delimiter = { '|' };
        public static string string_pipe_delimiter = "|";

        public static char[] tag_delimiter = { ';' };
        public static string string_tag_delimiter = ";";

        public static char[] trim_space = { ' ' };
        public static string string_space = " ";
        
        public static bool TrySplitPath(string input, char[] delimiters, out string[] path)
        {

            path = input.Split(delimiters);

            if (path.Length > 1)
                return true;

            return false;

        }

        /// <summary>
        /// Attempty to parse an IP adress formatted as "0.0.0.0:4444" or "0.0.0.0"
        /// </summary>
        /// <param name="key"></param>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool IsValidIPAddress(string key, out string IP, out int port)
        {

            IP = "";
            port = -1;

            string[] portSplit = key.Split(colon_delimiter);
            string ipText = key;

            if (portSplit.Length == 2)
            {
                if (int.TryParse(portSplit[1], out port))
                {
                    if (port < 0)
                        port = -1;

                    if (port > 65535)
                        port = -1;

                    ipText = portSplit[0];
                }
                else
                {
                    port = -1;
                }
            }

            string[] ipSplit = ipText.Split(dot_delimiter);

            if (ipSplit.Length != 4)
                return false;


            int testInt;
            for (int i = 0; i < 4; i++)
                if (!int.TryParse(ipSplit[i], out testInt)
                    && testInt >= 0
                    && testInt <= 255)
                    return false;

            IP = ipText;
            return true;

        }

        public static bool TryParse(string s, out Vector2 vector)
        {
            if (string.IsNullOrEmpty(s))
            {
                vector = Vector2.zero;
                return false;
            }

            string[] splitPos = s.Split(comma_delimiter);

            if (splitPos.Length < 2)
            {
                vector = Vector2.zero;
                return false;
            }

            float x = 0f, y = 0f;

            if (!float.TryParse(splitPos[0], out x))
                x = 0f;

            if (!float.TryParse(splitPos[1], out y))
                y = 0f;

            vector = new Vector2(x, y);
            return true;
        }

        public static bool TryParse(string s, out Vector3 vector)
        {

            if (string.IsNullOrEmpty(s))
            {
                vector = Vector3.zero;
                return false;
            }

            string[] splitPos = s.Split(comma_delimiter);

            if (splitPos.Length < 2)
            {
                vector = Vector3.zero;
                return false;
            }

            float x = 0f, y = 0f, z = 0f;

            if (!float.TryParse(splitPos[0], out x))
                x = 0f;

            if (!float.TryParse(splitPos[1], out y))
                y = 0f;

            if (splitPos.Length >= 3)
            {
                if (!float.TryParse(splitPos[2], out z))
                    z = 0f;
            }

            vector = new Vector3(x, y, z);
            return true;

        }
        
    }
}
