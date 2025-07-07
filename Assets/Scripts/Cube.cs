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
        GameObject prefab = Instantiate(Resources.Load<GameObject>("Prefabs/CubeOriginal"));
        prefab.transform.position = this.transform.position;
        prefab.transform.rotation = this.transform.rotation;
        prefab.transform.localScale = this.transform.localScale * .5f;
        prefab.GetComponent<Renderer>().material.color = CreateRandomColor();
        prefab.GetComponent<Cube>().UpdateDivideChance(this.DivideChance);

        return prefab.GetComponent<Cube>();
    }

    private void UpdateDivideChance(int divideChance)
    {
        if (divideChance % 2 == 0)
            _divideChance = divideChance / 2;
        else
            _divideChance = 0;
    }

    private Color CreateRandomColor()
    {
        float minColorChanelValue = 0;
        float maxColorChanelValue = 1;
        float saturation = .5f;
        float value = 1f;

        return UnityEngine.Random.ColorHSV(minColorChanelValue, maxColorChanelValue,
                                            saturationMin: saturation, saturationMax: saturation,
                                            valueMin: value, valueMax: value);
    }
}