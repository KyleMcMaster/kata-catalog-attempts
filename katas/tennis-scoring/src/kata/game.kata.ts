import { Player } from "./character.kata";

export class Game {
  winner: string = "";

  executeRound(
    playerOne: Player,
    firstScore: number,
    playerTwo: Player,
    secondScore: number
  ) {
    playerOne.scorePoints(firstScore);
    playerTwo.scorePoints(secondScore);
    this.determineWinner(playerOne, playerTwo);
  }

  private determineWinner(playerOne: Player, playerTwo: Player) {
    if (playerOne.score > 40 && playerTwo.score <= 40) {
      // player one wins
      this.winner = playerOne.name;
    }

    if (playerTwo.score > 40 && playerOne.score <= 40) {
      // player two wins
      this.winner = playerTwo.name;
    }

    if (playerOne.score > 40 && playerTwo.score == 40) {
      // "the deuce" in favor of player 1
      playerOne.score = 40;
      playerTwo.score = 40;
    }

    if (playerTwo.score > 40 && playerOne.score == 40) {
        // "the deuce" in favor of player 2
        playerOne.score = 40;
        playerTwo.score = 40;
    }
  }
}
