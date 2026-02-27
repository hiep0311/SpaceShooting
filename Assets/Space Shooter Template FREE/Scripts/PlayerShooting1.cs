using UnityEngine;

public class PlayerShooting1 : MonoBehaviour
{
    public float speed = 5f;
    public float fireRate = 10f; // Tốc độ bắn (viên/giây)
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioSource shootSound;

    private Camera mainCamera;
    private float nextFireTime = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Di chuyển theo vị trí chuột **cả X và Y** (toàn màn hình)
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z; // Giữ Z (thường là 0 cho 2D)

        // Di chuyển mượt mà theo chuột bằng Lerp
        transform.position = Vector3.Lerp(transform.position, mouseWorldPos, speed * Time.deltaTime);

        // Bắn liên tục khi giữ chuột trái
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        shootSound.Play();
    }
}