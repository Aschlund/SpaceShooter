using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstanse;


    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Awake()
    {
        bulletPoolInstanse = this;


    }

    // Start is called before the first frame update
    void Start()
    {
        //create the dictionary
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            poolDictionary.Add(pool.tag, objectPool);

            GrowPool(pool.tag);

        }
    }

    private void GrowPool(string tag)
    {
        //tries to get an object that dosent exist
        if (!checkTag(tag))
            return;

        //finds correct pool and adds 10 objects
        foreach (Pool pool in pools)
        {
            if (pool.tag != tag)
                continue;
            
            for (int i = 0; i < 10; i++)
            {
                var objectToAdd = Instantiate(pool.prefab);

                objectToAdd.SetActive(false);

                poolDictionary[tag].Enqueue(objectToAdd);
            }
        }
    }


    public GameObject GetBullet(string tag)
    {
        //tries to get an object that dosent exist
        if (!checkTag(tag))
            return null;

        //if the pool is empty, add more objects
        if (poolDictionary[tag].Count == 0)
            GrowPool(tag);

        //gets the object from the pool
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);

        return objectToSpawn;
    }

    public void returnBullet(string tag, GameObject bullet)
    {
        if (!checkTag(tag)) return;

        bullet.gameObject.SetActive(false);
        poolDictionary[tag].Enqueue(bullet);
    }


    private bool checkTag(string tag)
    {
        if (poolDictionary.ContainsKey(tag))
            return true;
        else
        {
            Debug.LogWarning(tag + " is not a key in the pool dictionary");
            return false;
        }
    }
}
