using UnityEngine;

public class Creater : MonoBehaviour
{
    private Spawner _spawner;
    private Exploder _exploder;
    private CameraRaycaster _camera;

    private void Awake()
    {
        _camera = Camera.main.GetComponent<CameraRaycaster>();
        _spawner = gameObject.AddComponent<Spawner>();
        _exploder = gameObject.AddComponent<Exploder>();
    }

    private void OnEnable() =>
        _camera.Clicked += Click;

    private void OnDisable() =>
        _camera.Clicked -= Click;

    private void Click(GameObject gameObject)
    {
        Cube copyCube = null;

        if (TryGetCube(gameObject, out Cube cube))
        {
            for (int i = 0; i < SetRandomNumber(); i++)
            {
                copyCube = _spawner.CreateCube(cube);

                if (copyCube != null)
                    _exploder.ExplodeCube(copyCube);
            }
        }
    }

    private bool TryGetCube(GameObject gameObject, out Cube cube)
    {
        bool isExist = false;
        cube = null;

        if (gameObject.GetComponent<Cube>() != null)
        {
            isExist = true;
            cube = gameObject.GetComponent<Cube>();
        }

        return isExist;
    }

    private int SetRandomNumber(int min = 2, int max = 6) =>
        Random.Range(min, max + 1);
}
