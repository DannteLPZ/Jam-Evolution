using UnityEngine;

public class EvolutionManagerHelper : MonoBehaviour
{
    public void ResetMaxPoints()
    {
        if(EvolutionManager.Instance != null)
        {
            EvolutionManager.Instance.ResetMaxPoints();
        }
    }
}