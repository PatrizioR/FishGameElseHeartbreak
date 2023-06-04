// See https://aka.ms/new-console-template for more information
using FishGameElseHeartbreak;

var player = new Player(new Position(7, 6), Direction.Up);
var enemy1 = new Enemy(new Position(2, 4), Direction.Up);
var enemy2 = new Enemy(new Position(3, 2), Direction.Down);
var enemy3 = new Enemy(new Position(6, 7), Direction.Left);
var game = new Game(8, player, new List<Enemy>() { enemy1, enemy2, enemy3 });
var solver = new GameSolver(game);
var result = solver.SolveGame();

if(result?.Any() == true)
{
    foreach(var resultItem  in result)
    {
        Console.WriteLine(resultItem);
    }
}
else
{
    Console.WriteLine("No result");
}
Console.ReadLine();