using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneFinders.Connection
{
    public class State : IState
    {
        public Hexagon[,] HexMatrix;
        public int Turn;
        public int Cycle;
        public List<Hero> Heroes;

        public State()
        {
            Turn = 0;
            Cycle = 0;
        }
      
        

        public void ChangeState()
        {
            Turn++;
            Cycle = Turn % 4;

            if(Turn % 10 == 0)
            {
                
            }
        }
    }
}
