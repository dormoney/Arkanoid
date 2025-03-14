using UnityEngine;

public class BallCopyScript : MonoBehaviour
{
    private Vector3 pos;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pos = gameObject.GetComponent<Transform>().position;
        if (pos.x > 2.94 || pos.x < -2.94 || pos.y > 5.1 || pos.y < -4.1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 curVelocity = rb.linearVelocity;
        if (collision.gameObject.name == "LeftCorner")
        {
            if (curVelocity.x > -6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x - 4, curVelocity.y);
            }
        }
        if (collision.gameObject.name.StartsWith("LeftMid"))
        {
            if (curVelocity.x > -6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x - 2, curVelocity.y);
            }
        }
        if (collision.gameObject.name.StartsWith("RightMid"))
        {
            if (curVelocity.x < 6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x + 2, curVelocity.y);
            }
        }
        if (collision.gameObject.name.StartsWith("RightCorner"))
        {
            if (curVelocity.x < 6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x + 4, curVelocity.y);
            }
        }
    }
}
