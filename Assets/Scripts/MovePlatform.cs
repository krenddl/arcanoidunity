using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform LeftPlace;
    [SerializeField] private Transform CenterPlace;
    [SerializeField] private Transform RightPlace;

    [SerializeField] private float MoveSpeed = 8f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Vector2 pos;
    private bool IsMoving;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        pos = rb.position;
        IsMoving = false;
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;
        IsMoving = false;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pos = LeftPlace.position;
            IsMoving = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pos = RightPlace.position;
            IsMoving = true;
        }
    }

    private void FixedUpdate()
    {
        if( Time.timeScale == 0f) return;
        if (!IsMoving) return;

        Vector2 newPos = Vector2.MoveTowards(rb.position, pos, MoveSpeed*Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
