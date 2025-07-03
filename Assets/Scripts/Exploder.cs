using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode(Rigidbody rigidbody) =>
        rigidbody.AddExplosionForce(700, rigidbody.transform.position, 200);
}