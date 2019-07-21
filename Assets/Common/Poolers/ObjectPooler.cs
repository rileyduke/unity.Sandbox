using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Common.Poolers
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler SharedInstance;
        public List<GameObject> Pool;
        public GameObject ObjectToPool;
        public float AmountToPool;

        void Start()
        {
            Pool = new List<GameObject>();
            GrowPool();
        }

        void Awake()
        {
            SharedInstance = this;
        }

        private void GrowPool()
        {
            for (int i = 0; i < AmountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(ObjectToPool);
                obj.SetActive(false);
                Pool.Add(obj);
            }
        }

        public void AddToPool(GameObject ObjectToAdd)
        {

        }

        public GameObject GetPooledObject()
        {
            if (Pool.Count == 0)
            {
                GrowPool();
            }

            GameObject Instance = GetFirstNotActive();

            return Instance;
        }

        public GameObject GetFirstNotActive()
        {
            foreach (var obj in Pool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            GrowPool();
            return GetFirstNotActive();
        }
    }
}
