using UnityEngine;

public class Bonus : MonoBehaviour
{
    public PlatformScript.BonusType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlatformScript platform = collision.GetComponent<PlatformScript>();

            if (platform != null)
                platform.ApplyBonus(type);

            Destroy(gameObject);
        }

        if (collision.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}