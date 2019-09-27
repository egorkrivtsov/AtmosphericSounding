using System;
using System.Collections.Generic;

namespace Common.Data.Interfaces.Probe
{
    public interface IProbePacket
    {
        DateTime DateTimeUtc { get; set; }

        int Id { get; set; }

        decimal Temperature { get; set; }

        decimal Humidity { get; set; }

    }
}
