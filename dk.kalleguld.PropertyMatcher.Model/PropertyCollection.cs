using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.Model
{
    public class PropertyCollection
    {
        public string Name { get; set; }
        public IList<Property> Properties { get; set; }
    }
}
