using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactiveDomain.Messaging;
using ProtoBuf;

namespace CommanPublisher.Commands
{
    [ProtoContract]
    public class CreateAccount : Command
    {
        [ProtoMember(1)]
        public readonly Guid AccountId;
        [ProtoMember(2)]
        public readonly string HolderName;
        public CreateAccount(Guid id, string holderName)
        {
            AccountId = id;
            HolderName = holderName;
        }
    }

    [ProtoContract]
    public class DeposeCash : Command
    {
        [ProtoMember(1,IsRequired = true)]
        public readonly Guid AccountId;
        [ProtoMember(2, IsRequired = true)]
        public readonly double Funds;
        public DeposeCash(Guid id, double funds)
        {
            Funds = funds;
            AccountId = id;
        }
    }

    [ProtoContract]
    public class WithdrawCash : Command
    {
        [ProtoMember(1, IsRequired = true)]
        public readonly Guid AccountId;
        [ProtoMember(2, IsRequired = true)]
        public readonly double Amount;
        public WithdrawCash(Guid id, double amount)
        {
            Amount = amount;
            AccountId = id;
        }
    }

    [ProtoContract]
    public class WireTransfer : Command
    {
        [ProtoMember(1, IsRequired = true)]
        public readonly Guid AccountId;
        [ProtoMember(2, IsRequired = true)]
        public readonly double Amount;
        public WireTransfer(Guid id, double amount)
        {
            Amount = amount;
            AccountId = id;
        }
    }

    [ProtoContract]
    public class BlockAccount : Command
    {
        [ProtoMember(1, IsRequired = true)]
        public readonly Guid AccountId;
        public BlockAccount(Guid id)
        {
            AccountId = id;
        }
    }

    [ProtoContract]
    public class UnblockAccount : Command
    {
        [ProtoMember(1, IsRequired = true)]
        public readonly Guid AccountId;
        public UnblockAccount(Guid id)
        {
            AccountId = id;
        }
    }

    [ProtoContract]
    public class SetOverdraftLimit : Command
    {
        [ProtoMember(1, IsRequired = true)]
        public readonly Guid AccountId;
        [ProtoMember(2, IsRequired = true)]
        public readonly double NewLimit;
        public SetOverdraftLimit(Guid id, double newLimit)
        {
            AccountId = id;
            NewLimit = newLimit;
        }
    }

    [ProtoContract]
    public class SetWireTransferLimit : Command
    {
        [ProtoMember(1, IsRequired = true)]
        public readonly Guid AccountId;
        [ProtoMember(2, IsRequired = true)]
        public readonly double NewLimit;
        public SetWireTransferLimit(Guid id, double newLimit)
        {
            AccountId = id;
            NewLimit = newLimit;
        }
    }
}
