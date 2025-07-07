using UnityEngine;

public class InputHandler : MonoBehaviour
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
        if (cube.DivideChance > 0)
        {
            Cube[] copies = _spawner.CreateCubes(cube);
            _exploder.Explode(copies, cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}