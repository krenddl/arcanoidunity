using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private Rigidbody2D rb;
    private bool IsStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        

    }
    void Update()
    {
        if(!IsStarted && Input.GetKey(KeyCode.Space))
        {
            StartBall();
        }
    }
    void StartBall()
    {
        float angle = Random.Range(-30f, 30f);
        Vector2 direction = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
        rb.linearVelocity = direction.normalized * speed;
        IsStarted = true;
    }

    void FixedUpdate()
    {
        if (IsStarted && rb.linearVelocity.magnitude > 0.01f)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }
    public void ChangeSpeed(float value)
    {
        speed += value;

        if (speed < 2f)
        {
            speed = 2f;
        }
    }
    
    public void LaunchWithDirection(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * speed;
        IsStarted = true;
    }
}
