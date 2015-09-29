using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mike.Oware.Engine;

namespace Oware
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new PlayerBot(new GameConfiguration(12, 4));
            char[] board = new[]
            {
                'A','A','A','A',
                'B','B','B','B',
                'C','C','C','C',
                'D','D','D','D',
                'E','E','E','E',
                'F','F','F','F',
                'a','a','a','a',
                'b','b','b','b',
                'c','c','c','c',
                'd','d','d','d',
                'e','e','e','e',
                'f','f','f','f',
            };

            p1.TakeTurn(board);
        }
    }
}
