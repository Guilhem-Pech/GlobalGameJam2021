using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public InputReader inputReader;
    public Pawn pawn;
    public float deadZoneRadius = 10f;
    private Camera _currentCamera;
    private bool _isRightClickPressed = false;
    private Vector2 _target;
    
    
    private void OnValidate()
    {
        if (pawn == null)
            pawn = GetComponent<Pawn>();
    }

    private void Start()
    {
        inputReader.onRightClick.AddListener(SetTarget);
        _currentCamera = Camera.main;
        _target = Vector2.zero;
    }
    private Vector2 ScreenToWorld(Vector3 mousePos)
    {
        mousePos.z = -_currentCamera.transform.position.z;
        return _currentCamera.ScreenToWorldPoint(mousePos);
    }
    private void SetTarget(InputAction.CallbackContext context)
    {
        if (context.canceled)
            _isRightClickPressed = false;
        if (!context.performed) return;
        _isRightClickPressed = true;
    }

    private void Update()
    {
        if (_isRightClickPressed)
        {
            _target = ScreenToWorld(inputReader.GetMousePosition()); // Get the world pos of where we clicked
            if (_target.SqrDistance(pawn.Position) < deadZoneRadius * deadZoneRadius) // If we are in the deadzone, don't move, just rotate
            {
                pawn.Stop();
                pawn.RotateToward(_target);
                _target = Vector2.zero; // Transform to local position
            }
            else
            {
                _target -= pawn.Position; // Transform to local position;
            }
        }
        if(!_target.IsNearlyEqual(Vector2.zero)) // Don't change the target if nearly equal to 0
            pawn.SetTarget(pawn.Position + _target); // The target in the pawn is in worldpos
    }
}
