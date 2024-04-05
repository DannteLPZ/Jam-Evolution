using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private EnemyController _enemyController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent(out PlayerHealth playerHealth);
        if(playerHealth != null )
        {
            playerHealth.TakeDamage(_attackDamage);
            _enemyController.PlayerHit();
        }
    }
}
