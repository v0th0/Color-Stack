using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    public float difficulty = 1f; // starts easy
    public float increaseRate = 0.1f; // every interval
    public float interval = 10f;

    private float timer = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            difficulty += increaseRate;
            timer = 0f;
        }
    }

    public float GetDifficulty()
    {
        return difficulty;
    }
}
