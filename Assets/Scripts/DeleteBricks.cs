using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteBricks : MonoBehaviour
{
    [SerializeField] private GameObject[] bonusPrefabs;
    [SerializeField] private float bonusChance = 0.3f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            DropBonus();
            GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

            if (bricks.Length == 1)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
            }

            Destroy(gameObject);
        }

    }

    private void DropBonus()
    {
        if (bonusPrefabs.Length == 0)
            return;

        float randomValue = Random.value;

        if(randomValue <= bonusChance)
        {
            int randomIndex = Random.Range(0, bonusPrefabs.Length);
            Instantiate(bonusPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
