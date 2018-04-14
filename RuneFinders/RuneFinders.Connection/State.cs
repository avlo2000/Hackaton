using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneFinders.Connection
{
    class State : IState
    {
        int[,] hex_matrix;
        Hero[] heroes;
        public void ChangeState(IState newState)
        {
            throw new NotImplementedException();
        }
    }
}
