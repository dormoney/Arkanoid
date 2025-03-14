using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public void ToMain()
    {
        SceneManager.LoadScene("Welcome");
    }

    public void ToFirst()
    {
        SceneManager.LoadScene("1lvl");
    }

    public void ToSecond()
    {
        SceneManager.LoadScene("2lvl");
    }

    public void ToThird()
    {
        SceneManager.LoadScene("3lvl");
    }
}
