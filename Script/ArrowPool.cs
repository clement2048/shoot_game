using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    public static ArrowPool Instance; // 单例

    public GameObject prefab; // 需要被池化的预制体
    public int poolSize = 10; // 池的大小

    private List<GameObject> objectPool; // 对象池

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeObjectPool();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeObjectPool()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // 如果没有可用的对象，可以考虑动态创建新的对象
        GameObject newObj = Instantiate(prefab);
        objectPool.Add(newObj);
        return newObj;
    }

    public void ResetAndDeactivateObject(GameObject obj)
    {
        obj.SetActive(false);
        // 你可能还需要在这里重置对象的其他属性
    }
}
