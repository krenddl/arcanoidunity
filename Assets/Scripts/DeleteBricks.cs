using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteBricks : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private bool unbreakable = false;

    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite crackedSprite;

    [SerializeField] private GameObject[] bonusPrefabs;
    [SerializeField] private float bonusChance = 0.3f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateBrickSprite();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }
        if (unbreakable)
            return;
        health--;
        if(health <= 0)
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
        else
        {
            UpdateBrickSprite();
        }

    }
    private void UpdateBrickSprite()
    {
        if (sr == null) return;

        if(health >= 2)
        {
            sr.sprite = normalSprite;
        }
        else if (health == 1)
        {
            sr.sprite = crackedSprite;
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
