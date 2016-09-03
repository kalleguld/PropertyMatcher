using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public interface ISelectable
    {
        SelectionStatus SelectionStatus { get; set; }
    }
}
