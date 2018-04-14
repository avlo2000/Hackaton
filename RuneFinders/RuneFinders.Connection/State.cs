using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneFinders.Connection
{
    public class State : IState
    {
        public IHexagon[,] HexMatrix;
        public int Turn;
        public int Cycle;
        public List<Hero> Heroes;

        public State()
        {

        }
      
        public void ChangeState()
        {
            Turn++;
            Cycle = Turn % 4;
        }
    }
}
