using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace hangman
{
    public class HangmanTests
    {
        private (string Input, string Expected) MockSecretWord => ("bell", "BELL");

        [Fact]
        public void Hangman_WhenCreated_ShouldAcceptSecretWordAndStoreInAllCaps()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            sut.SecretWord.Should().Be(MockSecretWord.Expected);
        }

        [Theory]
        [InlineData(5)]
        public void Hangman_WhenCreated_ShouldStoreTheNumberOfIncorrectGuessesThatWillResultInALosingGame(int maxIncorrectGuesses)
        {
            var sut = new Hangman(MockSecretWord.Input, maxIncorrectGuesses);

            sut.MaxIncorrectGuesses.Should().Be(maxIncorrectGuesses);
        }

        [Fact]
        public void Hangman_WhenCreated_IndicatesGameIsInProgress()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            sut.IsInProgress.Should().BeTrue();
        }

        [Fact]
        public void Hangman_Guess_ShouldAcceptALetter()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            sut.Guess('A');
        } // 4

        [Fact]
        public void Hangman_Guess_InvalidCharacterProducesAnInvalidResult()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            var result = sut.Guess('1');

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Invalid Guess");
        }

        [Fact]
        public void Hangman_Guess_CharacterNotInSecretWordReturnsIncorrectGuessResult()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            char guess = 'Z';

            var result = sut.Guess(guess);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Incorrect Guess");
            sut.IncorrectGuesses.Contains(guess).Should().BeTrue();
        }

        [Fact]
        public void Hangman_Guess_DuplicateIncorrectGuessReturnsDuplicateGuessResult()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            char guess = 'Z';

            sut.Guess(guess);

            var result = sut.Guess(guess);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Duplicate Guess");
        }

        [Fact]
        public void Hangman_Guess_DuplicateCorrectGuessReturnsDuplicateGuessResult()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            char guess = 'B';

            sut.Guess(guess);

            var result = sut.Guess(guess);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Duplicate Guess");
        } // 8

        [Fact]
        public void Hangman_GameState_AllLettersGuessedProducesGameWonResult()
        {
            var sut = new Hangman(MockSecretWord.Input, default);

            sut.Guess('B');
            sut.Guess('E');
            var result = sut.Guess('L');

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be("Game won!!!");
        }
    }
}
