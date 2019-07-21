using Assets.Ammo.ProjectilePools;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    #region rocket properties

    public GameObject rocketPrefab;
    public Transform rocketBarrel;
    public float reloadTime = 0.5f;

    private float lastFireTime;

    private RocketPool _RocketPool { get; set; }

    #endregion

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera;
    public Animator pointnshooty;

    void Start()
    {
        _RocketPool = new RocketPool();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRocketFromPool();
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
    /// shoots a rocket from an object pool instead of instantiating it
    /// </summary>
    void ShootRocketFromPool()
    {
        var Rocket = _RocketPool.GetFromPool();

        Rocket.transform.position = rocketBarrel.position;
        Rocket.transform.position = rocketBarrel.position;

        Rocket.transform.rotation = Quaternion.LookRotation(rocketBarrel.forward);
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
