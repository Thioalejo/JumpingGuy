using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmyController : MonoBehaviour
{
    public float speed = 2.5f;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -9.43) Destroy(gameObject);
    }
}
