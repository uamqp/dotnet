using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class ConnectionNative
{
    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    public static extern void create_channel(IntPtr rnt, IntPtr conn, IntPtr callback);
}
