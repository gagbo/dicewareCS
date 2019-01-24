﻿using System;

namespace Diceware
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintEntropyHelp();
            Passwords.PasswordFr5J defValue = new Passwords.PasswordFr5J(5);
            defValue.MakeRolls();
            Console.WriteLine(defValue.RawRolls.ToString());
            Console.WriteLine(defValue.Passphrase);
            Passwords.PasswordFr5J defValue2 = new Passwords.PasswordFr5J(5);
            defValue2.MakeRolls();
            Console.WriteLine(defValue2.RawRolls.ToString());
            Console.WriteLine(defValue2.Passphrase);
            Passwords.PasswordFr5J defValue3 = new Passwords.PasswordFr5J(5);
            defValue3.MakeRolls();
            Console.WriteLine(defValue3.RawRolls.ToString());
            Console.WriteLine(defValue3.Passphrase);
            Passwords.PasswordFr5J defValue4 = new Passwords.PasswordFr5J(5);
            defValue4.MakeRolls();
            Console.WriteLine(defValue4.RawRolls.ToString());
            Console.WriteLine(defValue4.Passphrase);
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
