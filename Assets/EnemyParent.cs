using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;
    private int direction = 1;

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        
        if (transform.position.x > 10)
            direction = -1;
        else if (transform.position.x < -10)
            direction = 1;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
