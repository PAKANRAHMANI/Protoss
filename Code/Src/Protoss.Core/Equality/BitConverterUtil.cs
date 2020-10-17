using System;

namespace Protoss.Core.Equality
{
    public static class BitConverterUtil
    {
        public static int SingleToInt32Bits(float value)
        {
            return BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
        }
    }
}
