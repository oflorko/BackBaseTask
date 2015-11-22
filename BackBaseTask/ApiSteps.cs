using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackBaseTask
{
    public abstract class ApiSteps
    {
        protected readonly BaseContext BaseContext;

        protected ApiSteps(BaseContext baseContext)
        {
            BaseContext = baseContext;
        }
    }
}
