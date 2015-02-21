using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using FlyoutProblem.Events;
using FlyoutProblem.Extensions;
using FlyoutProblem.Models;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace FlyoutProblem.ViewModels
{
    public class ManageTestViewModel : ViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public ManageTestViewModel(
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            SubscribeEvents();

            LoadData();
        }



        private void SubscribeEvents()
        {
            _eventAggregator.GetEvent<TestModelEditedEvent>().Subscribe(HandleTestModelEditedEvent);
        }

        private void HandleTestModelEditedEvent(TestModel obj)
        {
            SortHierarchyInFlatList();
        }


        protected async void LoadData()
        {

            Categories = new ObservableCollection<TestViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                var t = new TestModel
                {
                    Depth = i%3,
                    Name = "Test" + i.ToString()
                };

                var viewModel = new TestViewModel(t, _eventAggregator);
                Categories.Add(viewModel);
            }

            SortHierarchyInFlatList();
        }


        #region Categories

        private ObservableCollection<TestViewModel> _categories;
        public ObservableCollection<TestViewModel> Categories
        {
            get { return _categories; }
            set
            {
                SetProperty(ref _categories, value); ;
            }
        }

        #endregion


        protected void SortHierarchyInFlatList()
        {
            //var nodes = from node in Categories.ByHierarchy<TestViewModel>(
            //                 t => t.Depth == 0,
            //                 (parent, child) => (child.Category.ParentGradingCriteriaId == parent.Category.Id),
            //                 t => t.Category.Name)
            //            select node.Value;


            var nodes = from node in Categories
                orderby node.Depth
                select node;

            // TODO: Workarround for the FlyOut Problem - need to be investigated
            //var list = new ObservableCollection<GradingCategoryViewModel>();

            //nodes.ForEach(c => list.Add(_viewModelFactory.GetGradingCategoryViewModel(c)));

            //Categories = list;

            Categories = new ObservableCollection<TestViewModel>(nodes.ToList());

        }

    }
}
