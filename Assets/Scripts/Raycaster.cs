using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private InputReader _inputReader;

    private RaycastHit _hit;
    public event Action<Cube> Clicked;

    private void Update()
    {
        if (Physics.Raycast(_inputReader.GetRayFromMainCamera(), out _hit, Mathf.Infinity, ~_layerMask) && _inputReader.MouseButtonDownClick(MouseButton.Left))
        {
            if (_hit.collider != null && _hit.collider.TryGetComponent(out Cube cube))
                Clicked?.Invoke(cube);
        }
    }
}