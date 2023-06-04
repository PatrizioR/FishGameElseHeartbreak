using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FishGameElseHeartbreak.Test
{
    public class GameSolverTest
    {
        [Fact]
        public void BoardToStringTest()
        {
            var playerParts = "4,6,Up".Split(",");
            var player = new Player(new Position(int.Parse(playerParts[0]), int.Parse(playerParts[1])), Enum.Parse<Direction>(playerParts[2]));
            List<Enemy> enemies = new();

            var enemiesEntries = "3,1,Up;6,5,Left;1,2,Down".Split(";");
            foreach (var enemy in enemiesEntries)
            {
                var enemyParts = enemy.Split(",");
                enemies.Add(new Enemy(new Position(int.Parse(enemyParts[0]), int.Parse(enemyParts[1])), Enum.Parse<Direction>(enemyParts[2])));
            }
            Game testGame = new(8, player, enemies);
            string[] curBoard;
            int row;
            void SetNext()
            {
                curBoard = testGame.Board.ToString().Split("\r\n");
                row = 0;
            }

            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |E↑|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |E↓|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |  |  |E←|  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |  |  |  |P↑|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveLeft();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |E↑|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |E↓|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |  |E←|  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |  |  |  |P←|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveRight();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |E↓|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |E↓|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |E←|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |  |  |  |P↑|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveForward();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |E↓|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |E↓|  |  |E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |  |  |  |P↑|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveForward();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |E↓|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |E↓|  |  |P↑|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveForward();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |E↓|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |  |  |  |P↑|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |E↓|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveLeft();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |E↓|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |  |  |  |P←|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |E↑|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveForward();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |E↓|E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |E↑|  |P←|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveForward();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |E↑|  |  |E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |  |P←|E↓|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveForward();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |E↑|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |  |P←|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |E↓|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);

            testGame.PlayerMoveForward();
            SetNext();
            Assert.Equal("   |00|01|02|03|04|05|06|07|", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("00 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("01 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("02 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("03 |  |E↑|  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("04 |  |  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("05 |  |  |  |  |E†|  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("06 |P←|  |  |  |  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
            Assert.Equal("07 |  |  |  |E↑|  |  |  |  |", curBoard[row++]);
            Assert.Equal("----------------------------", curBoard[row++]);
        }


        [Theory(Timeout = 600000)/*(Skip = "Later")*/]
        [InlineData(8, "4,6,Up", "3,1,Up;6,5,Left;1,2,Down")]
        public void SolverTest(int boardSize, string playerPositionDirection, string enemiesPositionsDirection)
        {
            var playerParts = playerPositionDirection.Split(",");
            var player = new Player(new Position(int.Parse(playerParts[0]), int.Parse(playerParts[1])), Enum.Parse<Direction>(playerParts[2]));
            List<Enemy> enemies = new();

            var enemiesEntries = enemiesPositionsDirection.Split(";");
            foreach (var enemy in enemiesEntries)
            {
                var enemyParts = enemy.Split(",");
                enemies.Add(new Enemy(new Position(int.Parse(enemyParts[0]), int.Parse(enemyParts[1])), Enum.Parse<Direction>(enemyParts[2])));
            }

            Game testGame = new(boardSize, player, enemies);

            Assert.NotEmpty(testGame.Enemies);
            var solver = new GameSolver(testGame);
            var solution = solver.SolveGame(30/*, new[] { 3, 8, 12 }*/);
            
            foreach (var solutionStep in solution)
            {
                switch (solutionStep)
                {
                    case "Forward()":
                        testGame.PlayerMoveForward();
                        break;
                    case "Left()":
                        testGame.PlayerMoveLeft();
                        break;
                    case "Right()":
                        testGame.PlayerMoveRight();
                        break;
                    case "Wait()":
                        testGame.PlayerWait();
                        break;
                    default:
                        throw new ArgumentException(solutionStep.ToString());
                }
            }

            Assert.Empty(testGame.Enemies.Where(enemy => enemy.Alive));
        }
    }
}
