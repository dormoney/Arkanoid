using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public static PaddleScript Instance {  get; private set; }
    private Camera mainCamera;
    private float platformWidth;

    void Start()
    {
        Instance = this;
        mainCamera = Camera.main;
        platformWidth = transform.localScale.x * 3.65f;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        float minX = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + platformWidth;
        float maxX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - platformWidth;
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    public float ReturnPlatW()
    {
        return transform.localScale.x * 3.65f;
    }
}
