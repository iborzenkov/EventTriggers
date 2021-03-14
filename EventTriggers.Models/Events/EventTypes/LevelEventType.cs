using EventTriggers.Models.Events.Parameters;
using System;
using System.Diagnostics;

namespace EventTriggers.Models.Events.EventTypes
{
    public class LevelEventType : EventType
    {
        public LevelEventType() : base("Цена достигла уровня")
        {
        }

        public override Event MakeEvent(EventParameters parameters)
        {
            var levelParameters = parameters as LevelEventParameters;
            Debug.Assert(levelParameters != null);

            return new LevelEvent(levelParameters);
        }

        public override Guid Id { get; } = Guid.Parse("92143E46-936C-49FE-A145-6966E59B47CD");
    }
}