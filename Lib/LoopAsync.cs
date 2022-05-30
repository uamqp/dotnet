using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class LoopAsync
{
    public static IntPtr CreateAsyncLoop() => LoopNative.create_async_loop();

    public static Task<IntPtr> ConnectAsync(IntPtr rnt)
    {
        TaskCompletionSource<IntPtr> res = new();

        LoopNative.connect(rnt, Marshal.GetFunctionPointerForDelegate(new PtrCallack((IntPtr connPtr) =>
        {
            res.SetResult(connPtr);
        })));

        return res.Task;
    }
}
