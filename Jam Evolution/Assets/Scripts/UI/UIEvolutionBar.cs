using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvolutionBar : MonoBehaviour
{
    [SerializeField] private Image _evolutionBar;

    void Start()
    {
        UpdateEvolutionBar();
    }

    public void UpdateEvolutionBar()
    {
        int currentPoints = EvolutionManager.Instance.CurrentPoints;
        int maxPoints = EvolutionManager.Instance.MaxPoints;
        _evolutionBar.fillAmount = (float)currentPoints / maxPoints;
    }

}
