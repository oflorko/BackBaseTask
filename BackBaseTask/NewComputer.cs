using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public class NewComputer
    {
        public string ComputerName { set; get; }
        public string IntroducedDate { set; get; }
        public string DiscontinuedDate { set; get; }
        public string Company { set; get; }

        public NewComputer()
        {
            // Set all fields as empty strings by default
            ComputerName = "";
            IntroducedDate = "";
            DiscontinuedDate = "";
            Company = "";
        }
    }
}
