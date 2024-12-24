using System;
using UnityEngine;

public class PlaceObject: MonoBehaviour
{

    public LayerMask layer;
    public float rotateSpeed = 400.0f;

    private void Start()
    {
        PositionObject();
    }

    private void PositionObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, layer))
            transform.position = hit.point;
    }

    private void Update()
    {
        PositionObject();

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<AutoCarCreate>().enabled = true;
            Destroy(gameObject.GetComponent<PlaceObject>());
        }
        if (Input.GetKey(KeyCode.Z))
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

        
    }

}
