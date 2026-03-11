using UnityEngine;

public class MovingBrick : MonoBehaviour
{
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveSpeed = 2f;

    private Vector2 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * direction * moveSpeed * Time.fixedDeltaTime);

        if (transform.position.x >= startPos.x + moveDistance)
        {
            direction = -1;
        }

        if (transform.position.x <= startPos.x - moveDistance)
        {
            direction = 1;
        }
    }
}