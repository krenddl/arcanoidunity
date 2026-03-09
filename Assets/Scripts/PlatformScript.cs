using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public enum BonusType
    {
        MultipleBalls,
        Fast,
        Slow,
        ExpandPlatform,
        ShrinkPlatform
    }

    [SerializeField] private float platformSizeChange = 1f;
    [SerializeField] private float speedChange = 2f;
    [SerializeField] public GameObject ballPrefab;

    public void ApplyBonus(BonusType bonusType)
    {
        switch (bonusType)
        {
            case BonusType.MultipleBalls:
                CreateExtraBalls();
                break;

            case BonusType.Fast:
                ChangeBallSpeed(speedChange);
                break;

            case BonusType.Slow:
                ChangeBallSpeed(-speedChange);
                break;

            case BonusType.ExpandPlatform:
                {
                    ChangePlatformSize(platformSizeChange);
                    break;
                }

            case BonusType.ShrinkPlatform:
                {
                    ChangePlatformSize(-platformSizeChange);
                    break;
                }
        }
    }

    private void CreateExtraBalls()
    {
        GameObject currentBall = GameObject.FindGameObjectWithTag("Ball");

        if (currentBall == null || ballPrefab == null)
            return;

        GameObject ball1 = Instantiate(ballPrefab, currentBall.transform.position, Quaternion.identity);
        GameObject ball2 = Instantiate(ballPrefab, currentBall.transform.position, Quaternion.identity);

        BallMove bm1 = ball1.GetComponent<BallMove>();
        BallMove bm2 = ball2.GetComponent<BallMove>();

        if (bm1 != null)
            bm1.LaunchWithDirection(new Vector2(-1f, 1f));

        if (bm2 != null)
            bm2.LaunchWithDirection(new Vector2(1f, 1f));
    }

    private void ChangeBallSpeed(float value)
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            BallMove ballMove = ball.GetComponent<BallMove>();

            if (ballMove != null)
                ballMove.ChangeSpeed(value);
        }
    }

    private void ChangePlatformSize(float amount)
    {
        Vector3 scale = transform.localScale;
        scale.x += amount;

        if (scale.x < 2f)
            scale.x = 2f;

        if (scale.x > 6f)
            scale.x = 6f;

        transform.localScale = scale;
    }
}