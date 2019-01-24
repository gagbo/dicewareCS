using System;
using System.Windows.Forms;

namespace Diceware
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            PrintEntropyHelp();
            Passwords.PasswordFr5J defValue = new Passwords.PasswordFr5J(5);
            defValue.MakeRolls();
            Console.WriteLine(defValue.RawRolls.ToString());
            Console.WriteLine("Here are a few examples of passphrases generated");
            Console.WriteLine(defValue.Passphrase);
            Console.WriteLine(defValue.Passphrase);
            Console.WriteLine(defValue.Passphrase);
            Console.WriteLine(defValue.Passphrase);
            Console.WriteLine(defValue.Passphrase);
            Console.WriteLine("Another random passphrase has been added to the clipboard");
            Clipboard.SetText(defValue.Passphrase);
            Console.ReadLine();
        }

        static void PrintEntropyHelp()
        {
            Console.WriteLine("Each diceware word brings 12.9 bits of entropy. Therefore:");
            Console.WriteLine("    - 4 words is breakable by ~100 computers.");
            Console.WriteLine("    - 5 words is breakable only by a corporation with large budget");
            Console.WriteLine("    - 6 words seems unbreakable in the forseeable future, but may be in the grasp of state-backed attacks");
            Console.WriteLine("    - 7 words is unbreakable with current state of the art");
            Console.WriteLine("    - 8 words is safe for the times to come");
        }
    }
}
