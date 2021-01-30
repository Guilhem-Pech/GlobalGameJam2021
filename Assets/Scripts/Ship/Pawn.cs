using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[RequireComponent(typeof(Rigidbody2D))]
public class Pawn : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _target;
    private float _angleTarget;
    
    public float rotateSpeedModifier = 1;
    public float speedModifier = 1;
    public float additiveSpeedPerDistance = 0.05f;
    private float _speedModifierByDistance = 1f;
    
    public Vector2 Position => _rigidbody.position;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = _rigidbody.position;
        _angleTarget = _rigidbody.rotation;
    }

    public void SetTarget(Vector2 target)
    {
        _speedModifierByDistance = Math.Max(1,target.Distance(Position) * additiveSpeedPerDistance);
        _target = target;
        RotateToward(target);
    }

    /// <summary>
    /// Face smoothly the pawn toward the target
    /// </summary>
    /// <param name="target"></param>
    public void RotateToward(Vector2 target)
    {
        Vector2 dir = (target - _rigidbody.position).normalized;
        _angleTarget = Vector2.SignedAngle(Vector2.up, dir);
    }

    /// <summary>
    /// Stop the pawn
    /// </summary>
    public void Stop()
    {
        _target = _rigidbody.position;
    }
    
    private void MoveToward(Vector2 point)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, point, 0.1f * speedModifier * _speedModifierByDistance);
        _rigidbody.MovePosition(newPosition);
    }
    
    private void RotateToward(float target)
    {
        _rigidbody.SetRotation(Mathf.LerpAngle(_rigidbody.rotation, target, Time.fixedDeltaTime * rotateSpeedModifier));
    }

    private void FixedUpdate()
    {
        if(!_target.IsNearlyEqual(_rigidbody.position)) // Don't move the pawn if we are on the target
            MoveToward(_target);
        if(!Mathf.Approximately(_rigidbody.rotation, _angleTarget)) // Don't try to change the angle if it's already the good one
            RotateToward(_angleTarget);
    }

    
}
