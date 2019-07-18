using System;
using System.Collections.Generic;
using System.Linq;

namespace mars_rover
{
    public class Rover
    {
        private int x;
        private int y;
        private char direction;
        public IEnumerable<char> commands;

        public Rover()
        {
            this.x = 0;
            this.y = 0;
            this.direction = 'N';
            commands = Enumerable.Empty<char>();
        }

        public Tuple<int, int> Point() => new Tuple<int, int>(x,y);

        public char Facing() => direction;

        public void AddCommands(char[] commands)
        {
            this.commands = this.commands.Concat(commands);
        }

        public void executeCommands()
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'f':
                        if (direction == 'N')
                        {
                            y += 1;
                        }
                        break;
                    case 'b':
                        if (direction == 'N')
                        {
                            y -= 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
