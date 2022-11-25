using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private void OnDisable()
    {
        GameObject tmp;
        if (Random.Range(0f, 1f) > 0.5)
            tmp = ItemPooler.Instance.hkPooler.Get();
        else
            tmp = ItemPooler.Instance.ammoPooler.Get();
        tmp.transform.position = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            gameObject.SetActive(false);
    }
}
