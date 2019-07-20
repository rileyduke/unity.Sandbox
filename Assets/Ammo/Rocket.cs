using Helpers.AssetHelpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20.0f;
    public float life = 5.0f;
    public float BlastRadius = 10.0f;
    public float ExplosionForce = 1700f;

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Kill", life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        Explode();
    }

    void Kill()
    {
        Destroy(gameObject);
    }

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
