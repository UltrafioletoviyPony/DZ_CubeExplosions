using System;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    private Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;
    private int _layerMask;
    public event Action<GameObject> Clicked;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _layerMask = ~(1 << LayerMask.NameToLayer("InvisibleCollider"));
    }

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, _layerMask) && Input.GetMouseButtonDown(0))
        {
            if (_hit.collider != null)
                Clicked?.Invoke(_hit.collider.gameObject);
        }
    }
}