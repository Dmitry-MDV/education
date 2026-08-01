// using System;

public class Program {

    public static void Main(string[] args) {
        Console.WriteLine("***** TelemetryBuffer.ToBuffer *****");
        printLong(Int64.MaxValue);
        printLong((long)UInt32.MaxValue + 1);
        printLong(UInt32.MaxValue);
        printLong((long)Int32.MaxValue + 1);
        printLong(Int32.MaxValue);
        printLong((long)UInt16.MaxValue + 1);
        printLong(UInt16.MaxValue);
        printLong((long)Int16.MaxValue + 1);
        printLong(Int16.MaxValue);
        printLong(0);
        printLong(-1);
        printLong(Int16.MinValue);
        printLong(Int16.MinValue - 1);
        printLong(Int32.MinValue);
        printLong((long)Int32.MinValue - 1);
        printLong(Int64.MinValue);
     // printLong();

        Console.WriteLine();
        Console.WriteLine("***** TelemetryBuffer.FromBuffer *****");
        printBytes(new byte[] {22, 0xff, 0xff, 0xff, 0x7f, 0, 0, 0, 0});
        printBytes(new byte[] {0xf8, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f});
        printBytes(new byte[] {0xf8, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0x4, 0xff, 0xff, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0x4, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfc, 0xff, 0xff, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfc, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0x2, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0x2, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfe, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfe, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfe, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfe, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfc, 0xff, 0x7f, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xfc, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0});
        printBytes(new byte[] {0xf8, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0xff});
        printBytes(new byte[] {0xf8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x80});
     // printBytes(new byte[] {});
    }

    public static String byteAsString(byte b) => b.ToString("X".ToLower());

    public static void printBytes(byte[] bytes) {
        var value = TelemetryBuffer.FromBuffer(bytes);
        Console.Write("{0,25}{1,8}  ", value, (int)bytes[0]);
        for (int i = 0; i < bytes.Length - 1; ++i) {
            Console.Write("{0}", "0x" + byteAsString(bytes[i]) + ", ");
        }
        Console.WriteLine("{0}", "0x" + byteAsString(bytes[bytes.Length - 1]));
    }

    public static void printLong(long value) {
        var bytes = TelemetryBuffer.ToBuffer(value);
        Console.Write("{0,25}{0,10}", value, "0x" + byteAsString(bytes[0]) + ", ");
        for (int i = 1; i < bytes.Length - 1; ++i) {
            Console.Write("{0}", "0x" + byteAsString(bytes[i]) + ", ");
        }
        Console.WriteLine("{0}", "0x" + byteAsString(bytes[bytes.Length - 1]));
    }

}
