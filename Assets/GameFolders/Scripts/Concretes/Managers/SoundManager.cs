using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Utilities;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioClip[] _clips;
        private SoundController[] _soundControllers;

        public SoundController[] SoundControllers => _soundControllers;

        private void Awake()
        {
            SingletonMethod(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        private void Start()
        {
            _soundControllers[0].SetClip(_clip);
            _soundControllers[0].PlaySound();
        }

        public void RangeAttackSound()
        {
            _soundControllers[1].PlaySound();
        }

        public void MeleeAttackSound()
        {
            _soundControllers[2].PlaySound();
        }
    }
}