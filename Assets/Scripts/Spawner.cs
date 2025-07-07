using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<Cube> _copies = new List<Cube>();
    private int _minCopies = 2;
    private int _maxCopies = 6;

    private void Awake() =>
        _copies.Capacity = _maxCopies;

    public Cube[] CreateCubes(Cube cube)
    {
        _copies.Clear();

        for (int i = 0; i < CreateRandomNumber(); i++)
            _copies.Add(cube.Clone());

        return _copies.ToArray();
    }

    private int CreateRandomNumber() =>
        Random.Range(_minCopies, _maxCopies + 1);
}