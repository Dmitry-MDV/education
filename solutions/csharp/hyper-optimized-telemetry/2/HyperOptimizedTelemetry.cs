public static class TelemetryBuffer {

    public static byte[] ToBuffer(long reading) {
        byte[] buffer = new byte[9];
        byte length, prefix;
        if ((UInt32.MaxValue < reading && reading <= Int64.MaxValue) || (Int64.MinValue <= reading && reading < Int32.MinValue)) {
            length = (byte)sizeof(Int64);
            prefix = (byte)(256 - length); // signed type
        } else if ((Int32.MaxValue < reading && reading <= UInt32.MaxValue)) {
            length = (byte)sizeof(UInt32);
            prefix = length;
        } else if ((UInt16.MaxValue < reading && reading <= Int32.MaxValue) || (Int32.MinValue <= reading && reading < Int16.MinValue)) {
            length = (byte)sizeof(Int32);
            prefix = (byte)(256 - length); // signed type
        } else if ((0 <= reading && reading <= UInt16.MaxValue)) {
            length = (byte)sizeof(UInt16);
            prefix = length;
        } else if ((Int16.MinValue <= reading && reading < 0)) {
            length = (byte)sizeof(Int16);
            prefix = (byte)(256 - length); // signed type
        } else {
            length = 0;
            prefix = 0;
        }
        buffer[0] = prefix;
        Buffer.BlockCopy(BitConverter.GetBytes(reading), 0, buffer, 1, length);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer) {
        byte prefix = buffer[0];
        if (prefix == 2) {
            return BitConverter.ToUInt16(buffer, 1);
        } else if (prefix == 4) {
            return BitConverter.ToUInt32(buffer, 1);
        } else if (prefix == (byte)(256 - 2)) {
            return BitConverter.ToInt16(buffer, 1);
        } else if (prefix == (byte)(256 - 4)) {
            return BitConverter.ToInt32(buffer, 1);
        } else if (prefix == (byte)(256 - 8)) {
            return BitConverter.ToInt64(buffer, 1);
        } else {
            return 0;
        }
    }

}
