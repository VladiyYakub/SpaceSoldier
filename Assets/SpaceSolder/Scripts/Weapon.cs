using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damge = 21;
    public float fireRate = 1;
    public float distance = 15;
    public GameObject muzzleFlash;
    public AudioClip shotSound;
    public AudioSource audioSoursce;

    public Camera cam;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit,distance))
        {
            Debug.Log("Aim" + hit.collider);
        }
    }
}
