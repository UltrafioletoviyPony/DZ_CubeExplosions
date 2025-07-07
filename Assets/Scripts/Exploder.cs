using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] float _explosionForce = 700;
    [SerializeField] float _explosionRadius = 200;

    public void Explode(Cube[] copies, Vector3 explosionPosition)
    {
        foreach (Cube copy in copies)
            copy.Rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }
}