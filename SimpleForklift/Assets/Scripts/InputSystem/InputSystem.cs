
using UnityEngine;


namespace InputSystem
{
    public class InputSystem : MonoBehaviour,  IInputSystem
    {
        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";
        private KeyCode brakeKey = KeyCode.Space;
        
        private float horizontalAxis;
        private float verticalAxis;
        private bool brakeButton;
      


        public float HorizontalAxis => horizontalAxis;
        public float VerticalAxis => verticalAxis;
        public bool BrakeButton => brakeButton;

        private void FixedUpdate()
        {
            horizontalAxis = Input.GetAxis(HORIZONTAL_AXIS_NAME);
            verticalAxis = Input.GetAxis(VERTICAL_AXIS_NAME);
            brakeButton = Input.GetKey(brakeKey);
        }
        
        
    }
}

