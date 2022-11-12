using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler
{
    public GameObject _object;
    protected int _objectsActive;
    public List<GameObject> pool;

    public virtual void Init()
    {
        _objectsActive = 0;
        pool = new List<GameObject>();
    }

    public virtual void Init(GameObject gameObject)
    {
        _object = gameObject;
        _objectsActive = 0;
        pool = new List<GameObject>();
    }

    public GameObject Get()
    {
        GameObject res;
        if(_objectsActive == pool.Count)
        {
            res = GameObject.Instantiate(_object);
            pool.Add(res);
        }
        else
        {
            res = GetDisabledObject();
        }

        _objectsActive++;
        return res;
    }

    public void Release(GameObject gameObject) {

        if (pool.Contains(gameObject))
        {
            gameObject.SetActive(false);
            _objectsActive--;
        }
    }

    private GameObject GetDisabledObject()
    {
        GameObject res = null;
        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                res = pool[i];
                break;
            }
        }
        return res;
    }



}
