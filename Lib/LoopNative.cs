using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class LoopNative
{
    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    public static extern IntPtr create_async_loop();

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    public static extern void connect(IntPtr rnt, IntPtr callback);
}
