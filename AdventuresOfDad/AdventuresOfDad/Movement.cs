using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfDad
{
    class Movement
    {
        private readonly Player _player;
        private readonly Anim _anim;
        public Movement(Player player, Anim anim)
        {
            _player = player;
            _anim = anim;
        }
        public Movement()
        {

        }
        internal void MoveUp()
        {
            if (_player.FacingMovingDirection(1) && !_player.WillHitBounds("^"))
            {
                _anim.MoveCharUp("^");
            }
            if (!_player.FacingMovingDirection(1))
            {
                _anim.FaceMovingDirection("up");
            }
        }
        internal void MoveDown()
        {
            if (_player.FacingMovingDirection(2) && !_player.WillHitBounds("v"))
            {
                _anim.MoveCharDown("v");
            }
            if (!_player.FacingMovingDirection(2))
            {
                _anim.FaceMovingDirection("down");
            }
        }
        internal void MoveLeft()
        {
            if (_player.FacingMovingDirection(3) && !_player.WillHitBounds("<"))
            {
                _anim.MoveCharLeft("<");
            }
            if (!_player.FacingMovingDirection(3))
            {
                _anim.FaceMovingDirection("left");
            }
        }
        internal void MoveRight()
        {
            if (_player.FacingMovingDirection(4) && !_player.WillHitBounds("^"))
            {
                _anim.MoveCharRight(">");
            }
            if (!_player.FacingMovingDirection(4))
            {
                _anim.FaceMovingDirection("right");
            }
        }
    }
}
