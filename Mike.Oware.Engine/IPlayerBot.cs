using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mike.Oware.Engine
{
    public interface IPlayerBot
    {
        bool IsHome { get;set; } // Implement but only worry about during TakeTurn.
        char TakeTurn(char[] state);
    }
}
