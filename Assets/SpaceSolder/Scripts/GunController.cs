using UnityEngine;

public class GunController : MonoBehaviour
{
    public AudioClip shootSound;
    public GameObject shotEffect;
    public GameObject hitEffect;
    public Transform shotPoint;
    public float shotInterval = 0.1f;
    public float shotDistance = 100f;
    public LayerMask targetMask;
    private float lastShotTime = 0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time - lastShotTime >= shotInterval)
        {
            lastShotTime = Time.time;
            Fire();
        }
    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        GameObject newShotEffect = Instantiate(shotEffect, shotPoint.position, shotPoint.rotation);       
        RaycastHit hit;
        if (Physics.Raycast(shotPoint.position, shotPoint.forward, out hit, shotDistance, targetMask))
        {
            Vector3 hitPoint = hit.point;
            Instantiate(hitEffect, hitPoint, Quaternion.LookRotation(hit.normal));
        }
        Destroy(newShotEffect, 0.1f);
    }
}
