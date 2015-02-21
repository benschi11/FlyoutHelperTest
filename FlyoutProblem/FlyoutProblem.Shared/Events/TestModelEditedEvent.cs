using System;
using System.Collections.Generic;
using System.Text;
using FlyoutProblem.Models;
using Microsoft.Practices.Prism.PubSubEvents;

namespace FlyoutProblem.Events
{
    public class TestModelEditedEvent : PubSubEvent<TestModel>
    {
    }
}
