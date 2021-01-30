using System;
using Cinemachine;
using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        private CinemachineVirtualCamera _virtualCamera;
        public PlayerController player;

        private void OnValidate()
        {
            if (player == null) player = FindObjectOfType<PlayerController>();
            if (player == null) player = GameObject.Find("Player").GetComponent<PlayerController>();

        }

        private void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _virtualCamera.Follow = player.transform;
        }
    }
}