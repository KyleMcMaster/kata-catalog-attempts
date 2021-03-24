using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace hangman
{
    public class Hangman
    {
        public bool IsInProgress { get; }
        public int MaxIncorrectGuesses { get; }
        public string SecretWord { get; }
        private List<char> validCharacters { get; }

        public Hangman(int maxIncorrectGuesses, string secretWord) 
        {
            MaxIncorrectGuesses = maxIncorrectGuesses;
            SecretWord = secretWord.ToUpper();

            validCharacters = new("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26));

            IsInProgress = true;
        }

        public Result<string> Guess(char g)
        {
            if (!this.validCharacters.Contains(g))
            {
                return Result.Failure<string>("Invalid Guess");
            }

            return string.Empty;
        }
    }
}