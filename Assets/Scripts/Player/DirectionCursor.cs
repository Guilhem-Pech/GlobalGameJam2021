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

    /* unused code
    private void Update()
    {
        Vector3 playerPos = playerController.transform.position;
        Vector3 cursorPos = transform.position;
        float angle = (float)Math.Atan2(cursorPos.y - playerPos.y, cursorPos.x - playerPos.x);
    }
    */
}