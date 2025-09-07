using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected int amountToPool;

    protected virtual List<GameObject> SetupPool(GameObject objectToPool, GameObject parent)
    {
        List<GameObject> pooledObjects = new List<GameObject>();

        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            tmp.transform.parent = parent.transform;
            pooledObjects.Add(tmp);
        }

        return pooledObjects;
    }

    public virtual GameObject GetPooledObject(List<GameObject> pooledObjects)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
