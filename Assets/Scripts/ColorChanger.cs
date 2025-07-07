using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeRandomColors(Cube[] copies)
    {
        foreach (Cube copy in copies)
            copy.GetComponent<Renderer>().material.color = CreateRandomColor();
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