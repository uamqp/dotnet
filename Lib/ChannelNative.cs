using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class ChannelNative
{
    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    public static extern void queue_declare(IntPtr rnt, IntPtr channel, IntPtr callback);

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    public static extern void basic_consume(IntPtr rnt, IntPtr channel, IntPtr callback);

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    public static extern void basic_publish(IntPtr rnt, IntPtr channel, IntPtr callback);
}
