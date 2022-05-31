using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class ConsumerNative
{
    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    public static extern void next(IntPtr rnt, IntPtr consumer, IntPtr callback);
}
