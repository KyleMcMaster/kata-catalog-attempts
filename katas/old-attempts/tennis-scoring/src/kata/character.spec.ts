import { Player } from './character.kata';

describe('player', () => {
  it('should begin with a score of zero (0)', () => { 
    const player = new Player({});
    expect(player.score).toBe(0);
  });

  it('should be able to score points', () => {
    const playerOne = new Player({ score: 0 });
    playerOne.scorePoints(1)
    expect(playerOne.score).toBe(1);
  });

  

  // it('should create a character that is alive, has 1000hp, & is lvl 1', () => {
  // const character = new Character({});
  //   expect(character.health).toBe(1000);
  //   expect(character.isAlive).toBe(true);
  //   expect(character.level).toBe(1);
  // });
  
  // it('should have 800hp when 200 damage is dealt', () => { 
  //   const character = new Character({});
  //   character.takeDamage(200);
  //   expect(character.health).toBe(800);
  // });
  
  // it('should be dead when 1000 damage is dealt', () => {
  //   const character = new Character({});
    
  //   character.takeDamage(1000);
  //   expect(character.health).toBe(0);
  //   expect(character.isAlive).toBe(false);
  // });
  
  // it('should have 1000hp after being healed', () => { 
  //   const character = new Character({});
  //   character.takeDamage(500);
  //   character.takeHealth(500);
  //   expect(character.health).toBe(1000);
  // });
  
  // it('should not heal past 1000hp', () => { 
  //   const character = new Character({});
  //   character.takeHealth(200);
    
  //   expect(character.health).toBe(1000);
  // });
  
  // it('should not be healed when its already died', () => { 
  //   const character = new Character({});

  //   character.takeDamage(1000);
  //   expect(character.isAlive).toBe(false);
  //   character.takeHealth(1001);
  //   expect(character.health).toBe(0);
    
  // });
  
  // it('should not be able to deal damage to self', () => {
  //   const character = new Character({});
    
  //   character.attackTarget(character, 200);
  //   expect(character.attackTarget).toThrow();
  // });
  
  // it('should be able to heal self', () => {
  //   const character = new Character({});
  //   character.takeDamage(200);
  //   character.healTarget(character, 200);
  //   expect(character.health).toBe(1000);
  // });
});
