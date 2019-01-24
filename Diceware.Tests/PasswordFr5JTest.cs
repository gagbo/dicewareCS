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
            Assert.IsTrue(testee.WordsList.Count == Math.Pow(6, 5));
        }
    }
}