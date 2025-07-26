using UnityEngine;

public class PlateColorRandomizer : MonoBehaviour
{
    void Start()
    {
        Color[] colors = { Color.red, Color.green, Color.blue };
        GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
    }
}
