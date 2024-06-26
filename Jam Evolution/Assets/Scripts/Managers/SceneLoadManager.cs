using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Animator _loadingScreen;
    [SerializeField] private Slider _loadingBar;

    [SerializeField] private GameEvent _onSceneLoaded;

    public static SceneLoadManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void LoadScene(int buildIndex)
    {
        _loadingScreen.SetBool("Show", true);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(buildIndex);
        loadOperation.allowSceneActivation = false;
        StartCoroutine(ShowLoadProgress(loadOperation));
    }

    public void LoadNextScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (buildIndex < SceneManager.sceneCountInBuildSettings)
            LoadScene(buildIndex);
        else
            GameManager.Instance.WinGame();
    }

    private IEnumerator ShowLoadProgress(AsyncOperation loadOperation)
    {
        float randomProgress = 0.0f;
        while(randomProgress < 1.0f)
        {
            _loadingBar.value = randomProgress;
            randomProgress += Random.Range(0.1f, 0.3f);
            yield return new WaitForSecondsRealtime(0.2f);
        }
        loadOperation.allowSceneActivation = true;
        _loadingScreen.SetBool("Show", false);
        _onSceneLoaded.Invoke();
    }
}