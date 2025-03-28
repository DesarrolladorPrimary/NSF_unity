using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";



    private float HorizontalInput;
    private float VerticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;


    [SerializeField] private WheelCollider llantadelanteraderechacollider;
    [SerializeField] private WheelCollider llantadelanteraizquierdacollider;
    [SerializeField] private WheelCollider llantatraseraderechacollider;
    [SerializeField] private WheelCollider llantatraseraizquierdacollider;



    [SerializeField] private Transform llantadelanteraderechatransform;
    [SerializeField] private Transform llantadelanteraizquierdatransform;
    [SerializeField] private Transform llantatraseraderechatransform;
    [SerializeField] private Transform llantatraseraizquierdatransform;












    // Update is called once per frame
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheel();

    }

    private void GetInput()
    {

        HorizontalInput = Input.GetAxis(HORIZONTAL);
        VerticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);


    }

    private void HandleMotor()
    {

        llantadelanteraderechacollider.motorTorque = VerticalInput * motorForce;
        llantadelanteraizquierdacollider.motorTorque = VerticalInput * motorForce;
        currentbreakForce = isBreaking ? motorForce : 0f;
        ApplyBreaking();

    }

    private void ApplyBreaking()
    {
        llantadelanteraderechacollider.brakeTorque = currentbreakForce;
        llantadelanteraizquierdacollider.brakeTorque = currentbreakForce;
        llantatraseraderechacollider.brakeTorque = currentbreakForce;
        llantatraseraizquierdacollider.brakeTorque = currentbreakForce;


    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * HorizontalInput;
        llantadelanteraderechacollider.steerAngle = currentSteerAngle;
        llantadelanteraizquierdacollider.steerAngle = currentSteerAngle;

    }



    private void UpdateWheel()
    {
        UpdateSingleWheel(llantadelanteraderechacollider, llantadelanteraderechatransform);
        UpdateSingleWheel(llantadelanteraizquierdacollider, llantadelanteraizquierdatransform);
        UpdateSingleWheel(llantatraseraderechacollider, llantatraseraderechatransform);
        UpdateSingleWheel(llantatraseraizquierdacollider, llantatraseraizquierdatransform);

    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;




    }









}
