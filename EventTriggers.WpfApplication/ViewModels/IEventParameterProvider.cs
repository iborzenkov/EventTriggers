using System;
using EventTriggers.WpfApplication.ViewModels.Commands.Parameters;

namespace EventTriggers.WpfApplication.ViewModels
{
    public interface IEventParameterProvider
    {
        MakeEventParameters Value { get; }
        
        event EventHandler<MakeEventParameters> ParametersChanged;
    }
}