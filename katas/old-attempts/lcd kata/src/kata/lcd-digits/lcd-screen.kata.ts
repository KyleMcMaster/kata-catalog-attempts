import { LcdDigit } from './lcd-digits.kata';
export class LcdScreen { 
    private numbers: string[][][] = [];

    constructor(param: number) {
        const lcd = new LcdDigit();
        const numbers = (param + '').split('');

       this.numbers = numbers.map(num => {
           lcd.draw(+num);
           return lcd.getGrid();
       });  
    }
 
    initScreen() {
        let output1: string = '';
        let output2: string = '';
        let output3: string = '';
        this.numbers.forEach(num => { 
            
            const line1 = num[0][0] + num[0][1] + num[0][2];
            const line2 = num[1][0] + num[1][1] + num[1][2];
            const line3 = num[2][0] + num[2][1] + num[2][2];

            output1 += line1.replace(' ', '.') +'  ';
            output2 += line2.replace(' ', '.') +'  ';
            output3 += line3.replace(' ', '.') +'  ';
            // console.log(
            // JSON.stringify(num[0]).replace('[', '').replace(']', '').replace('"', "") + '\n',
            // JSON.stringify(num[1]).replace('[', '').replace(']', '') + '\n',
            // JSON.stringify(num[2]).replace('[', '').replace(']', '')
            // );  
            
        })
        console.log(output1 + '\n' + output2 + '\n' + output3);
    }
}