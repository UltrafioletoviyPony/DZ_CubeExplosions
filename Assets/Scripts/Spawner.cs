using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cube[] CreateCubes(Cube cube)
    {
        Cube[] copies = new Cube[CreateRandomNumber()] ;

        for (int i = 0; i < copies.Length; ++i)
        {
            copies[i] = Instantiate(cube);
            copies[i].UpdateDivideChance(cube.DivideChance);
            copies[i].transform.localScale *= .5f;
            copies[i].GetComponent<Renderer>().material.color = CreateRandomColor();
        }

        return copies;
    }

    private int CreateRandomNumber(int min = 2, int max = 6) =>
        Random.Range(min, max + 1);

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