using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20.0f;
    public float life = 5.0f;

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
        Kill();
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
