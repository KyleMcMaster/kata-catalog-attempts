import { LcdScreen } from "./lcd-screen.kata";

describe('lcd-screen', () => {
    it('should exist', () => {
        const screen = new LcdScreen(0);
        expect(screen).toBeDefined();
    });

    it('should draw numbers', () => { 
        const screen = new LcdScreen(80087355);
        screen.initScreen();
    })
});