using System;
using System.Collections.Generic;
using System.Text;
using ReactiveDomain.Messaging;

namespace EventRaiser.Events
{
    public class AccountCreated : Event
    {
        public readonly Guid AccountId;
        public readonly string HolderName;
        public AccountCreated(Guid id, string holderName)
        {
            AccountId = id;
            HolderName = holderName;
        }
    }

    public class DeposedCash : Event
    {
        public readonly Guid AccountId;
        public readonly double Funds;
        public DeposedCash(Guid id, double funds)
        {
            Funds = funds;
            AccountId = id;
        }
    }
    public class DeposedCheck : Event
    {
        public readonly Guid AccountId;
        public readonly double Funds;
        public DeposedCheck(Guid id, double funds)
        {
            Funds = funds;
            AccountId = id;
        }
    }
    public class WithdrawedCash : Event
    {
        public readonly Guid AccountId;
        public readonly double WithdrawdAmount;
        public WithdrawedCash(Guid id, double withdrawdAmount)
        {
            WithdrawdAmount = withdrawdAmount;
            AccountId = id;
        }
    }

    public class AmountWireTransferred : Event
    {
        public readonly Guid AccountId;
        public readonly double TransferredAmount;
        public AmountWireTransferred(Guid id, double transferredAmount)
        {
            TransferredAmount = transferredAmount;
            AccountId = id;
        }
    }

    public class AccountBlocked : Event
    {
        public readonly Guid AccountId;
        public AccountBlocked(Guid id)
        {
            AccountId = id;
        }
    }

    public class AccountUnblocked : Event
    {
        public readonly Guid AccountId;
        public AccountUnblocked(Guid id)
        {
            AccountId = id;
        }
    }

    public class SettedOverdraftLimit : Event
    {
        public readonly Guid AccountId;
        public readonly double NewLimit;
        public SettedOverdraftLimit(Guid id, double newLimit)
        {
            AccountId = id;
            NewLimit = newLimit;
        }
    }

    public class SettedWireTransferLimit : Event
    {
        public readonly Guid AccountId;
        public readonly double NewLimit;
        public SettedWireTransferLimit(Guid id, double newLimit)
        {
            AccountId = id;
            NewLimit = newLimit;
        }
    }
}
