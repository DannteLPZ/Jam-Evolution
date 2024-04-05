using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected float _patrolSpeed;
    [SerializeField] protected float _chaseSpeed;

    protected Rigidbody2D _enemyRb;
    protected Transform _target;
    protected bool _playerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            _target = collision.transform;
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true) _playerInRange = false;
    }

    public abstract void PlayerHit();
}
