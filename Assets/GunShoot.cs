using UnityEngine;

public class GunShoot : MonoBehaviour
{
    #region rocket properties

    public GameObject rocketPrefab;
    public Transform rocketBarrel;
    public float reloadTime = 0.5f;

    private float lastFireTime;

    #endregion

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera;
    public Animator pointnshooty;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time > lastFireTime + reloadTime)
        {
            ShootRocket();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }
    
    /// <summary>
    /// shoot a rocket launcher
    /// </summary>
    void ShootRocket()
    {
        GameObject go = (GameObject)Instantiate(rocketPrefab, rocketBarrel.position, Quaternion.LookRotation(rocketBarrel.forward));
        Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
        lastFireTime = Time.time;
    }

    /// <summary>
    /// shoot a direct raycast
    /// </summary>
    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TakeDmg target = hit.transform.GetComponent<TakeDmg>();
            if(target != null)
            {
                target.TakeDmge(damage);
            }
        }
    }
}
