// Include :
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// https://discussions.unity.com/t/how-do-i-detect-when-the-player-just-landed-after-jumping/855755
// https://discussions.unity.com/t/how-to-make-player-detect-when-on-ground-and-when-lands-on-ground/196439/3


[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class Player_CS : MonoBehaviour
{
    [Header("References :")]
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Camera CameraTarget;

    [Header("Movement :")]
    [SerializeField] private float ForwardMoveSpeed = 1.0f;
    [SerializeField] private float BackwardMoveSpeed = 0.2f;
    [SerializeField] private float RotateSpeed = 35.0f;
    private float CurrentRotateSpeed = 35.0f;
    [SerializeField] private float HeightThresholdLimit = 0.5f;
    [SerializeField] private float MaxSpeed = 10000.0f;
    [SerializeField] private float BuildingSpeedBaseIncriment = 100.0f;
    [SerializeField] private float BuildingSpeedExponentialAcceleration = 0.10f;
    private float BuildSpeedIncriment = 1.0f;
    private float BuiltSpeed = 0.0f;
    [SerializeField] private float BuiltSpeedThreshold = 20.0f;

    private float AirTime = 0.0f;

    [Header("Collision")]
    [SerializeField] private LayerMask FloorLayers;
    [SerializeField] private float SizeGain = 0.4f;
    [SerializeField] private float MassGain = 2.0f;


    private void Awake()
    {
        CurrentRotateSpeed = RotateSpeed;
    }


    private void Update()
    {
        // Movement :
       
        // Forward / Build Speed:
        if (Input.GetKey(KeyCode.W) == true)
        {
            BuildSpeedIncriment = BuildSpeedIncriment + Time.deltaTime * (BuildSpeedIncriment * BuildingSpeedExponentialAcceleration);
            BuiltSpeed = Mathf.Clamp(BuiltSpeed + BuildSpeedIncriment, 0.0f, MaxSpeed);
            CurrentRotateSpeed = 0;
        }
        // Launch : 
        else if (Input.GetKeyUp(KeyCode.W))
        {
            if (BuiltSpeed > BuiltSpeedThreshold)
            {
                PlayerBody.AddForce(PlayerTransform.forward * BuiltSpeed * PlayerBody.mass);
            }
            
            BuiltSpeed = 0.0f;
            BuildSpeedIncriment = BuildingSpeedBaseIncriment;
            CurrentRotateSpeed = RotateSpeed;
        }


        // Backwards : 
        else if (Input.GetKey(KeyCode.S) == true)
        {
            PlayerTransform.Translate(Vector3.forward * Time.deltaTime * -BackwardMoveSpeed);
        }

        // https://www.youtube.com/watch?v=CieCJ2mNTXE
        int SidewardsMovement = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32((Input.GetKey(KeyCode.A)));
        PlayerTransform.Rotate(0.0f, SidewardsMovement * CurrentRotateSpeed * Time.deltaTime, 0.0f);

        // Air Time : 
        if (Physics.Raycast(PlayerTransform.transform.position, Vector3.down, 1.0f, FloorLayers) == false)
        {
            AirTime = AirTime + Time.deltaTime;
        }
    }

    // Height Death : 
    private void OnCollisionEnter(Collision collision)
    {
        // Landing : 
        if (collision.gameObject.CompareTag("Floor") == true)
        {
            if (AirTime > HeightThresholdLimit)
            {
                Debug.Log("Dead");
            }
            AirTime = 0.0f;
        }
    }

    public void Grow(float ObjectValue)
    {
        Vector3 GrowValue = new Vector3(SizeGain * ObjectValue, SizeGain* ObjectValue, SizeGain* ObjectValue);
        PlayerTransform.localScale = PlayerTransform.localScale + GrowValue;
        PlayerBody.mass = PlayerBody.mass + (MassGain * ObjectValue);
    }

}
