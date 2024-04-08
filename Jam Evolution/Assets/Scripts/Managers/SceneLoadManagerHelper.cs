using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManagerHelper : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        if (SceneLoadManager.Instance != null)
        {
            SceneLoadManager.Instance.LoadScene(buildIndex);
        }
    }

    public void ReloadCurrentScene()
    {
        if (SceneLoadManager.Instance != null)
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneLoadManager.Instance.LoadScene(buildIndex);
        }
    }
}
