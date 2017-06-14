using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfDad
{
    internal class Input
    {
        private readonly Movement _movement;
        private readonly Player _player;
        public Input(Movement movement, Player player)
        {
            _movement = movement;
            _player = player;
            GetInput();
        }

        public Input()
        {
            
        }
        internal void GetInput()
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        _movement.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        _movement.MoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        _movement.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        _movement.MoveRight();
                        break;
                    case ConsoleKey.Spacebar:
                        _player.Attack();
                        break;
                }
            }
        }
    }
}
