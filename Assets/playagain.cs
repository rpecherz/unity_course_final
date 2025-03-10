using UnityEngine;
using UnityEngine.SceneManagement;

public class playagain : MonoBehaviour
{
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
