using dk.kalleguld.PropertyMatcher.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class PropertyMatcherViewModel : INotifyPropertyChanged
    {
        private PropertyCollection<Model.InputProperty> ModelInputs { get; set; }
        private PropertyCollection<Model.OutputProperty> ModelOutputs { get; set; }

        public ObservableCollection<ViewModel.InputProperty> Inputs { get; private set; }
        public ObservableCollection<ViewModel.OutputProperty> Outputs { get; private set; }

        public string InputsName { get; private set; }
        public string OutputsName { get; private set; }

        public PropertyMatcherViewModel(
            PropertyCollection<Model.InputProperty> inputs, 
            PropertyCollection<Model.OutputProperty> outputs)
        {
            ModelInputs = inputs;
            ModelOutputs = outputs;

            Inputs = GetViewModelInputs(ModelInputs);
            Outputs = GetViewModelOutputs(ModelOutputs, Inputs);



            InputsName = ModelInputs.Name;
            OutputsName = ModelOutputs.Name;
        }

        [Obsolete("For Design time only")]
        public PropertyMatcherViewModel()
        {

            Console.WriteLine("PropertyMatcherViewModel deprecated constructor");
            ModelInputs = new Model.PropertyCollection<Model.InputProperty>
            {
                Name = "A",
                Properties = new List<Model.InputProperty>
                {
                    new Model.InputProperty { Name= "Navn", },
                    new Model.InputProperty { Name= "Adresse", },
                    new Model.InputProperty { Name= "Tlf", },
                },
            };

            ModelOutputs = new Model.PropertyCollection<Model.OutputProperty>
            {
                Name = "B",
                Properties = new List<Model.OutputProperty>
                {
                    new Model.OutputProperty { Name = "Name", ConnectedTo = new Model.Connection(ModelInputs.Properties[0], Model.Connection.Creator.Auto) },
                    new Model.OutputProperty { Name = "Street", ConnectedTo = new Model.Connection(ModelInputs.Properties[1], Model.Connection.Creator.Auto) },
                    new Model.OutputProperty { Name = "Zipcode", ConnectedTo = new Model.Connection(ModelInputs.Properties[1], Model.Connection.Creator.User) },
                    new Model.OutputProperty { Name = "Country", ConnectedTo = new Model.Connection(ModelInputs.Properties[1], Model.Connection.Creator.User) },
                    new Model.OutputProperty { Name = "Phone", ConnectedTo = new Model.Connection(ModelInputs.Properties[2], Model.Connection.Creator.Auto) },
                },
            };

            Inputs = GetViewModelInputs(ModelInputs);
            Outputs = GetViewModelOutputs(ModelOutputs, Inputs);
            InputsName = ModelInputs.Name;
            OutputsName = ModelOutputs.Name;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private static ObservableCollection<ViewModel.InputProperty> GetViewModelInputs(Model.PropertyCollection<Model.InputProperty> inputCollection)
        {
            var inputEnumerable = inputCollection.Properties.Select(p => new ViewModel.InputProperty(p));
            return new ObservableCollection<InputProperty>(inputEnumerable);
        }

        private static ObservableCollection<OutputProperty> GetViewModelOutputs(PropertyCollection<Model.OutputProperty> outputCollection, IEnumerable<ViewModel.InputProperty> inputs)
        {
            var outputList = outputCollection.Properties.Select(p => new ViewModel.OutputProperty(p)).ToList();

            foreach (var output in outputList.Where(o => o.ModelProperty.ConnectedTo != null))
            {
                var creator = output.ModelProperty.ConnectedTo.CreatedBy;
                output.ConnectedTo = new Connection(inputs.FirstOrDefault(i => i.ModelProperty == output.ModelProperty.ConnectedTo.Input),
                    (ViewModel.Connection.Creator)creator);
            }
            return new ObservableCollection<OutputProperty>(outputList);
        }
    }
}
