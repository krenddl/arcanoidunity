using UnityEngine;

public class GameOver : MonoBehaviour
{
    private UIScript ui;
    
    private void Start()
    {
        ui = FindFirstObjectByType<UIScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            Invoke(nameof(CheckBalls), 0.05f);
        }
    }
    private void CheckBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        if(balls.Length == 0 && ui != null)
        {
            ui.LoseLife();
        }
    }
}
