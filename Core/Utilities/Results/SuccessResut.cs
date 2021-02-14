using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResut:Result
    {
        public SuccessResut(string message) : base(true, message)
        {
        }

        public SuccessResut() : base(true)
        {
        }
    }
}
