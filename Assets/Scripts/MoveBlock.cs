using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBlock : MonoBehaviour
{
    private float speed = 1f;
    private bool _toDown = true;
    void Start()
    {
        
    }

    void Update()
    {
        MoveDownOrUp();
    }

    private void MoveDownOrUp()
    {        
        if (_toDown)
        {
            transform.Translate(Vector2.down * (speed * Time.deltaTime));

            if (transform.position.y < 0.43f)
            {
                _toDown = false;
            }
        }
        else
        {
            transform.Translate(Vector2.up * (speed * Time.deltaTime));

            if (transform.position.y > 2.255f)
            {
                _toDown = true;
            }
        }
    }
}
