using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent _onPaused;
    [SerializeField] private GameEvent _onResumed;
    [SerializeField] private GameEvent _onGameLost;
    [SerializeField] private GameEvent _onGameWon;

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
        ChangeTimeScale(0.0f);
        _isPaused = true;
        _onPaused.Invoke();
    }

    public void Resume()
    {
        ChangeTimeScale(1.0f);
        _isPaused = false;
        _onResumed.Invoke();
    }

    public void LoseGame()
    {
        ChangeTimeScale(0.0f);
        _onGameLost.Invoke();
    }

    public void WinGame()
    {
        ChangeTimeScale(0.0f);
        _onGameWon.Invoke();
    }

    private void ChangeTimeScale(float scale) => Time.timeScale = scale;
}
