using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Framework.Encryption
{
    public interface IHashProvider
    {
        string GetHash(string value);
    }
}
