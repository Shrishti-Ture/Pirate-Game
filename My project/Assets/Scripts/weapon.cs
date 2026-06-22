using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce =20f;

    public void Fire()
    {
        GameObject bullet =Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up*fireForce,ForceMode2D.Impulse);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}