using Assets.Ammo.ProjectilePools;
using Assets.Combat.Ammo;
using Assets.Combat.Ammo.ProjectilePools;
using Helpers.AssetHelpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : TTLAmmo
{
    public float speed = 20.0f;
    public float BlastRadius = 10.0f;
    public float ExplosionForce = 1700f;

    public GameObject Explosion;
    
    /// <summary>
    /// update
    /// </summary>
    void Update()
    {
        if(Time.time > Genesis + TTL)
        {
            Kill();
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    /// <summary>
    /// unity behaviour
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        Explode();
    }

    /// <summary>
    /// explode the rocket
    /// </summary>
    void Explode()
    {
        // show explosion effect
        Instantiate(Explosion, transform.position, new Quaternion(0,0,0,0));

        // explode nearby objects
        // - add forces to them
        var ExplodedColliders = Physics.OverlapSphere(transform.position, BlastRadius);

        foreach(var collider in ExplodedColliders)
        {
            // add force
            Rigidbody rb = collider.attachedRigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(ExplosionForce, transform.position, BlastRadius);
            }

            // add damage
            var DamageableObject = collider.GetComponent<Damageable>();
            if(DamageableObject != null)
            {
                Debug.Log("damageable object desu");
            }
        }

        // kill
        Kill();
    }
}
