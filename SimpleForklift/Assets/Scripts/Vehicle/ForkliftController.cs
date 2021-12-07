using UnityEngine;

namespace Forklift
{
    public class ForkliftController : MonoBehaviour
    {
        [SerializeField] private InputSystem.InputSystem inputSystem;
        
        [SerializeField] private WheelCollider frontRightWheelCollider;
        [SerializeField] private WheelCollider frontLeftWheelCollider;
        [SerializeField] private WheelCollider backRightWheelCollider;
        [SerializeField] private WheelCollider backLeftWheelCollider;

        [SerializeField] private Transform frontRightWheelTransform;
        [SerializeField] private Transform frontLeftWheelTransform;
        [SerializeField] private Transform backRightWheelTransform;
        [SerializeField] private Transform backLeftWheelTransform;

        [SerializeField] private Transform handler;
        [SerializeField] private Transform handlerMaxTransform;
        [SerializeField] private Transform handlerMinTransform;
        

        [SerializeField] private float maxSteerAngle = 30f;
        [SerializeField] private float engineForce = 30f;
        [SerializeField] private float brakeForce = 200f;
        [SerializeField] private float handlerSpeed = 1;
        
        private float steeringAngle;
        
        private void FixedUpdate()
        {
            Steering();
            Accelerate();
            UpdateWheels();
            HandlerControl();
        }
        
        private void Steering()
        {
            steeringAngle = maxSteerAngle * inputSystem.HorizontalAxis;
            frontRightWheelCollider.steerAngle = steeringAngle;
            frontLeftWheelCollider.steerAngle = steeringAngle;
        }

        private void Accelerate()
        {
            frontRightWheelCollider.motorTorque = inputSystem.VerticalAxis * engineForce;
            frontLeftWheelCollider.motorTorque = inputSystem.VerticalAxis * engineForce;

            if (inputSystem.BrakeButton)
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

        private void HandlerControl()
        {
            if (inputSystem.HandlerUpButton && handler.position.y < handlerMaxTransform.position.y)
            {
                handler.transform.Translate(Vector3.up * Time.deltaTime * handlerSpeed);
            }
            else if (handler.position.y > handlerMaxTransform.position.y)
            {
                handler.transform.position = handlerMaxTransform.position;
            }
            else if (inputSystem.HandlerDownButton && handler.position.y > handlerMinTransform.position.y)
            {
                handler.transform.Translate(-Vector3.up * Time.deltaTime * handlerSpeed);
            }
            else if (handler.position.y < handlerMinTransform.position.y)
            {
                handler.transform.position = handlerMinTransform.position;
            }
        }
    }
}