using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPoolable {

    [SerializeField] float sideVelocity;
    [SerializeField] float upVelocity;

    public void OnObjectPolled()
    {
        Vector3 velocity = new Vector3();
        velocity.x = Random.Range(-sideVelocity, sideVelocity);
        velocity.y = Random.Range(upVelocity / 2, upVelocity);
        velocity.z = Random.Range(-sideVelocity, sideVelocity);

        GetComponent<Rigidbody>().velocity = velocity;
    }

}
