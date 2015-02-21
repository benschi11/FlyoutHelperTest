using System;
using System.Collections.Generic;
using System.Text;
using FlyoutProblem.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace FlyoutProblem.ViewModels
{
    public class TestViewModel : ViewModel
    {

        private TestModel _testModel;
        private IEventAggregator _eventAggregator;
        public TestViewModel(TestModel test, IEventAggregator eventAggregator)
        {
            _testModel = test;
            _eventAggregator = eventAggregator;

            EditCommand = new DelegateCommand(Edit);

            EditTestControlViewModel = new EditTestControlViewModel(_eventAggregator, _testModel);
        }

        public string Name
        {
            get { return _testModel.Name; }
        }

        public int Depth
        {
            get { return _testModel.Depth; }
        }


        private EditTestControlViewModel _editTestControlViewModel;
        public EditTestControlViewModel EditTestControlViewModel
        {
            get { return _editTestControlViewModel; }
            set
            {
                SetProperty(ref _editTestControlViewModel, value); ;
            }
        }

        public DelegateCommand EditCommand { get; private set; }

        private void Edit()
        {
            _editTestControlViewModel.FlyoutIsOpen = true;
        }
    }
}
