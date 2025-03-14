using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Camera mainCam;
    private bool _isLocked = true;
    private bool _isDamaged = false;
    private Rigidbody2D rb;
    private Vector3 pos;

    void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pos = gameObject.GetComponent<Transform>().position;
        if (Input.GetMouseButton(0) && _isLocked)
        {
            _isLocked = false;
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(3, 5);
            HealthScript.Instance.HeartsUpdate();
        }
        if (_isLocked)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = mainCam.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;
            float minX = mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + PaddleScript.Instance.ReturnPlatW();
            float maxX = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - PaddleScript.Instance.ReturnPlatW();
            float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
            transform.position = new Vector3(clampedX, -2.7f, transform.position.z);
        }
        if (pos.x > 2.94 || pos.x < -2.94 || pos.y > 5.1 || pos.y < -4.1)
        {
            if (!_isDamaged)
            {
                _isDamaged = !_isDamaged;
                _isLocked = true;
                HealthScript.Instance.Damage();
                Invoke("MiniTimer", 0.25f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 linearVelocity = rb.linearVelocity;
        Vector2 curVelocity = linearVelocity;
        if (collision.gameObject.name == "LeftCorner")
        {
            if (curVelocity.x > -6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x - 4, 4);
            }
            else
            {
            }
        }
        if (collision.gameObject.name.StartsWith("LeftMid"))
        {
            if (curVelocity.x > -6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x - 2, 4);
            }
            else
            {
                rb.linearVelocity = new Vector2(6, 4);
            }
        }
        if (collision.gameObject.name.StartsWith("RightMid"))
        {
            if (curVelocity.x < 6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x + 2, 4);
            }
            else
            {
                rb.linearVelocity = new Vector2(6, 4);
            }
        }
        if (collision.gameObject.name.StartsWith("RightCorner"))
        {
            if (curVelocity.x < 6)
            {
                rb.linearVelocity = new Vector2(curVelocity.x + 4, 4);
            }
            else
            {
                rb.linearVelocity = new Vector2(6, 4);
            }
        }
    }

    void MiniTimer()
    {
        _isDamaged = !_isDamaged;
    }
}
