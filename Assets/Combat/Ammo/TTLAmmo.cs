using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Combat.Ammo
{
    /// <summary>
    /// Generic type for anything that should be sent back to its pool after a predetermined time
    /// </summary>
    public class TTLAmmo : MonoBehaviour
    {
        public float TTL = 5.0f;
        public float Genesis;

        // Start is called before the first frame update
        void Start()
        {
            Genesis = Time.time;
        }
        // Start is called before the first frame update
        void OnEnable()
        {
            Genesis = Time.time;
        }

        public void Kill()
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
