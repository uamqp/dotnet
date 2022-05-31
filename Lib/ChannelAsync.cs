using System.Runtime.InteropServices;

namespace Uamqp.Lib;

internal static class ChannelAsync
{
    public static Task QueueDeclareAsync(IntPtr loopPtr, IntPtr channelPtr)
    {
        TaskCompletionSource res = new();

        ChannelNative.queue_declare(loopPtr, channelPtr, Marshal.GetFunctionPointerForDelegate(new Callack(() =>
        {
            res.SetResult();
        })));

        return res.Task;
    }

    public static Task<IntPtr> BasicConsumeAsync(IntPtr loopPtr, IntPtr channelPtr)
    {
        TaskCompletionSource<IntPtr> res = new();

        ChannelNative.basic_consume(loopPtr, channelPtr, Marshal.GetFunctionPointerForDelegate(new PtrCallack((IntPtr conumerPtr) =>
        {
            res.SetResult(conumerPtr);
        })));

        return res.Task;
    }

    public static Task BasicPublishAsync(IntPtr loopPtr, IntPtr channelPtr)
    {
        TaskCompletionSource res = new();

        ChannelNative.basic_publish(loopPtr, channelPtr, Marshal.GetFunctionPointerForDelegate(new Callack(() =>
        {
            res.SetResult();
        })));

        return res.Task;
    }
}
