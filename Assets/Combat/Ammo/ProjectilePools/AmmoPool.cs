using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Combat.Ammo.ProjectilePools
{
    public class AmmoPool : MonoBehaviour
    {
        public float PoolSize;

        public GameObject Prefab;

        public Queue<GameObject> Pool = new Queue<GameObject>();

        public AmmoPool(GameObject _prefab)
        {
            this.Prefab = _prefab;
        }

        /// <summary>
        /// gets an ammo object from the pool
        /// </summary>
        /// <returns></returns>
        public GameObject GetFromPool()
        {
            Debug.Log("GetFromPool");
            if (Pool.Count == 0)
            {
                GrowPool();
            }

            var Instance = Pool.Dequeue();
            Instance.SetActive(true);

            return Instance;
        }

        #region private
        /// <summary>
        /// Adds another PoolSize to the pool if we run out
        /// </summary>
        private void GrowPool()
        {
            for (var i = 0; i < PoolSize; i++)
            {
                var AddInstance = Instantiate(Prefab);
                AddInstance.transform.SetParent(transform);

                AddToPool(AddInstance);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Instance"></param>
        private void AddToPool(GameObject Instance)
        {
            Instance.SetActive(false);
            Pool.Enqueue(Instance);
        }

        #endregion
    }
}
