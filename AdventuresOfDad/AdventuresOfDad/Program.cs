using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventuresOfDad
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw draw = new Draw();
            Anim anim = new Anim(draw);
            Player player = new Player(draw, anim);
            Movement movement = new Movement(player, anim);
            Input input = new Input(movement, player);   
            
        }
    }
}
