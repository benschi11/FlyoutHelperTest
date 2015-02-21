using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.Prism.Mvvm;

namespace FlyoutProblem.Models
{
    public class TestModel : BindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value); ;
            }
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

        private int _depth;
        public int Depth
        {
            get { return _depth; }
            set
            {
                SetProperty(ref _depth, value); ;
            }
        }
    }
}
