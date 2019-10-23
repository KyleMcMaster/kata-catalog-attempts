namespace MineField
{
    public class MineField
    {
        public int Width { get; }
        public int Length { get; }
        public int Mines { get; }

        public char[,] Field { get; }
        //public int[,] Hints { get; }

        public MineField(int length, int width, int mines)
        {
            Length = length;
            Width = width;
            Mines = mines;

            Field = new char[length, width];

            for (int l = 0; l < length; l++)
            {
                for (int w = 0; w < width; w++)
                {
                    if (mines > 0)
                    {
                        Field[l, w] = '*';
                        mines--;
                    }
                    else
                    {
                        Field[l, w] = '0';
                    }
                    SetHints(l, w);
                }
            }
        }

        private void SetHints(int x, int y)
        {
            if (Field[x, y] == '*')
            {
                return;
            }

            int sum = 0;

            // side neighbors
            if (x + 1 < Length && Field[x + 1, y] == '*')
            {
                sum++;
            }
            if (x - 1 > -1 && Field[x - 1, y] == '*')
            {
                sum++;
            }

            // top neighbors
            if (y - 1 > -1 && Field[x, y - 1] == '*')
            {
                sum++;
            }
            if (x + 1 < Length && y - 1 > -1 && Field[x + 1, y - 1] == '*')
            {
                sum++;
            }
            if (y - 1 > -1 && x - 1 > -1 && Field[x - 1, y - 1] == '*')
            {
                sum++;
            }

            // bottom neighbors
            if (y + 1 < Width && Field[x, y + 1] == '*')
            {
                sum++;
            }
            if (x + 1 < Length && y + 1 < Width && Field[x + 1, y + 1] == '*')
            {
                sum++;
            }
            if (x - 1 > -1 && y + 1 < Width && Field[x - 1, y + 1] == '*')
            {
                sum++;
            }

            Field[x, y] = (char)sum;
        }
    }
}
