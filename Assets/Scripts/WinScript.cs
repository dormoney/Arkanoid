using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    private BlockScript[] blocks;
    private GameObject[] bedrocks;
    void Start()
    {
        bedrocks = GameObject.FindGameObjectsWithTag("Bedrock");
    }
     
    void Update()
    {
        blocks = GameObject.FindObjectsByType<BlockScript>(FindObjectsSortMode.None);
        if (blocks.Length <= 0) 
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
            Destroy(GameObject.FindGameObjectWithTag("Paddle"));
            foreach (GameObject bedrock in bedrocks)
            {
                Destroy(bedrock);
            }
            gameObject.GetComponent<CanvasScaler>().scaleFactor = 1.0f;
        }
    }
}
