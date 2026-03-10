using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    [SerializeField] private GameObject pause;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text loseText;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private Vector3 ballScale = new Vector3(0f, 0f, 0f);

    private int lives = 3;
    private bool paused = false;

    private bool gameOver = false;


    void Start()
    {
        pause.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Restart();
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Time.timeScale = paused ? 0f : 1f;
            pause.SetActive(paused);
        }
    }


    public void LoseLife()
    {
        lives--;

        if (lives == 2) heart3.enabled = false;

        if (lives == 1)
        {
            heart2.enabled = false;
        }

        if (lives == 0)
        {
            heart1.enabled = false;
            Time.timeScale = 0f;

            loseText.text = "";
            gameOverPanel.SetActive(true);
            gameOver = true;
            
        }
        else
        {
            SpawnBall();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        gameOver = false;
        lives = 3;
        Time.timeScale = 1f;
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab);

        newBall.transform.position = Vector3.zero;
        newBall.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

}
