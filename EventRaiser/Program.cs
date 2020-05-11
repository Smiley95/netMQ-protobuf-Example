using System;
using NetMQ.Sockets;
using NetMQ;
using EventRaiser.Events;
using System.IO;
using EventRaiser.Commands;
using ProtoBuf;

namespace EventRaiser
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var commandreceiver = new ResponseSocket("@tcp://*:5555"))
            {
                while (true)
                {
                    var msg = commandreceiver.ReceiveFrameBytes();
                    using (var stream = new MemoryStream(msg))
                    {
                        CreateAccount command = Serializer.Deserialize<CreateAccount>(stream);
                        //Serializer.Deserialize<string>(stream);
                        Console.WriteLine("id = " + command.AccountId + " holder name = "+ command.HolderName);
                        commandreceiver.SendFrame(new AccountCreated(new Guid(), "test").ToString());
                        //return 
                    }
                }
            }
        }
    }
}
