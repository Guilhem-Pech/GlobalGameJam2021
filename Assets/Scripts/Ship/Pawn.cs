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
    
    public float rotateSpeedModifier = 1;
    public float speedModifier = 1;
    
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = transform.position;
    }

    public void SetTarget(Vector2 target)
    {
        _target = target;
    }

    private void MoveToward(Vector2 point)
    {
        Vector2 dir = (point - _rigidbody.position).normalized;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, point, 0.1f * speedModifier);
        _rigidbody.MovePosition(newPosition);
        float angle = Vector2.SignedAngle(Vector2.up, dir);
        _rigidbody.SetRotation(Mathf.LerpAngle(_rigidbody.rotation, angle, Time.deltaTime * rotateSpeedModifier));
    }

    private void Update()
    {
        if(!_target.IsNearlyEqual(_rigidbody.position))
            MoveToward(_target);
    }
}
