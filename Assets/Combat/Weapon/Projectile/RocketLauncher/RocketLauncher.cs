using Assets.Combat.Ammo.ProjectilePools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Combat.Weapon.Projectile.RocketLauncher
{
    public class RocketLauncher : IWeapon
    {
        #region rocket properties

        public GameObject rocketPrefab;

        public float reloadTime = 0.5f;

        private float lastFireTime;

        #endregion

        public float damage = 10f;
        public float range = 100f;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootRocketFromPool();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                ShootRocket();
            }
        }

        /// <summary>
        /// shoot a rocket launcher
        /// </summary>
        void ShootRocket()
        {
            GameObject go = (GameObject)Instantiate(rocketPrefab, BarrelInstantiatePoint.position, Quaternion.LookRotation(BarrelInstantiatePoint.forward));
            Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
            lastFireTime = Time.time;
        }

        /// <summary>
        /// shoots a rocket from an object pool instead of instantiating it
        /// </summary>
        void ShootRocketFromPool()
        {
            GameObject Rocket = AmmoPooler.SharedInstance.GetPooledObject();
            if (Rocket != null)
            {
                Rocket.transform.position = BarrelInstantiatePoint.transform.position;
                Rocket.transform.rotation = BarrelInstantiatePoint.transform.rotation;
                Rocket.SetActive(true);
            }
        }

        /// <summary>
        /// shoot a direct raycast
        /// </summary>
        void Shoot()
        {
            RaycastHit hit;

            if (Physics.Raycast(FpsCamera.transform.position, FpsCamera.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                TakeDmg target = hit.transform.GetComponent<TakeDmg>();
                if (target != null)
                {
                    target.TakeDmge(damage);
                }
            }
        }
    }
}
