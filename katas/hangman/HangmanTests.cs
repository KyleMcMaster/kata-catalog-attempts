using System;
using FluentAssertions;
using Xunit;

namespace hangman
{
    public class HangmanTests
    {
        private (string Input, string Expected) MockSecretWord => ("bell", "BELL");

        [Fact]
        public void Hangman_WhenCreated_ShouldAcceptASecretWordAndStoreInAllCaps()
        {
            var sut = new Hangman(default, MockSecretWord.Input);

            sut.SecretWord.Should().Be(MockSecretWord.Expected);
        }

        [Theory]
        [InlineData(5)]
        public void Hangman_WhenCreated_ShouldStoreTheNumberOfIncorrectGuessesThatWillResultInALosingGame(int maxIncorrectGuesses)
        {
            var sut = new Hangman(maxIncorrectGuesses, MockSecretWord.Input);

            sut.MaxIncorrectGuesses.Should().Be(maxIncorrectGuesses);
        }

        [Fact]
        public void Hangman_WhenCreated_IndicatesTheGameIsInProgress()
        {
            var sut = new Hangman(default, MockSecretWord.Input);

            sut.IsInProgress.Should().BeTrue();
        }

        [Fact]
        public void Hangman_Guess_AcceptsALetter()
        {
            var sut = new Hangman(default, MockSecretWord.Input);

            sut.Guess('A');
        }

        [Fact]
        public void Hangman_Guess_InvalidCharacterInputReturnsInvalidGuessResult()
        {
            var sut = new Hangman(default, MockSecretWord.Input);

            var result = sut.Guess('1');

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Invalid Guess");
        }
    }
}
