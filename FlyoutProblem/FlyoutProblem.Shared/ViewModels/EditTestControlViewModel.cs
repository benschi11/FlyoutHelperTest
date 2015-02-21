using System.Collections.ObjectModel;
using System.Linq;
using FlyoutProblem.Events;
using FlyoutProblem.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace FlyoutProblem.ViewModels
{
    public class EditTestControlViewModel : ViewModel	
    {
        private readonly IEventAggregator _eventAggregator;
        private TestModel _testModel;

        public EditTestControlViewModel(IEventAggregator eventAggregator, TestModel testModel) 
        {
            _eventAggregator = eventAggregator;
            _testModel = testModel;

            Name = _testModel.Name;

            SaveCommand = new DelegateCommand(Save);

            
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value); ;
            }
        }


        #region EditFlyoutIsOpen

        private bool _flyoutIsOpen;
        public bool FlyoutIsOpen
        {
            get { return _flyoutIsOpen; }
            set
            {
                SetProperty(ref _flyoutIsOpen, value);
            }
        }

        #endregion


        public DelegateCommand SaveCommand { get; private set; }

        private void Save()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                _testModel.Name = Name;
                _eventAggregator.GetEvent<TestModelEditedEvent>().Publish(_testModel);

                this.FlyoutIsOpen = false;
            }
        }

    }
}
