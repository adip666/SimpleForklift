
using UnityEngine;


namespace InputSystem
{
    public class InputSystem : MonoBehaviour,  IInputSystem
    {
        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";
        private KeyCode brakeKey = KeyCode.Space;
        private KeyCode handlerUpKey = KeyCode.Mouse0;
        private KeyCode handlerDownKey = KeyCode.Mouse1;
        private float horizontalAxis;
        private float verticalAxis;
        private bool brakeButton;
        private bool handlerUpButton;
        private bool handlerDownButton;


        public float HorizontalAxis => horizontalAxis;
        public float VerticalAxis => verticalAxis;
        public bool BrakeButton => brakeButton;
        public bool HandlerUpButton => handlerUpButton;
        public bool HandlerDownButton => handlerDownButton;

        private void FixedUpdate()
        {
            horizontalAxis = Input.GetAxis(HORIZONTAL_AXIS_NAME);
            verticalAxis = Input.GetAxis(VERTICAL_AXIS_NAME);
            brakeButton = Input.GetKey(brakeKey);
            handlerUpButton = Input.GetKey(handlerUpKey);
            handlerDownButton = Input.GetKey(handlerDownKey);
        }
        
        
    }
}

