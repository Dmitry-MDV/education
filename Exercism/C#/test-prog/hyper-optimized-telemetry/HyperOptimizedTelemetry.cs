public static class TelemetryBuffer {

    public static byte[] ToBuffer(long reading) {
        byte[] completeBuffer = new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0}, payloadBytes;
        byte length, prefix;
        if ((4_294_967_296 <= reading && reading <= 9_223_372_036_854_775_807) || (-9_223_372_036_854_775_808 <= reading && reading <= -2_147_483_649)) {
            length = 8;
            prefix = (byte)(256 - length);
        } else if ((2_147_483_648 <= reading && reading <= 4_294_967_295)) {
            length = 4;
            prefix = length;
        } else if ((65_536 <= reading && reading <= 2_147_483_647) || (-2_147_483_648 <= reading && reading <= -32_769)) {
            length = 4;
            prefix = (byte)(256 - length);
        } else if ((0 <= reading && reading <= 65_535)) {
            length = 2;
            prefix = length;
        } else if ((-32_768 <= reading && reading <= -1)) {
            length = 2;
            prefix = (byte)(256 - length);
        } else {
            length = 0;
            prefix = 0;
        }
        completeBuffer[0] = prefix;
        payloadBytes = BitConverter.GetBytes(reading);
        for (int i = 0; i < length; ++i) {
            completeBuffer[i + 1] = payloadBytes[i];
        }
        return completeBuffer;
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
