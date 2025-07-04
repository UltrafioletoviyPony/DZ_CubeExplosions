using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable() =>
        _raycaster.Clicked += Click;

    private void OnDisable() =>
        _raycaster.Clicked -= Click;

    private void Click(Cube cube)
    {
        Cube[] copies;

        if (cube.DivideChance % 2 == 0)
        {
            copies = _spawner.CreateCubes(cube);

            foreach (Cube copy in copies)
                _exploder.Explode(copy.Rigidbody);
        }

        Destroy(cube.gameObject);
    }
}