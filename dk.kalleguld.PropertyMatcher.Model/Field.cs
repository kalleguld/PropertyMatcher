using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.Model
{
    public class Field
    {
        public string SystemTableId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Samplee { get; set; }
        public bool? IsMandatory { get; set; }
        public string Attribute { get; set; }
        public string Reference { get; set; }
    }
}
