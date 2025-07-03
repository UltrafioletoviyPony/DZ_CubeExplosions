using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cube CreateCube(Cube cube)
    {
        Cube copy = null;

        if (cube.DivideChance > 0)
        {
            copy = Instantiate(cube);
            copy.UpdateDivideChance(cube.DivideChance);
            copy.transform.localScale *= .5f;
            copy.GetComponent<Renderer>().material.color = CreateRandomColor();
        }

        Destroy(cube.gameObject);

        return copy;
    }

    private Color CreateRandomColor()
    {
        float minColorChanelValue = 0;
        float maxColorChanelValue = 1;
        float[] colorChanelValues = new float[3];

        for (int i = 0; i < colorChanelValues.Length; i++)
            colorChanelValues[i] = UnityEngine.Random.Range(minColorChanelValue, maxColorChanelValue);

        return new Color(colorChanelValues[0], colorChanelValues[1], colorChanelValues[2]);
    }
}