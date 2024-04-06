using UnityEngine;

public abstract class EvolutionItem: MonoBehaviour 
{
    [SerializeField] protected int points;
    [SerializeField] protected GameEvent _onPointsGiven;
    protected bool playerInRange;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    protected void GiveEvolutionPoints()
    {
        EvolutionManager.Instance.IncreasePoints(points);
        _onPointsGiven.Invoke();
        Destroy(gameObject);
    }
}
