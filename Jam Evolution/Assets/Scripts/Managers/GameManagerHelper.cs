using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerHelper : MonoBehaviour
{
    public void Pause()
    {
        if(GameManager.Instance != null)
            GameManager.Instance.Pause();
    }

    public void Resume()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Resume();
    }
}
