namespace Uamqp.Lib;

public class Channel
{
    public readonly IntPtr _loopPtr;
    public readonly IntPtr _channelPtr;

    public Channel(IntPtr loopPtr, IntPtr channelPtr)
    {
        _loopPtr = loopPtr;
        _channelPtr = channelPtr;
    }

    public async Task QueueDeclareAsync() => await ChannelAsync.QueueDeclareAsync(_loopPtr, _channelPtr);

    public async Task<Consumer> BasicConsumeAsync() => new Consumer(_loopPtr, await ChannelAsync.BasicConsumeAsync(_loopPtr, _channelPtr));
}
