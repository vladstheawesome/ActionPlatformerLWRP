using ActionPlatformer.PooledObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class PoolManager : Singleton<PoolManager>
    {
        public Dictionary<PoolObjectType, List<GameObject>> PoolDictionary = new Dictionary<PoolObjectType, List<GameObject>>();

        public void SetUpDictionary()
        {
            // A list for every ENUM
            PoolObjectType[] arr = System.Enum.GetValues(typeof(PoolObjectType)) as PoolObjectType[];
            
            foreach(PoolObjectType p in arr)
            {
                // If Dictionary doesnt already have a key, we create a new list
                PoolDictionary.Add(p, new List<GameObject>());
            }
        }

        // We want to able to get the object by just specifying the enum
        public GameObject GetObject(PoolObjectType objType)
        {
            if(PoolDictionary.Count == 0)
            {
                SetUpDictionary();
            }

            List<GameObject> list = PoolDictionary[objType];
            GameObject obj = null;

            if(list.Count > 0)
            {
                obj = list[0];
                list.RemoveAt(0);
            }
            else
            {
                obj = PoolObjectLoader.InstantiatePrefab(objType).gameObject;
            }

            return obj;
        }

        // Once an object is used, lets put it back into the pool
        public void AddObject(PoolObject obj)
        {
            List<GameObject> list = PoolDictionary[obj.poolObjectType];
            list.Add(obj.gameObject);
            obj.gameObject.SetActive(false);
        }
    }
}
