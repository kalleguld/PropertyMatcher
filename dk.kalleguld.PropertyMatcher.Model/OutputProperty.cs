using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.Model
{
    public class OutputProperty : Property
    {

        public Connection ConnectedTo { get; set; }
        
    }
}
