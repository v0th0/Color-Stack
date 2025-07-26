using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColorCollector player = other.GetComponent<PlayerColorCollector>();
            if (player != null)
            {
                player.RemovePlates();
                Debug.Log("⚠️ Player hit by laser. Half the plates removed.");
            }
        }
    }
}
