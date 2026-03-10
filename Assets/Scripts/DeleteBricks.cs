using UnityEngine;

public class DeleteBricks : MonoBehaviour
{
    [SerializeField] private GameObject[] bonusPrefabs;
    [SerializeField] private float bonusChance = 0.3f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            DropBonus();
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
