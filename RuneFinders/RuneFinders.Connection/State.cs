using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneFinders.Connection
{
    class State : IState
    {
        public IHexagon[,] hex_matrix;
        public List<Hero> heroes;
        public State()
        {

        }

        public void ChangeState(IState newState)
        {
            throw new NotImplementedException();
        }
    }
}
