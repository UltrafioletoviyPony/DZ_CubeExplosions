using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    private Raycaster _camera;

    private void Awake() =>
        _camera = Camera.main.GetComponent<Raycaster>();

    private void OnEnable() =>
        _camera.Clicked += Click;

    private void OnDisable() =>
        _camera.Clicked -= Click;

    private void Click(Cube cube)
    {
        Cube[] copies;

        if (cube.DivideChance > 0)
        {
            copies = _spawner.CreateCubes(cube);

            foreach (Cube copy in copies)
                _exploder.Explode(copy.Rigidbody);
        }
    }
}
