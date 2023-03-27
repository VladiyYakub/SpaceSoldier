using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;

    public float shootFoce;
    public float spread;
    void Update()
    {
        if (Input.GetButton("Fire1"))
            Shoot();
    }

    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0, 0.5f, 5f));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(- spread, spread);
        float y = Random.Range(- spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);
        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithoutSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootFoce, ForceMode.Impulse);
    }
}
