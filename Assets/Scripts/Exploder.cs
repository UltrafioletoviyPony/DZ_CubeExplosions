using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void ExplodeCube(Cube cube)
    {
        if (cube != null)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();
            rigidbody.AddExplosionForce(5000, cube.transform.position, 200);
        }
    }
}