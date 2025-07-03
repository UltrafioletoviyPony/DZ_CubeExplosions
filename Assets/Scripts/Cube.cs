using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _divideChance;

    public int DivideChance => _divideChance;

    private void Awake() =>
        _divideChance = 100;

    public void UpdateDivideChance(int divideChance) =>
        _divideChance = divideChance / 2;
}