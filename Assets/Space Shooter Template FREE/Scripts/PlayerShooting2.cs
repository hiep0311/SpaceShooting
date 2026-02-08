using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootingInterval = 0.3f;

    float lastBulletTime;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastBulletTime > shootingInterval)
            {
                Shoot();
                lastBulletTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );
    }
}
