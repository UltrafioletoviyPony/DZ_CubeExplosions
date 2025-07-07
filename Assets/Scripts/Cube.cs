using Unity.VisualScripting;
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

    public Cube Clone()
    {
        const string CubePrefabPath = "Prefabs/CubeOriginal";
        float scaleMultiplier = .5f;

        GameObject prefab = Instantiate(Resources.Load<GameObject>(CubePrefabPath));
        prefab.transform.position = this.transform.position;
        prefab.transform.rotation = this.transform.rotation;
        prefab.transform.localScale = this.transform.localScale * scaleMultiplier;
        prefab.GetComponent<Cube>().UpdateDivideChance(this.DivideChance);

        return prefab.GetComponent<Cube>();
    }

    private void UpdateDivideChance(int divideChance)
    {
        int chanceDivider = 2;
        int zeroChance = 0;

        if (divideChance % chanceDivider == zeroChance)
            _divideChance = divideChance / chanceDivider;
        else
            _divideChance = zeroChance;
    }
}