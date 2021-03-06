using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAngle : MonoBehaviour
{
    private Transform follow;

    // Start is called before the first frame update
    void Start()
    {
        var cameraComponent = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        cameraComponent.Follow = FindObjectOfType<PlayerController>().transform;
        follow = cameraComponent.Follow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = follow.rotation;
    }
}
