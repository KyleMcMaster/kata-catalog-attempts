using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace hangman
{
    public class Hangman
    {
        public bool IsInProgress => IncorrectGuesses.Count() < MaxIncorrectGuesses;
        public string SecretWord { get; }
        public string GameStateSecretWord { get; set; }
        public int MaxIncorrectGuesses { get; }
        public List<char> CorrectGuesses { get; }
        public List<char> IncorrectGuesses { get; }
        private List<char> validCharacters { get; }
        public Hangman(string secretWord, int maxIncorrectGuesses)
        {
            this.MaxIncorrectGuesses = maxIncorrectGuesses;
            this.SecretWord = secretWord.ToUpper();
            this.GameStateSecretWord = secretWord.ToUpper();

            validCharacters = new("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26));
            IncorrectGuesses = new();
            CorrectGuesses = new();
        }

        public Result<string> Guess(char g)
        {
            if (!validCharacters.Contains(g))
            {
                return Result.Failure<string>("Invalid Guess");
            }

            if (IncorrectGuesses.Contains(g) || CorrectGuesses.Contains(g))
            {
                return Result.Failure<string>("Duplicate Guess");
            }

            if (!SecretWord.Contains(g))
            {
                IncorrectGuesses.Add(g);
                return Result.Failure<string>("Incorrect Guess");
            }

            CorrectGuesses.Add(g);

            GameStateSecretWord = GameStateSecretWord.Replace(g.ToString(), "");

            if (string.IsNullOrWhiteSpace(GameStateSecretWord))
            {
                return Result.Success("Game won!!!");
            }

            return Result.Success("Correct Guess");
        }
    }
}