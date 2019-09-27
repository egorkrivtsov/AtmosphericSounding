using Common.Data.Interfaces;
using Common.Data.Interfaces.Probe;
using Data.Models;

namespace Data.Common
{
    public static class SharedData
    {
        private static SharedList<RawPacket> probe;

        public static SharedList<RawPacket> Probe => probe ?? (probe = new SharedList<RawPacket>());
    }
}
