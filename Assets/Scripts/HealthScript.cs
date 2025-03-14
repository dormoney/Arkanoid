using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public static HealthScript Instance { get; private set; }
    private int HP;
    private SpriteRenderer[] hearts;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Instance = this;
        HP = 3;
        hearts = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {

    }

    public void Damage()
    {
        HP -= 1;
        if (HP == 2)
        {
            hearts[0].sprite = Resources.Load<Sprite>("Sprites/HealthOut");
        }
        if (HP == 1)
        {
            hearts[1].sprite = Resources.Load<Sprite>("Sprites/HealthOut");
        }
        if (HP == 0)
        {
            HP = 3;
            foreach (var heart in hearts)
            {
                heart.sprite = Resources.Load<Sprite>("Sprites/HealthIs");
            }
            SceneManager.LoadScene("Retry");
        }
    }

    public void HeartsUpdate()
    {
        if (HP == 2)
        {
            hearts[0].sprite = Resources.Load<Sprite>("Sprites/HealthOut");
        }
        if (HP == 1)
        {
            hearts[0].sprite = Resources.Load<Sprite>("Sprites/HealthOut");
            hearts[1].sprite = Resources.Load<Sprite>("Sprites/HealthOut");
        }
    }
}
