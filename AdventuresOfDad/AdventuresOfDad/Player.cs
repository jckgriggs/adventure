using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventuresOfDad
{
    internal class Player
    {
        public static Draw _draw;
        public static Anim _anim;
        public int _cooldown = 10;

        public Player(Draw draw, Anim anim)
        {
            _draw = draw;
            _anim = anim;
            
        }

        public Player()
        {
            Thread thread = new Thread(CooldownLoop);
            thread.Start();
        }
        internal bool FacingMovingDirection(int direction)
        {
            //1: Up, 2: Down, 3: Left, 4: Right
            if (_draw.BackgroundContains("^") && direction == 1)
            {
                return true;
            }
            if (_draw.BackgroundContains("v") && direction == 2)
            {
                return true;
            }
            if (_draw.BackgroundContains("<") && direction == 3)
            {
                return true;
            }
            if (_draw.BackgroundContains(">") && direction == 4)
            {
                return true;
            }
            return false;
        }
        internal bool WillHitBounds(string sym)
        {
            if (_draw.findIndex('^') == 2)
            {
                return true;
            }
            if (_draw.findIndex('v') == 31)
            {
                return true;
            }
            if (_draw.BackgroundContains($"│{sym}"))
            {
                return true;
            }
            if (_draw.BackgroundContains($"{sym}│"))
            {
                return true;
            }
            return false;
        }
        internal void Attack()
        {
            switch (_anim.CurrentlyFacing)
            {
                case "^":
                    if (!WillHitBounds("^"))
                    {
                        _anim.attackUp();
                        Debug.Print("attack up");
                    }
                    break;
                case "v":
                    if (!WillHitBounds("v"))
                        _anim.attackDown();
                    break;
                case "<":
                    if (!WillHitBounds("<"))
                    {
                        _anim.attackLeft();
                        Debug.Print("attack left");
                    }
                    break;
                case ">":
                    if (!WillHitBounds(">"))
                        _anim.attackRight();                   
                    break;
            }
            
        }

        internal void CooldownLoop()
        {
            while (true)
            {
                Thread.Sleep(350);
                if (_cooldown != 10)
                    AddCooldown(1);
            }
        }

        public bool SubtractCooldown(int cool)
        {
            if (!(_cooldown - cool < 0))
            {
                _cooldown -= cool;
                _draw.DrawStamina(_cooldown);
                return true;
            }
            return false;
        }

        public bool AddCooldown(int cool)
        {
            if (!(_cooldown + cool > 10))
            {
                _cooldown += cool;
                _draw.DrawStamina(_cooldown);
                return true;
            }
            return false;
        }
    }
}
