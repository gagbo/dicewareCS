using System;
using System.Collections.Generic;
using System.IO;

namespace Diceware.Passwords
{
    public interface IPassword
    {
        Diceroll RawRolls { get; }
        void MakeRolls();
        string Passphrase { get; }
        string PassphraseWithoutSpaces { get; }
    }
}
