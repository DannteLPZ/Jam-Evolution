using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadManagerHelper : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        if (SceneLoadManager.Instance != null)
        {
            SceneLoadManager.Instance.LoadScene(buildIndex);
        }
    }
}
