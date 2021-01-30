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

    public Vector2 Position => _rigidbody.position;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = _rigidbody.position;
        _angleTarget = _rigidbody.rotation;
    }

    public void SetTarget(Vector2 target)
    {
        _target = target;
        RotateToward(target);
    }

    public void RotateToward(Vector2 target)
    {
        Vector2 dir = (target - _rigidbody.position).normalized;
        _angleTarget = Vector2.SignedAngle(Vector2.up, dir);
    }

    public void Stop()
    {
        _target = _rigidbody.position;
    }
    
    private void MoveToward(Vector2 point)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, point, 0.1f * speedModifier);
        _rigidbody.MovePosition(newPosition);
    }
    
    private void RotateToward(float target)
    {
        _rigidbody.SetRotation(Mathf.LerpAngle(_rigidbody.rotation, target, Time.deltaTime * rotateSpeedModifier));
    }

    private void Update()
    {
        if(!_target.IsNearlyEqual(_rigidbody.position))
            MoveToward(_target);
        if(!Mathf.Approximately(_rigidbody.rotation, _angleTarget))
            RotateToward(_angleTarget);
    }

    
}
