using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Queue<GameObject> pool;
    public Transform Parent;
    [SerializeField] private GameObject poolObject;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        pool = new Queue<GameObject>();
        Create();
    }

    public void Create()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(poolObject, Parent);
            go.SetActive(false);
            pool.Enqueue(go);
        }
    }
    
    public GameObject Get()
    {
        GameObject go;
        try
        {
            if (pool.TryDequeue(out go))
            {
                go.SetActive(true);
                return go;
            }
            else
            {
                throw new AvaliableObjectNotFound() { NotFound = true };
            }
        }
        catch (AvaliableObjectNotFound e) when (e.NotFound)
        {
            Debug.Log(e.ExceptionMessage);
            go = Instantiate(poolObject, Parent);
            return go;
        }
    }

    public void Release(GameObject go)
    {
        go.SetActive(false);
        pool.Enqueue(go);
    }
}

class AvaliableObjectNotFound : Exception
{
    public bool NotFound { get; set; } = false;
    public string ExceptionMessage = "사용 가능한 오브젝트가 없어 새로운 오브젝트를 생성합니다.. Pool의 Size를 늘려주세요.";
}