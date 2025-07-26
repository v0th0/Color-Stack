using UnityEngine;

public class ColorWall : MonoBehaviour
{
    public Color wallColor = Color.red; // Set in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColorCollector player = other.GetComponent<PlayerColorCollector>();
            if (player != null)
            {
                player.SetPlayerColor(wallColor);
            }
        }
    }
}
