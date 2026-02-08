using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed;
    public int damage;
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
