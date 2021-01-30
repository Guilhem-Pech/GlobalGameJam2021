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
    private Camera _current;
    
    private void OnValidate()
    {
        if (pawn == null)
            pawn = GetComponent<Pawn>();
    }

    void Start()
    {
        inputReader.onRightClick.AddListener(SetTarget);
        _current = Camera.main;
    }

    void SetTarget(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        Vector2 target = ScreenToWorld(inputReader.GetMousePosition());
        if (target.SqrDistance(pawn.Position) < deadZoneRadius * deadZoneRadius)
        {
            pawn.Stop();
            pawn.RotateToward(target);
        }
        else
            pawn.SetTarget(target);
    }

    private Vector2 ScreenToWorld(Vector3 mousePos)
    {
        mousePos.z = -_current.transform.position.z;
        return _current.ScreenToWorldPoint(mousePos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
