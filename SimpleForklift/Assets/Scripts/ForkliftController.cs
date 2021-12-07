using UnityEngine;

public class ForkliftController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;

    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;

    [SerializeField] private float maxSteerAngle = 30f;
    [SerializeField] private float motorForce = 30f;
    [SerializeField] private float brakeForce = 200f;

    private float horizontal;
    private float vertical;
    private float steeringAngle;
    private bool brake;

    private void FixedUpdate()
    {
        Inputs();
        Steering();
        Accelerate();
        UpdateWheels();
    }


    private void Inputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        brake = Input.GetKey(KeyCode.Space);
    }

    private void Steering()
    {
        steeringAngle = maxSteerAngle * horizontal;
        frontRightWheelCollider.steerAngle = steeringAngle;
        frontLeftWheelCollider.steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        frontRightWheelCollider.motorTorque = vertical * motorForce;
        frontLeftWheelCollider.motorTorque = vertical * motorForce;

        if (brake)
        {
            frontRightWheelCollider.brakeTorque = brakeForce;
            frontLeftWheelCollider.brakeTorque = brakeForce;
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0;
            frontLeftWheelCollider.brakeTorque = 0;
        }
    }

    private void UpdateWheels()
    {
        UpdateWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheel(backRightWheelCollider, backRightWheelTransform);
        UpdateWheel(backLeftWheelCollider, backLeftWheelTransform);
    }

    private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 wheelPosition = wheelTransform.position;
        Quaternion wheelRotation = wheelTransform.rotation;
        wheelCollider.GetWorldPose(out wheelPosition, out wheelRotation);
        wheelTransform.position = wheelPosition;
        wheelTransform.rotation = wheelRotation;
    }
}