using UnityEngine;

public class InputReader : MonoBehaviour
{
    private Camera _camera;

    private void Awake() =>
        _camera = Camera.main;

    public bool MouseButtonDownClick(MouseButton mouseButton) =>
        Input.GetMouseButtonDown((int)mouseButton);

    public Ray GetRayFromMainCamera() =>
        _camera.ScreenPointToRay(Input.mousePosition);
}

public enum MouseButton
{
    Left = 0,
    Right = 1,
    Middle = 2,
}