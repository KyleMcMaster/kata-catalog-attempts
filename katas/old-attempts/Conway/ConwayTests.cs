using System;
using System.Diagnostics;
using Xunit;

namespace Conway
{
    public class ConwayTests
    {
        [Fact]
        public void Cell_Constructor_Should_Create_New_Cell()
        {
            // arrange and act
            var cell = new Cell(true);

            //assert
            Assert.NotNull(cell);
        }

        [Fact]
        public void Cell_Constructor_With_True_Param_Creates_Cell_That_is_Alive()
        {
            //arrange and act
            var cell = new Cell(true);

            //assert
            Assert.True(cell.IsAlive);
        }

        [Fact]
        public void Map_Is_Initialized()
        {
            // arrange and act
            var map = InitializeMap();

            //assert
            Assert.NotNull(map);
        }

        [Fact]
        public void Maps_Contains_All_Dead_Cells()
        {
            //arrange
            var map = InitializeMap();
            bool containsAliveCells = false;

            //act
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (map[x, y].IsAlive)
                    {
                        containsAliveCells = true;
                    }
                }
            }

            //assert
            Assert.False(containsAliveCells);
        }

        [Fact]
        public void Map_Contains_Alive_Cell_At_Origin()
        {
            //arrange
            var map = InitializeMap();

            //act
            map[0, 0].IsAlive = true;

            //assert
            Assert.True(map[0, 0].IsAlive);
        }

        [Fact]
        public void Cell_Has_One_Neighbor()
        {
            //arrange 
            var map = InitializeMap();
            map[1, 4].IsAlive = true;
            map[1, 5].IsAlive = true;

            //PrintMap(map);

            //act and assert
            Assert.True(DetermineNeighborExists(map, 1, 4));
        }

        private bool DetermineNeighborExists(Cell[,] map, int x, int y)
        {
            var baseCell = map[x, y];

            var possibleNeighbor = map[x + 1, y];

            if (possibleNeighbor.IsAlive)
            {
                return true;
            }

            possibleNeighbor = map[x - 1, y];

            if (possibleNeighbor.IsAlive)
            {
                return true;
            }

            possibleNeighbor = map[x, y + 1];

            if (possibleNeighbor.IsAlive)
            {
                return true;
            }

            possibleNeighbor = map[x, y - 1];

            if (possibleNeighbor.IsAlive)
            {
                return true;
            }

            return false;
        }

        private Cell[,] InitializeMap()
        {
            var map = new Cell[4, 8];

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    map[x, y] = new Cell(false);
                }
            }

            return map;
        }

        private void PrintMap(Cell[,] map)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    string s;
                    s = map[x, y].IsAlive ? "*" : ".";

                    if (y == 7)
                    {
                        Debug.WriteLine(s);
                    }
                    else
                    {
                        Debug.Write(s);
                    }
                }
            }
        }
    }
}
