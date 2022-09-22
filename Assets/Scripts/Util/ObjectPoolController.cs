using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    public string objName;
    public GameObject part;
    public int initSize;

    private GameObject parentsObj;

    private Queue<GameObject> pool = new Queue<GameObject>();

    public void Init()
    {
        parentsObj = new GameObject(part.name + "_Pool");
        AddPool(initSize);
    }
    public void AddPool(int size = 1)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject temp = GameObject.Instantiate(part, parentsObj.transform);
            temp.SetActive(false);
            pool.Enqueue(temp);
        }
    }
    public void UseObj(Vector3 pos, Quaternion rot)
    {
        GameObject temp = pool.Dequeue();

        temp.transform.parent = null;
        temp.transform.position = pos;
        temp.transform.rotation = rot;
        temp.SetActive(true);
    }

    public void ReturnObj(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.parent = parentsObj.transform;
        pool.Enqueue(obj);
    }
}

public class ObjectPoolController: MonoBehaviour
{
    public ObjectPool[] pools;
    public static Dictionary<string, ObjectPool> poolDic = new Dictionary<string, ObjectPool>();

    private void Start()
    {
        foreach (var pool in pools)
        {
            pool.Init();
            poolDic.Add(pool.part.name, pool);
        }
    }
}
