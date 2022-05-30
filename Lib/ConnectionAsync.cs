using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class ConnectionAsync
{
    public static Task<IntPtr> CreateChannelAsync(IntPtr loop, IntPtr connPtr)
    {
        TaskCompletionSource<IntPtr> res = new();

        ConnectionNative.create_channel(loop, connPtr, Marshal.GetFunctionPointerForDelegate(new PtrCallack((IntPtr channelPtr) =>
        {
            res.SetResult(channelPtr);
        })));

        return res.Task;
    }
}
