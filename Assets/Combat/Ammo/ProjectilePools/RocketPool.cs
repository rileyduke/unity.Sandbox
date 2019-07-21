using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Ammo.ProjectilePools
{
    public class RocketPool : MonoBehaviour
    {
        public float PoolSize = 10f;
        public GameObject Prefab;
        private Queue<GameObject> ObjectPool = new Queue<GameObject>();
        public static RocketPool Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GameObject GetFromPool()
        {
            Debug.Log("GetFromPool");
            if(ObjectPool.Count == 0)
            {
                GrowPool();
            }

            var _instance = ObjectPool.Dequeue();
            _instance.SetActive(true);

            return _instance;
        }

        /// <summary>
        /// Adds another PoolSize to the pool if we run out
        /// </summary>
        private void GrowPool()
        {
            for(var i=0; i<PoolSize; i++)
            {
                var AddInstance = Instantiate(Prefab);
                AddInstance.transform.SetParent(transform);

                AddToPool(AddInstance);
            }
        }

        /// <summary>
        /// put the instance back into the queue
        /// </summary>
        /// <param name="Instance"></param>
        private void AddToPool(GameObject Instance)
        {
            Instance.SetActive(false);
            ObjectPool.Enqueue(Instance);
        }

    }
}
