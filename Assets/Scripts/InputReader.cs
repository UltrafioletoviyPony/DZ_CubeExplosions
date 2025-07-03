using UnityEngine;

public class InputReader : MonoBehaviour
{
    public bool MouseButtonDownClick(MouseButton mouseButton) =>
        Input.GetMouseButtonDown((int)mouseButton);

    public Ray GetRayFromMainCamera() =>
        Camera.main.ScreenPointToRay(Input.mousePosition);
}

public enum MouseButton
{
    Left = 0,
    Right = 1,
    Middle = 2,
}