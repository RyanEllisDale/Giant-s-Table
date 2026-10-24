// Includes :
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_CS : MonoBehaviour
{
    [SerializeField] private Transform TransformTarget;
    [SerializeField] private Camera CameraTarget;
    [SerializeField] private Vector3 CameraOffset;

    private void Start()
    {
        CameraTarget.transform.LookAt(TransformTarget);
    }

    private void Update()
    {
        CameraTarget.transform.position = transform.position + CameraOffset;
    }
}
