using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _attackDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent(out PlayerHealth playerHealth);
        if(playerHealth != null )
        {
            playerHealth.TakeDamage(_attackDamage);
        }
    }
}
