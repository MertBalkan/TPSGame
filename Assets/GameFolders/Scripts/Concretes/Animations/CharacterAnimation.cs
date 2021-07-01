using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Controllers;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Animations
{
    public class CharacterAnimation
    {
        private Animator _animator;

        public CharacterAnimation(IEntityController entity)
        {
            _animator = entity.transform.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("moveSpeed") == moveSpeed) return;

            _animator.SetFloat("moveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }

        public void AttackAnimation(bool canAttack)
        {
            _animator.SetBool("isAttack", canAttack);
        }

        public void DeadAnimation()
        {
            _animator.SetTrigger("die");
        }

    }
}