using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    [SerializeField] private GameEvent increasePoints;
    [SerializeField] private int maxPoints;

    [SerializeField] private GameEvent _onFullPoints;
    private int currentPoints;
    private int tempMaxPoints;
    public int CurrentPoints => currentPoints;
    public int MaxPoints => tempMaxPoints;

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
        tempMaxPoints = maxPoints;
    
    }
    public void IncreasePoints(int points)
    {
        currentPoints += points;
        increasePoints.Invoke();
        if(currentPoints >= tempMaxPoints)
        {
            tempMaxPoints *= 2;
            _onFullPoints.Invoke();
        }
    }

    public void ResetPoints()
    {
        currentPoints = 0;
        increasePoints.Invoke();
    }

    public void ResetMaxPoints() => tempMaxPoints = maxPoints;
}
