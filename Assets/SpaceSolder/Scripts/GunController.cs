using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject weapon;
    public GameObject bullet;
    public AudioClip shootSound;
    public GameObject shotEffect;
    public GameObject hitEffect;
    public Transform shotPoint;

    public float shotInterval;
    public float shotDistance;
    private float lastShotTime;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time - lastShotTime >= shotInterval)
        {
            lastShotTime = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        GameObject newShotEffect = Instantiate(shotEffect, shotPoint.position, shotPoint.rotation);
        RaycastHit hit;
        if (Physics.Raycast(shotPoint.position, shotPoint.right, out hit, shotDistance))
        {
            Vector3 hitPoint = hit.point;
            Instantiate(hitEffect, hitPoint, Quaternion.LookRotation(hit.normal));
        }
        Destroy(newShotEffect, 0.1f);
    }
}






