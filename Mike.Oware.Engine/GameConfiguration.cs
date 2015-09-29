using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mike.Oware.Engine
{
    public class GameConfiguration
    {
        public int NumberOfPits { get; private set; }
        public int InitialStonesInEachPit { get; private set; }

        public GameConfiguration(int numberOfPits, int initialStonesInEachPit)
        {
            NumberOfPits = numberOfPits;
            InitialStonesInEachPit = initialStonesInEachPit;
        }
    }
}
