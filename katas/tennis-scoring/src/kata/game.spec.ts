import { Game } from './game.kata';
import { Player } from './character.kata';

describe('game', () => {
  it('must be able to be complete with a winner', () => { 
    const game = new Game();
    const playerOne = new Player({ name: 'Bob' });
    const playerTwo = new Player({ name: 'Bill' });

    game.executeRound(playerOne, 15, playerTwo, 0);
    game.executeRound(playerOne, 15, playerTwo, 0);
    game.executeRound(playerOne, 10, playerTwo, 0);
    game.executeRound(playerOne, 1, playerTwo, 0);

    expect(game.winner).toBe('Bob');
  });

  it('game should handle deuce case', () => { 
    const game = new Game();
    const playerOne = new Player({ name: 'Bob' });
    const playerTwo = new Player({ name: 'Bill' });

    game.executeRound(playerOne, 15, playerTwo, 15);
    game.executeRound(playerOne, 15, playerTwo, 15);
    game.executeRound(playerOne, 10, playerTwo, 10);

    expect(game.winner).toBe('');

    game.executeRound(playerOne, 1, playerTwo, 0);

    expect(game.winner).toBe('Bob');
  });

  it('game has been won and a winner has been determined', () => { 
    const game = new Game();
    const playerOne = new Player({ name: 'Bob' });
    const playerTwo = new Player({ name: 'Bill' });

    game.executeRound(playerOne, 15, playerTwo, 0);
    game.executeRound(playerOne, 15, playerTwo, 0);
    game.executeRound(playerOne, 10, playerTwo, 0);
    game.executeRound(playerOne, 1, playerTwo, 0);

    expect(playerOne.score).toBeGreaterThan(40);
    expect(playerTwo.score).toBeLessThanOrEqual(40);
    expect(game.winner).toBe('Bob');
  });
});
