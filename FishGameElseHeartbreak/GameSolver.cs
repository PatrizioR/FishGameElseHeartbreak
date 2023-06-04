using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    public class GameSolver
    {
        private readonly Game game;

        public GameSolver(Game game)
        {
            this.game = game;
        }

        public IEnumerable<string> SolveGame(int maxSteps = 12, int[]? killsWithinSteps = null)
        {
            Queue<(Game, List<string>)> queue = new();
            queue.Enqueue((game, new List<string>()));

            while (queue.Count > 0)
            {
                (Game currentGame, List<string> moves) = queue.Dequeue();

                if (moves.Count > maxSteps)
                {
                    continue;
                }

                if (currentGame.PlayerHasLost())
                {
                    continue;
                }

                if (currentGame.PlayerHasWon())
                {
                    return moves;
                }

                var lastTwoMoves = moves.TakeLast(2).ToList();
                // check if we did a left right or right left and skip that
                if (lastTwoMoves.Count == 2 && (
                    (lastTwoMoves[0] == "Left()" && lastTwoMoves[1] == "Right()") ||
                    (lastTwoMoves[1] == "Left()" && lastTwoMoves[0] == "Right()")
                    ))
                {
                    continue;
                }

                var lastFourMoves = moves.TakeLast(4).ToList();
                // check if we do a 360 round and skip that
                if (lastFourMoves.Count == 4 && (
                   (
                   (lastFourMoves[0] == "Left()" &&
                   lastFourMoves[1] == "Left()" &&
                   lastFourMoves[2] == "Left()" &&
                   lastFourMoves[3] == "Left()")
                   ||
                    (lastFourMoves[0] == "Right()" &&
                   lastFourMoves[1] == "Right()" &&
                   lastFourMoves[2] == "Right()" &&
                   lastFourMoves[3] == "Right()")
                   )
                   ))
                {
                    continue;
                }

                var shouldContinue = false;
                for(int i = 0; i < (killsWithinSteps?.Length ?? 0); i++)
                {
                    if(moves.Count >= killsWithinSteps![i] && currentGame.EnemiesKilled < (i+1))
                    {
                        shouldContinue = true;
                    }
                }

                if (shouldContinue)
                {
                    continue;
                }

                foreach (var nextGame in currentGame.GetNextPossibleGames())
                {
                    var nextMoves = new List<string>(moves)
                    {
                        nextGame.Value
                    };
                    queue.Enqueue((nextGame.Key, nextMoves));
                }
            }

            return Array.Empty<string>(); // No solution found
        }
    }

}
