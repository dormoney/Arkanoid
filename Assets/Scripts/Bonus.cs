using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public static Bonus Instance { get; private set; }

    public enum BonusType
    {
        MultipleBalls,
        SpeedUp,
        SlowDown,
        ExpandPlatform,
        CompressPlatform
    }

    public BonusType bonusType;
    public float duration = 5f;
    public float speedMultiplier = 1.5f;
    public float sizeMultiplier = 1.5f;
    public GameObject prefab;

    public void Activate(GameObject ball, GameObject platform)
    {
        switch (bonusType)
        {
            case BonusType.MultipleBalls:
                CreateMultipleBalls(ball);
                break;
            case BonusType.SpeedUp:
                StartCoroutine(ChangeBallSpeed(ball, speedMultiplier));
                break;
            case BonusType.SlowDown:
                StartCoroutine(ChangeBallSpeed(ball, 1f / speedMultiplier));
                break;
            case BonusType.ExpandPlatform:
                ChangePlatformSize(platform, sizeMultiplier);
                break;
            case BonusType.CompressPlatform:
                ChangePlatformSize(platform, 1f / sizeMultiplier);
                break;
        }
    }

    private void CreateMultipleBalls(GameObject originalBall)
    {
        for (int i = 0; i < 2; i++)
        {
            Vector2 positionOffset = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            GameObject newBall = Instantiate(prefab, originalBall.transform.position + (Vector3)positionOffset, Quaternion.identity);
            newBall.GetComponent<Rigidbody2D>().linearVelocity = originalBall.GetComponent<Rigidbody2D>().linearVelocity;
        }
    }

    private IEnumerator ChangeBallSpeed(GameObject ball, float multiplier)
    {
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.linearVelocity *= multiplier;

        yield return new WaitForSeconds(duration);

        rb.linearVelocity /= multiplier;
    }

    private void ChangePlatformSize(GameObject platform, float multiplier)
    {
        Vector3 newSize = platform.transform.localScale * multiplier;
        Vector3 oldSize = platform.transform.localScale;
        platform.transform.localScale = newSize;

        Invoke("platform.transform.localScale = oldSize",
               duration);
    }
}