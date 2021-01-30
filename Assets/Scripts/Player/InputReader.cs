using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, GameInputs.IGameplayActions
    {
        private GameInputs _gameInputs;
        private Vector2 _mousePos;
        public UnityEvent<InputAction.CallbackContext> onRightClick = new UnityEvent<InputAction.CallbackContext>(); 
        
        private void OnEnable()
        {
            _gameInputs = new GameInputs();
            _gameInputs.Gameplay.SetCallbacks(this);
            _gameInputs.Gameplay.Enable();
            _gameInputs.Enable();
        }

        private void OnDisable()
        {
            _gameInputs.Disable();
        }

        public Vector2 GetMousePosition()
        {
            return _mousePos;
        }
        
        public void OnRightClick(InputAction.CallbackContext context)
        {
            onRightClick.Invoke(context);
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            _mousePos = context.ReadValue<Vector2>();
        }
    }
}