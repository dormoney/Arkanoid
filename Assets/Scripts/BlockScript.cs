using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int HealthPoints;
    private SpriteRenderer spriteRenderer;
    private string color;
    public GameObject[] bonusPrefabs;
    public AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = gameObject.name;
        SpriteChange();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HealthPoints -= 1;
        if (other.gameObject.CompareTag("Ball") && HealthPoints > 0)
        {
            color = gameObject.name;
            SpriteChange();
        }
        else if (other.gameObject.CompareTag("Ball"))
        {
            if (Random.Range(0f, 1f) <= 0.333f)
            {
                GenerateBonus();
            }
            Debug.Log("’п при смерти:" + HealthPoints);
            Destroy(gameObject);
            audioSource.Play();
        }
    }

    private string ReturnHP()
    {
        if (HealthPoints == 3)
        {
            return "Full";
        }
        else if (HealthPoints == 2)
        {
            return "Dmgd";
        }
        else if (HealthPoints == 1)
        {
            return "Last";
        }
        else
        {
            return "";
        }
    }
    
    void SpriteChange()
    {
        color = color[..^6];
        spriteRenderer.sprite = Resources.Load<Sprite>($"Sprites/{color + ReturnHP()}");
    }

    private void GenerateBonus()
    {
        int randomIndex = Random.Range(0, bonusPrefabs.Length);
        GameObject bonus = Instantiate(bonusPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
