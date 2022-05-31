using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class ConsumerAsync
{
    public static Task NextAsync(IntPtr loopPtr, IntPtr consumerPtr)
    {
        TaskCompletionSource res = new();

        ConsumerNative.next(loopPtr, consumerPtr, Marshal.GetFunctionPointerForDelegate(new Callack(() =>
        {
            res.SetResult();
        })));

        return res.Task;
    }
}
