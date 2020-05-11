using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommanPublisher.Commands;
using NetMQ.Sockets;
using NetMQ;
using ProtoBuf;
using System.IO;

namespace CommanPublisher.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommandController : ControllerBase
    {

        private RequestSocket commander;

       public CommandController()
        {
            commander = new RequestSocket(">tcp://localhost:5555");
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("CreateAccount")]
        public object CommandCreateAccount()
        {
            commander = new RequestSocket(">tcp://localhost:5555");
            using (var stream = new MemoryStream())
            {
                var command = new CreateAccount(Guid.NewGuid(), "me");
                Serializer.Serialize<CreateAccount>(stream, command);
                commander.SendFrame(stream.ToArray());
                var @event = commander.ReceiveFrameString();
                return command.AccountId;
            }
        }

        [HttpGet]
        [Route("DeposeCash")]
        public object CommandDeposeCash()
        {
            commander = new RequestSocket(">tcp://localhost:5555");
            using (var stream = new MemoryStream())
            {
                var command = new DeposeCash(Guid.NewGuid(), 100);
                Serializer.Serialize<DeposeCash>(stream, command);
                commander.SendFrame(stream.ToArray());
                var @event = commander.ReceiveFrameString();
                return @event;
            }
        }

        [HttpGet]
        [Route("WithdrawCash")]
        public WithdrawCash CommandWithdrawCash()
        {
            return new WithdrawCash(new Guid(), 100);
        }

        [HttpGet]
        [Route("WireTransfer")]
        public WireTransfer CommandWireTransfer()
        {
            return new WireTransfer(new Guid(), 100);
        }

        [HttpGet]
        [Route("BlockAccount")]
        public BlockAccount CommandBlockAccount()
        {
            return new BlockAccount(new Guid());
        }

        [HttpGet]
        [Route("UnblockAccount")]
        public UnblockAccount CommandUnblockAccount()
        {
            return new UnblockAccount(new Guid());
        }

        [HttpGet]
        [Route("SetOverdraftLimit")]
        public SetOverdraftLimit CommandSetOverdraftLimit()
        {
            return new SetOverdraftLimit(new Guid(),100);
        }
        [HttpGet]
        [Route("SetWireTransferLimit")]
        public SetWireTransferLimit CommandSetWireTransferLimit()
        {
            return new SetWireTransferLimit(new Guid(),100);
        }
    }
}