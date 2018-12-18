using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    [SerializeField] string[] tag;

    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        GameObject go = objectPooler.SpawnFromPool( tag[ Random.Range(0, tag.Length) ] , transform.position, transform.rotation);

    }
}
