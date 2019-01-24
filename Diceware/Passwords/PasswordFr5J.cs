using System;
using System.Collections.Generic;
using System.IO;
using Diceware;

namespace Diceware.Passwords
{
    // TODO : Ajouter la possibilité de retirer les espaces (remplacés par des '0' ou du sel)

    // TODO : Que faire si le sel tombe sur un caractère "hors mot" ? Reroll ?

    // TODO : A refactorer vers une interface + cette classe qui l'implémente pour étendre à d'autres dicts

    /// Traduit des jets de dés en mots de passe à partir d'un dictionnaire et d'une table de sel
    public class PasswordFr5J : IPassword
    {
        public Diceroll RawRolls
        {
            get;
        }
        public Dictionary<int, string> WordsList
        {
            get
            {
                return _wordsList;
            }
        }
        private static Dictionary<int, string> _wordsList = new Dictionary<int, string>();
        private static string _dictFilename = "data/diceware-fr-5-jets.txt";
        private static char[,] _saltSymbolTable = new char[6, 6] {{'~', '!', '#', '$', '%', '^'},
                    {'&', '*', '(', ')', '-', '='},
                    {'+', '[', ']', '\\', '{', '}'},
                    {':', ';', '"', '\'', '<', '>'},
                    {'?', '/', '0', '1', '2', '3'},
                    {'4', '5', '6', '7', '8', '9'}};

        public PasswordFr5J(int how_many_words, bool has_salt = true)
        {
            // Peu lisible à cause des arguments tous entiers. kwargs comme Python ?
            RawRolls = new Diceroll(how_many_words, 5, has_salt, 6);
            try
            {
                using (StreamReader sr = new StreamReader(_dictFilename))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
{
                    string[] key_value_pair = line.Split(" ");
                    int key = Int32.Parse(key_value_pair[0]);
                    _wordsList[key] = key_value_pair[1];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Diceware FR 5 Jets : " + _wordsList.Count.ToString() + " words added.");
        }

        public void MakeRolls()
        {
            RawRolls.MakeRolls();
        }
    }
}
