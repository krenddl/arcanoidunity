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

    [SerializeField] private float platformSizeChange = 15f;
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
        if (currentBall == null || ballPrefab == null) return;

        Vector3 pos = currentBall.transform.position;

        GameObject ball1 = Instantiate(ballPrefab, pos, Quaternion.identity);
        GameObject ball2 = Instantiate(ballPrefab, pos, Quaternion.identity);

        ball1.transform.localScale = currentBall.transform.localScale;
        ball2.transform.localScale = currentBall.transform.localScale;

        SpriteRenderer sr1 = ball1.GetComponent<SpriteRenderer>();
        SpriteRenderer sr2 = ball2.GetComponent<SpriteRenderer>();

        if (BallSkinLoader.Instance != null)
        {
            if (sr1 != null)
                BallSkinLoader.Instance.ApplySkinToRenderer(sr1);

            if (sr2 != null)
                BallSkinLoader.Instance.ApplySkinToRenderer(sr2);
        }

        BallMove bm1 = ball1.GetComponent<BallMove>();
        BallMove bm2 = ball2.GetComponent<BallMove>();

        if (bm1 != null)
            bm1.LaunchWithDirection(new Vector2(-1f, 1f).normalized);

        if (bm2 != null)
            bm2.LaunchWithDirection(new Vector2(1f, 1f).normalized);

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
        scale.x = Mathf.Clamp(scale.x, 40f, 100f);
        transform.localScale = scale;
    }
}