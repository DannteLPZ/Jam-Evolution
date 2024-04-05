using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    [SerializeField] private GameEvent increasePoints;
    [SerializeField] private int maxPoints;
    private int currentPoints;
    public int CurrentPoints => currentPoints;
    public int MaxPoints => maxPoints;

    public static EvolutionManager Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    
    }
    public void IncreasePoints(int points)
    {
        currentPoints += points;
        increasePoints.Invoke();
        if(currentPoints >= maxPoints)
        {
            //logica para terminar nivel
        }
    }
}
