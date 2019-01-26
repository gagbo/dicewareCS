using NUnit.Framework;
using Diceware;
using Diceware.Passwords;
using System;
using System.IO;

namespace Diceware.Tests
{
    public class PasswordFr5JTests
    {
        private PasswordFr5J testee;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HasCopiedDictFile()
        {
            Assert.IsTrue(File.Exists("data/diceware-fr-5-jets.txt"));
        }

        [Test]
        public void HasAllWords()
        {
            PasswordFr5J testee = new PasswordFr5J(5);
            Assert.AreEqual(testee.WordsList.Count, Math.Pow(6, 5));
        }

        [Test]
        public void GeneratesConsecutiveDifferentPhrases()
        {
            PasswordFr5J testee = new PasswordFr5J(5);
            Assert.AreNotEqual(testee.Passphrase, testee.Passphrase);
        }

        [Test]
        public void GeneratesNoSpacePhrases()
        {
            PasswordFr5J testee = new PasswordFr5J(5);
            Assert.IsFalse(testee.PassphraseWithoutSpaces.Contains(' '));
        }
    }
}