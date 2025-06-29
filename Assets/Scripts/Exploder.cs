using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private ObjectExplosion _objectExplosion;
    //private List<Collider> _colliders;

    private void Awake()
    {
        _objectExplosion = GetComponent<ObjectExplosion>();
    }

    private void OnEnable() =>
        _objectExplosion.Cloned += Explode;
    private void OnDisable() =>
        _objectExplosion.Cloned -= Explode;

    private void Explode(List<Collider> colliders)
    {
        foreach (Rigidbody explodebleObject in GetExplotebleObjects(colliders))
        {
            explodebleObject.AddExplosionForce(700, transform.position, 20);
        }

        Instantiate(_particleSystem, transform.position, transform.rotation);
    }

    private List<Rigidbody> GetExplotebleObjects(List<Collider> colliders)
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody != null)
            {
                rigidbodies.Add(collider.attachedRigidbody);
            }

        }

        return rigidbodies;
    }
}