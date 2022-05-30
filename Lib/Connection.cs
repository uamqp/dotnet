namespace Uamqp.Lib;

public class Connection
{
    private readonly IntPtr _loopPtr;
    public readonly IntPtr _ptr;

    internal Connection(IntPtr loopPtr, IntPtr ptr)
    {
        _loopPtr = loopPtr;
        _ptr = ptr;
    }

    public async Task<Channel> CreateChannelAsync() => new(_loopPtr, await ConnectionAsync.CreateChannelAsync(_loopPtr, _ptr));
}
