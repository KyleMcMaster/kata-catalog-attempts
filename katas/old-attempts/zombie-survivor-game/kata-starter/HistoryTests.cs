using System;
using FluentAssertions;
using Kata.Starter.Fixtures;
using Xunit;

namespace Kata.Starter
{
    public class HistoryTests
    {
        private DateTimeOffset startTime { get; set; }
        private History sut { get; set; }

        public HistoryTests()
        {
            startTime = DateTimeOffset.UtcNow;

            sut = new History(startTime);
        }

        [Fact]
        public void History_Begins_By_Recording_The_Time_The_Game_Began() => sut.StartTime.Should().Be(startTime);

        [Fact]
        public void History_Notes_That_A_Survivor_Has_Been_Added_To_The_Game()
        {
            var historyEvent = new HistoryEvent("Chucri", nameof(Survivor), "Added to game");

            sut.LogEvent(historyEvent);

            sut.Events.Should().Contain(historyEvent);
        }
    }
}