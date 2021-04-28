using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman_App.Clases
{
    class Generic
    {
        public static char[] InsertArray(char[] original, char elementoIns, int pos)
        {
            int n = original.Length;

            char[] nuevo = new char[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                if (i < pos - 1)
                    nuevo[i] = original[i];
                else if (i == pos - 1)
                    nuevo[i] = elementoIns;
                else
                    nuevo[i] = original[i - 1];
            }

            return nuevo;
        }
    }
}
