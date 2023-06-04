using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    [Serializable]
    public class Game
    {
        public Board Board { get; private set; }
        public Player Player { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public int EnemiesKilled => Enemies?.Count(item => !item.Alive) ?? 0;
        public Game(int boardSize, Player player, List<Enemy> enemies)
        {
            Board = new Board(boardSize);
            Player = player;
            Enemies = enemies;

            Board.AddEntity(player);
            foreach (var enemy in enemies)
            {
                Board.AddEntity(enemy);
            }
        }

        public Game Clone()
        {
            var enemiesClone = new List<Enemy>();
            var playerClone = new Player(new Position(Player.Position.X, Player.Position.Y), Player.Direction, Player.Alive);
            foreach (var enemy in Enemies)
            {
                enemiesClone.Add(new Enemy(new Position(enemy.Position.X, enemy.Position.Y), enemy.Direction, enemy.Alive));
            }
            var clone = new Game(Board.Size, playerClone, enemiesClone);
            return clone;
        }

        public List<KeyValuePair<Game, string>> GetNextPossibleGames()
        {
            if (!Board.Entities.Any((entity) => entity is Player))
            {
                // game lost
                return new List<KeyValuePair<Game, string>>();
            }
            List<KeyValuePair<Game, string>> games = new();
            var gameForward = Clone();
            var gameLeft = Clone();
            var gameRight = Clone();
            var gameWait = Clone();
            gameForward.PlayerMoveForward();
            gameLeft.PlayerMoveLeft();
            gameRight.PlayerMoveRight();
            gameWait.PlayerWait();
            if (!Player.Position.Equals(gameForward.Player.Position) ||
                Enemies.Count(enemy => enemy.Alive) != gameForward.Enemies.Count(enemy => enemy.Alive))
            {
                // could we move or killed an enemy
                games.Add(new KeyValuePair<Game, string>(gameForward, "Forward()"));
            }
            // only add forward if any gain from that

            var random = new Random();
            var tempGames = new List<KeyValuePair<Game, string>>()    {
                new KeyValuePair<Game, string>(gameLeft, "Left()"),
                new KeyValuePair<Game, string>(gameRight, "Right()"),
                new KeyValuePair<Game, string>(gameWait, "Wait()")
            };

            while (tempGames.Count > 0)
            {
                int index = random.Next(tempGames.Count); // Get random index
                games.Add(tempGames[index]); // Add that item to the games list
                tempGames.RemoveAt(index); // Remove from tempGames
            }
            return games;
        }

        public bool PlayerHasWon()
        {
            // The game is over if all enemies have been knocked out
            return Enemies.All((enemy) => !enemy.Alive);
        }

        public bool PlayerHasLost()
        {
            // game lost
            return !Board.Entities.First((entity) => entity is Player).Alive;
        }

        public void PlayerMoveForward()
        {
            PlayerMove(new Move(Player.Direction, 1));
        }
        public void PlayerMoveLeft()
        {
            PlayerMove(new Move((Direction)((((int)Player.Direction) - 1 + 4) % 4), 0));
        }
        public void PlayerMoveRight()
        {
            PlayerMove(new Move((Direction)((((int)Player.Direction) + 1) % 4), 0));
        }

        public void PlayerWait()
        {
            PlayerMove(new Move(Player.Direction, 0));
        }

        public void PlayerMove(Move move)
        {
            if (!Player.Alive)
            {
                return;
            }
            void CheckCollisionAndMove(Entity entity)
            {
                var collision = CheckCollisions(entity);
                switch (collision)
                {
                    case Enemy e:
                        // can't move
                        break;
                    case Player p:
                        // game lost
                        break;
                    default:
                        // can move
                        entity.Move(this.Board);
                        break;
                }
            }

            // Move the player
            Player.ChangeDirection(move.Direction);
            for (int i = 0; i < move.Steps; i++)
            {
                CheckCollisionAndMove(Player);
            }

            // Move all enemies
            foreach (var enemy in Enemies.Where((enemy) => enemy.Alive).ToList())
            {
                CheckCollisionAndMove(enemy);
            }
        }

        private Entity? CheckCollisions(Entity entity)
        {
            // Check if the entity collided with another entity

            var entitiesNextPosition = entity.GetNextPosition();
            foreach (var e in Board.Entities.ToList())
            {
                if (e != entity && e.Position.Equals(entitiesNextPosition))
                {
                    HandleCollision(entity, e);
                    return e;
                }
            }

            return null;
        }

        private void HandleCollision(Entity entity1, Entity entity2)
        {
            // If a player and an enemy collide, the enemy is removed
            if (entity1 is Player && entity2 is Enemy enemy)
            {
                if (Enemies.Contains(enemy))
                {
                    enemy.Alive = false;
                }
            }
            else if (entity1 is Enemy && entity2 is Player player)
            {
                player.Alive = false;
            }
        }
    }

}
