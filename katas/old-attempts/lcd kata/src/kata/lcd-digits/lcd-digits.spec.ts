import { LcdDigit } from "./lcd-digits.kata";

let lcd = new LcdDigit();

describe('lcd', () => {
    beforeEach(() => { 
        lcd = new LcdDigit();
    });
  it('should exist', () => {
      expect(lcd).toBeDefined();
  });

  it('should create empty grid on init', () => {
    expect(lcd.getGrid()).toEqual([["", "", ""], ["", "", ""], ["", "", ""]]);
  });

  it('grid can contain space value', () => {
    lcd.insertCharacter(' ', 0, 0);
    expect(lcd.getGrid()[0][0]).toEqual(' ');
  });

  it('grid can contain underscore value', () => {
    lcd.insertCharacter('_', 0 ,0);
    expect(lcd.getGrid()[0][0]).toEqual('_');
  });

  it('grid can contain pipe value', () => {
    lcd.insertCharacter('|', 0, 0);
    expect(lcd.getGrid()[0][0]).toEqual('|');
  });

  it('grid contains value at specified coordinate', () => {
    const x = 2;
    const y = 1;
    lcd.insertCharacter('|', x, y);
    expect(lcd.getGrid()[y][x]).toEqual('|');
  });

  it('grid is equal to string representation of zero', () => {
    lcd.draw(0);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  ["|", " ", "|"], 
                                  ["|", "_", "|"]]);
  });

  it('grid is equal to string representation of one', () => {
    lcd.draw(1);
    expect(lcd.getGrid()).toEqual([
                                  [" ", " ", " "], 
                                  [" ", " ", "|"], 
                                  [" ", " ", "|"]]);
  });

  it('grid is equal to string representation of two', () => {
    lcd.draw(2);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  [" ", "_", "|"], 
                                  ["|", "_", " "]]);
  });

  it('grid is equal to string representation of three', () => {
    lcd.draw(3);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  [" ", "_", "|"], 
                                  [" ", "_", "|"]]);
  });

  it('grid is equal to string representation of four', () => {
    lcd.draw(4);
    expect(lcd.getGrid()).toEqual([
                                  [" ", " ", " "], 
                                  ["|", "_", "|"], 
                                  [" ", " ", "|"]]);
  });

  it('grid is equal to string representation of five', () => {
    lcd.draw(5);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  ["|", "_", " "], 
                                  [" ", "_", "|"]]);
  });

  it('grid is equal to string representation of six', () => {
    lcd.draw(6);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  ["|", "_", " "], 
                                  ["|", "_", "|"]]);
  });

  it('grid is equal to string representation of seven', () => {
    lcd.draw(7);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  [" ", " ", "|"], 
                                  [" ", " ", "|"]]);
  });

  it('grid is equal to string representation of eight', () => {
    lcd.draw(8);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  ["|", "_", "|"], 
                                  ["|", "_", "|"]]);
  });

  it('grid is equal to string representation of nine', () => {
    lcd.draw(9);
    expect(lcd.getGrid()).toEqual([
                                  [" ", "_", " "], 
                                  ["|", "_", "|"], 
                                  [" ", " ", "|"]]);
  });

});
