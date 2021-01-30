using System.Dynamic;
using System.Net.Mime;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DirectionCursor : MonoBehaviour
{
    private PlayerController playerController = null;
    [SerializeField] private Image Tail1;
    [SerializeField] private Image Tail2;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
        playerController.directionCursor = this;        
    }

    public void UpdateCursorPos(Vector2 onScreenTarget) {
        this.transform.position = onScreenTarget;
    }

    public void UpdateCursorForce(int force)
    {
        Tail1.enabled = force>=1;
        Tail2.enabled = force>=2;
    }

    public void UpdateCursorAngle(float angle)
    {
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Update() {
        float angle = (float)Math.Atan2(transform.position.y - playerController.transform.position.y, transform.position.x - playerController.transform.position.x);
        Debug.Log(angle * 180 / Math.PI);
    }
}