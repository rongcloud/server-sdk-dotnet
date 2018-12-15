using System;
namespace donet.io.rong.messages
{
    public interface IMessage
    {
        String getType();

        String toString();
    }
}
