namespace InputSystem
{
    public interface IInputSystem 
    {
        float HorizontalAxis { get; }
        float VerticalAxis { get; }
        bool BrakeButton { get; }
        bool HandlerUpButton { get; }
        bool HandlerDownButton { get; }
    }
}