using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Utilities;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] private AudioClip[] _clips;
        private SoundController[] _soundControllers;


        private void Awake()
        {
            SingletonMethod(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        private void Start()
        {
            _soundControllers[0].SetClip(_clips[0]);
            _soundControllers[1].SetClip(_clips[1]);

            _soundControllers[0].PlaySound();
        }

        public void PlayMachineGun(Vector3 position){

        }
    }
}