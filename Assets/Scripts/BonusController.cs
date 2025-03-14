using UnityEngine;

public class BonusController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            Bonus bonus = GetComponent<Bonus>();
            if (bonus != null)
            {
                bonus.Activate(GameObject.FindWithTag("Ball"), other.gameObject);
                Destroy(gameObject);
            }
        }   
    }
}