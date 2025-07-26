using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] plateSpots;
    public GameObject[] colorWalls; // 0 - Red, 1 - Green, 2 - Blue
    public GameObject obstacle;

    void Start()
    {
        float diff = DifficultyManager.Instance.GetDifficulty();

        // Spawn plates
        int maxPlates = Mathf.Clamp(Mathf.FloorToInt(diff), 1, plateSpots.Length);
        for (int i = 0; i < maxPlates; i++)
        {
            SpawnRandomPlate(plateSpots[i].transform.position);
        }

        // Enable one random color wall
        EnableRandomColorWall();

        // Enable obstacle randomly
        obstacle.SetActive(Random.value < diff * 0.3f);
    }

    void SpawnRandomPlate(Vector3 position)
    {
        GameObject plate = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plate.transform.position = position + Vector3.up * 0.2f;
        plate.transform.localScale = new Vector3(1f, 0.2f, 1f);
        plate.tag = "Plate";

        Color[] colors = { Color.red, Color.green, Color.blue };
        Color chosenColor = colors[Random.Range(0, colors.Length)];
        plate.GetComponent<Renderer>().material.color = chosenColor;
    }

    void EnableRandomColorWall()
    {
        // First disable all
        foreach (GameObject wall in colorWalls)
        {
            wall.SetActive(false);
        }

        // Pick one at random
        int index = Random.Range(0, colorWalls.Length);
        colorWalls[index].SetActive(true);
    }
}
