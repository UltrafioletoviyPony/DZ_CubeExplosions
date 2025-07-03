using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private int _divideChance;

    public int DivideChance => _divideChance;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _divideChance = 100;
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void UpdateDivideChance(int divideChance) =>
        _divideChance = divideChance / 2;
}