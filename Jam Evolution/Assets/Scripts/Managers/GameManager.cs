using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent _onPaused;
    [SerializeField] private GameEvent _onResumed;

    public static GameManager Instance;
    private bool _isPaused;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
            if (_isPaused == true)
                Pause();
            else
                Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        _onPaused.Invoke();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        _onResumed.Invoke();
    }
}
