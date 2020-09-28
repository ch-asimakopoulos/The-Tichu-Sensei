using System;
using System.Collections.Generic;
using TichuSensei.Core.Domain.Exceptions;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Domain.ValueObjects
{
    public class AdAccount : ValueObject
    {
        private AdAccount()
        {
        }

        public static AdAccount For(string accountString)
        {
            AdAccount account = new AdAccount();

            try
            {
                int index = accountString.IndexOf("\\", StringComparison.Ordinal);
                account.Domain = accountString.Substring(0, index);
                account.Name = accountString.Substring(index + 1);
            }
            catch (Exception ex)
            {
                throw new AdAccountInvalidException(accountString, ex);
            }

            return account;
        }

        public string Domain { get; private set; }

        public string Name { get; private set; }

        public static implicit operator string(AdAccount account) => account.ToString();

        public static explicit operator AdAccount(string accountString) => For(accountString);

        public override string ToString() => $"{Domain}\\{Name}";

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Domain;
            yield return Name;
        }
    }
}