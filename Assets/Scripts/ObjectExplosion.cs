using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectExplosion : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private CameraRaycaster _cameraRaycaster;
    private Renderer _renderer;
    private int _numberOfObjects;
    private int _divideChance;
    public event Action<List<Collider>> Cloned;

    private void Awake()
    {
        _cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();

        _renderer = GetComponent<Renderer>();
        _renderer.material.color = CreateRandomColor();
        UpdateNumberOfObjects();
        _divideChance = 100;
    }

    private void OnEnable() =>
        _cameraRaycaster.Clicked += ClickByObject;

    private void OnDisable() =>
        _cameraRaycaster.Clicked -= ClickByObject;
    private void ClickByObject(RaycastHit hit)
    {
        List<Collider> colliders = new List<Collider>();

        if (gameObject.transform == hit.transform)
        {
            if (_divideChance > 0)
            {
                colliders = CreateClones();

                Cloned?.Invoke(colliders);
            }

            Destroy(gameObject);
        }
    }

    private List<Collider> CreateClones()
    {
        List<Collider> colliders = new();

        for (int i = 0; i <= _numberOfObjects; i++)
        {
            ObjectExplosion copy = Instantiate(GetComponent<ObjectExplosion>());
            copy.GetComponent<Renderer>().material.color = CreateRandomColor();
            copy.transform.localScale *= 0.5f;
            copy.UpdateDivideChance(_divideChance);
            copy.UpdateNumberOfObjects();
            colliders.Add(copy.GetComponent<Collider>());
        }

        return colliders;
    }
    private void UpdateDivideChance(int divideChance) =>
        _divideChance = divideChance / 2;

    private void UpdateNumberOfObjects(int min = 2, int max = 6) =>
        _numberOfObjects = UnityEngine.Random.Range(min, max + 1);

    private Color CreateRandomColor()
    {
        float minColorChanelValue = 0;
        float maxColorChanelValue = 1;
        float[] colorChanelValues = new float[3];

        for (int i = 0; i < colorChanelValues.Length; i++)
            colorChanelValues[i] = UnityEngine.Random.Range(minColorChanelValue, maxColorChanelValue);

        return new Color(colorChanelValues[0], colorChanelValues[1], colorChanelValues[2]);
    }
}