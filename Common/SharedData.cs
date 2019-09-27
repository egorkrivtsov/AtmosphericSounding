using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class SharedData
    {
        private static ConcurrentQueue<int> probeData  = new ConcurrentQueue<int>();

        private static ConcurrentQueue<int> interpolatedData = new ConcurrentQueue<int>();

        private static ConcurrentQueue<int> processedData = new ConcurrentQueue<int>();
    }
}
