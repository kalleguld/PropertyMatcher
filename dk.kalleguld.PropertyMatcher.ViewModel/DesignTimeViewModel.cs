using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class DesignTimeViewModel : PropertyMatcherViewModel
    {
        public DesignTimeViewModel()
            : this(GetCtorData())
        {

        }

        private DesignTimeViewModel(CtorData cd)
            : base(cd.Inputs, cd.Outputs, cd.Connections)
        {

        }

        private static CtorData GetCtorData()
        {
            var result = new CtorData
            {
                Inputs = new Model.Table
                {
                    SystemName = "Input Data",
                    Fields = new List<Model.Field>
                    {
                        new Model.Field { Name= "Navn", },
                        new Model.Field { Name= "Adresse", },
                        new Model.Field { Name= "Tlf", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                        new Model.Field { Name=" Test Property", },
                    }
                },
                Outputs = new Model.Table
                {
                    SystemName = "B",
                    Fields = new List<Model.Field>
                    {
                        new Model.Field { Name = "Name" },
                        new Model.Field { Name = "Street" },
                        new Model.Field { Name = "Zipcode" },
                        new Model.Field { Name = "Country" },
                        new Model.Field { Name = "Phone" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },
                        new Model.Field { Name = "Test Property" },

                    },
                }
            };

            result.Connections = new List<Model.Connection>
            {
                new Model.Connection(result.Inputs.Fields[0], result.Outputs.Fields[0], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[1], result.Outputs.Fields[1], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[1], result.Outputs.Fields[2], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[1], result.Outputs.Fields[3], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[2], result.Outputs.Fields[4], Model.Connection.Creator.Auto),
            };

            return result;
        }

        private class CtorData
        {
            internal Model.Table Inputs;
            internal Model.Table Outputs;
            internal IEnumerable<Model.Connection> Connections;
        }
    }
}
