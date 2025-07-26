using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float moveDistance = 3f;     // how far it moves
    public float moveSpeed = 2f;        // how fast it moves

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float move = moveSpeed * Time.deltaTime;
        if (movingRight)
        {
            transform.Translate(Vector3.right * move);
            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * move);
            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}
