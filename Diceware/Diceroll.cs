using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace Diceware
{
    ///    public static class ExtensionTest
    ///{
    ///        public static void MyExtension(this Diceroll theDiceroll)
    ///        {
    ///            theDiceroll.....
    ///        }
    ///    }

    /// Glorified random generator with a nicer interface to communicate with dictionaries
    /// 
    /// Set the dice / rolls / salt properties and then the Words and Salt properties has
    /// all the rolls so a dictionary can construct a random passphrase with the data
    public class Diceroll
    {
        private int _wordCount;
        private int _dicePerWord;
        private int _facesPerDie;
        private IList<Diceword> words;
        // Those 2 options could be converted to an Option type ?
        private Diceword _salt;
        private bool _hasSalt;

        public Diceroll(int wordCount = 5, int dicePerWord = 5, bool salted = true, int facesPerDie = 6)
        {
            _wordCount = wordCount;
            _dicePerWord = dicePerWord;
            _facesPerDie = facesPerDie;
            _hasSalt = salted;

            _salt = new Diceword(3, 6);

            words = new List<Diceword>();
            for (int i = 0; i < _wordCount; i++)
            {
                words.Add(new Diceword(_dicePerWord, _facesPerDie));
            }

        }

        public List<int[]> WordRolls
        {
            get
            {
                return words.Select(x => x.Rolls).ToList();
            }
        }

        public int[] Salt
        {
            get
            {
                if (_hasSalt)
                {
                    return _salt.Rolls;
                }
                else
                {
                    return new int[0];
                }
            }
        }

        public void MakeRolls()
        {
            foreach (var word in words)
            {
                word.MakeRolls();
            }
            if (_hasSalt)
            {
                _salt.MakeRolls();
            }
        }

        public override string ToString()
        {
            var test = "essai";
            test += " essai2";
            var test2 = $"il est {DateTime.Now}";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_wordCount.ToString() + " Words : ");
            foreach (var word in words)
            {
                sb.AppendLine(word.ToString());
            }
            if (_hasSalt)
            {
                sb.AppendLine("And the salt -> " + _salt.ToString());
            }
            return sb.ToString();
        }

        /// Helper class which contains enough dice rolls to make a word
        class Diceword
        {
            private int _diceCount;
            private List<int> _rolls;
            private int _diceFaces;
            private static RandomNumberGenerator _rngCsp = RandomNumberGenerator.Create();

            public int[] Rolls
            {
                get
                {
                    return _rolls.ToArray();
                }
            }

            public Diceword(int diceCount, int diceFaces = 6)
            {
                _diceCount = diceCount;
                _diceFaces = diceFaces;
                _rolls = new List<int>();
            }

            public void MakeRolls()
            {
                int bytes_in_64 = 8;
                byte[] randomNumber = new byte[bytes_in_64 * _diceCount];
                _rngCsp.GetBytes(randomNumber);
                for (int i = 0; i < _diceCount; i++)
                {
                    double randomDouble = (double)BitConverter.ToUInt64(randomNumber, i * bytes_in_64) / UInt64.MaxValue;
                    _rolls.Add(1 + (int)Math.Floor(randomDouble * _diceFaces));
                }
            }

            public override string ToString()
            {
                return "Rolls : " + String.Join(" ", _rolls);
            }

        }
    }
}
