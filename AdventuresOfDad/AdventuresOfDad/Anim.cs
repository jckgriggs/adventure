using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfDad
{
    class Anim
    {
        internal string CurrentlyFacing = "^";
        private Draw _draw;
        private Player _player = new Player();

        public Anim(Draw draw)
        {
            _draw = draw;
        }

        internal void MoveCharUp(string sym)
        {
            string[] background = _draw.GetBackground();
            var item = background.First(c => c.Contains(sym));
            int index = Array.IndexOf(background, item);
            string currentPos = background[index];
            background[index] = background[index].Replace(sym, ".");
            index -= 1;
            background[index] = currentPos;
        }

        internal void MoveCharDown(string sym)
        {
            string[] background = _draw.GetBackground();
            var item = background.First(c => c.Contains(sym));
            int index = Array.IndexOf(background, item);
            string currentPos = background[index];
            background[index] = background[index].Replace(sym, ".");
            index += 1;
            background[index] = currentPos;
        }

        internal void MoveCharLeft(string sym)
        {
            string[] background = _draw.GetBackground();
            var item = background.First(c => c.Contains(sym));
            int index = Array.IndexOf(background, item);
            background[index] = background[index].Replace($".{sym}", $"{sym}.");
        }

        internal void MoveCharRight(string sym)
        {
            string[] background = _draw.GetBackground();
            var item = background.First(c => c.Contains(sym));
            int index = Array.IndexOf(background, item);
            background[index] = background[index].Replace($"{sym}.", $".{sym}");
        }

        internal void FaceMovingDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    _draw.Replace(CurrentlyFacing, "^");
                    CurrentlyFacing = "^";
                    break;
                case "down":
                    _draw.Replace(CurrentlyFacing, "v");
                    CurrentlyFacing = "v";
                    break;
                case "left":
                    _draw.Replace(CurrentlyFacing, "<");
                    CurrentlyFacing = "<";
                    break;
                case "right":
                    _draw.Replace(CurrentlyFacing, ">");
                    CurrentlyFacing = ">";
                    break;
            }
        }

        internal void attackUp()
        {
            if(_player.SubtractCooldown(2))
                _draw.insertAbove('^', "+", 120);
        }

        internal void attackDown()
        {
            if(_player.SubtractCooldown(2))
                _draw.insertBelow('v', "+", 120);
        }

        internal void attackLeft()
        {
            if(_player.SubtractCooldown(2))
                _draw.insertLeft('<', "+", 120);
        }


        internal void attackRight()
        {
            if(_player.SubtractCooldown(2))
                _draw.insertRight('>', "+", 120);
        }
    }
}
