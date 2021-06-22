using System.Collections;
using System.Collections.Generic;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Animations
{
    public class CharacterAnimation
    {
        private Animator _animator;
        
        public CharacterAnimation(PlayerController entity)
        {
            _animator = entity.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("moveSpeed") == moveSpeed) return;

            _animator.SetFloat("moveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }

    }
}