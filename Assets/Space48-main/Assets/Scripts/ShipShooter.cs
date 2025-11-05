using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float fireRate = 3f;

    float cooldown;

    public void TryShoot()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            Fire();
            cooldown = 1f / fireRate;
        }
    }

    void Fire()
    {
        if (!laserPrefab) return;
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }
}