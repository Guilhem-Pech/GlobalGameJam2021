using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public InputReader inputReader;
    public Pawn pawn;
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
        if (context.performed)
        {
            Vector3 mousePos = inputReader.GetMousePosition();
            mousePos.z = -_current.transform.position.z;
            Vector2 target = _current.ScreenToWorldPoint(mousePos);
            pawn.SetTarget(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
