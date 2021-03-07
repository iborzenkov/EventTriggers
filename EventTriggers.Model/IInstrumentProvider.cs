using System.Collections.Generic;

namespace EventTriggers.Models
{
    public interface IInstrumentProvider
    {
        IEnumerable<Instrument> Instruments { get; }
    }
}