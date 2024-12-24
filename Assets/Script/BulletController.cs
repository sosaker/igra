using System;
using UnityEngine;

public class BulletController: MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    public float speed = 30f;

    private void Update()
    {
        float step =speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
        if(transform.position == position )
            Destroy(gameObject);
    }

}

