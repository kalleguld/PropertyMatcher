using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.Model
{
    public class Connection
    {
        public Connection(Property input, Property output, Creator createdBy)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            Input = input;

            if (output == null)
                throw new ArgumentNullException(nameof(output));
            Output = output;

            CreatedBy = createdBy;
        }

        public Property Input { get; }
        public Property Output { get; }

        public Creator CreatedBy { get; }
        



        public enum Creator { User, Auto, }

    }
}
