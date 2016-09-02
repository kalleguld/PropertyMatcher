using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class Connection
    {
        public Connection(InputProperty input, Creator createdBy)
        {
            Input = input;
            CreatedBy = createdBy;
        }

        public InputProperty Input { get; }

        public Creator CreatedBy { get; }




        public enum Creator { User, Auto, }
    }
}
