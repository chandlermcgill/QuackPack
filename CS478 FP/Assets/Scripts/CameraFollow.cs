using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    ICinemachineCamera vCam;

    UnityAction<Transform> setCameraTargetAction;

    private void Awake()
    {
        vCam = GetComponent<ICinemachineCamera>();

        //Define action with found vCam component
        setCameraTargetAction = new UnityAction<Transform>(SetCameraTarget);
    }

    private void Start()
    {
        transform.LookAt(target);
    }

    void SetCameraTarget(Transform cameraTarget)
    {
        vCam.Follow = cameraTarget;
        vCam.VirtualCameraGameObject.transform.parent = cameraTarget;
    }

    private void OnEnable()
    {
        PlayerEvents.onPlayerSpawned += setCameraTargetAction;
    }

    private void OnDisable()
    {
        PlayerEvents.onPlayerSpawned -= setCameraTargetAction;
    }

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    //void LateUpdate()
    //{
    //    Vector3 desiredPosition = target.position + offset;
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPosition;

    //    //transform.LookAt(target);
    //}
}
