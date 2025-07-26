using UnityEngine;
using System.Collections.Generic;

public class PlayerColorCollector : MonoBehaviour
{
    public Color playerColor;
    public Renderer playerRenderer;
    public Transform plateHolderTop;
    public GameManager gameManager;

    private int collectedCount = 0;
    private float plateStackHeight = 0.3f;
    private List<GameObject> collectedPlates = new List<GameObject>();

    void Start()
    {
        Color[] colors = { Color.red, Color.green, Color.blue };
        playerColor = colors[Random.Range(0, colors.Length)];
        playerRenderer.material.color = playerColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            Color plateColor = other.GetComponent<Renderer>().material.color;

            // ✅ Use safe comparison
            if (ColorsMatch(plateColor, playerColor))
            {
                Destroy(other.gameObject);
                collectedCount++;

                GameObject plate = GameObject.CreatePrimitive(PrimitiveType.Cube);
                plate.transform.SetParent(plateHolderTop);
                plate.transform.localPosition = new Vector3(0, collectedCount * plateStackHeight, 0);
                plate.transform.localScale = new Vector3(1f, 0.2f, 1f);
                plate.GetComponent<Renderer>().material.color = playerColor;
                collectedPlates.Add(plate);
            }
            else
            {
                Destroy(other.gameObject);

                if (collectedCount > 0)
                {
                    Destroy(collectedPlates[collectedPlates.Count - 1]);
                    collectedPlates.RemoveAt(collectedPlates.Count - 1);
                    collectedCount--;
                }
                else
                {
                    gameManager.GameOver();
                }
            }
        }
        else if (other.CompareTag("ColorWall"))
        {
            Color wallColor = other.GetComponent<Renderer>().material.color;
            SetPlayerColor(wallColor);
        }
        else if (other.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }

    }

    public void SetPlayerColor(Color newColor)
    {
        playerColor = newColor;
        playerRenderer.material.color = newColor;

        foreach (GameObject plate in collectedPlates)
        {
            if (plate != null)
                plate.GetComponent<Renderer>().material.color = newColor;
        }
    }

    // ✅ Safe color comparison to avoid color.red issues
    private bool ColorsMatch(Color a, Color b, float tolerance = 0.05f)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance;
    }

    internal void RemoveHalfPlates()
    {
        throw new System.NotImplementedException();
    }
    public void RemovePlates()
    {
        int half = collectedPlates.Count / 2;

        for (int i = 0; i < half; i++)
        {
            GameObject plateToRemove = collectedPlates[collectedPlates.Count - 1];
            collectedPlates.RemoveAt(collectedPlates.Count - 1);
            Destroy(plateToRemove);
            collectedCount--;
        }
    }

}
