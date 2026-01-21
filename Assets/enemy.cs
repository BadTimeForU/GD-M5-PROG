using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float Speed = 2f;

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} childs tikkeling {damage} damage HP: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Attack()
    {
        Debug.Log($"{gameObject.name} valt aan!");
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} ging naar diddys huis en mocht niet weg");
        Destroy(gameObject);
    }
}