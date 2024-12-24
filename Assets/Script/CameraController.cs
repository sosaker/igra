using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 100.0f; 
    public float moveSpeed = 10.0f; 
    public float minY = 1.5f;   
    public float maxY = 21f;       

    private void Update()
    {
        float rotate = 0f;

        if (Input.GetKey(KeyCode.Q))
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E))
            rotate = 1f; 

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate, Space.World);

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) 
            move += transform.forward;

        if (Input.GetKey(KeyCode.S)) 
            move -= transform.forward;

        if (Input.GetKey(KeyCode.Space)) 
            move += Vector3.up;

        if (Input.GetKey(KeyCode.LeftShift)) 
            move -= Vector3.up;
        
        transform.position += move.normalized * moveSpeed * Time.deltaTime;
    
        LimitCameraHeight();
    }

    private void LimitCameraHeight()
    {
        
        Vector3 position = transform.position;

        
        position.y = Mathf.Clamp(position.y, minY, maxY);
       
        transform.position = position;

        Debug.Log($"Camera Y Position: {transform.position.y}");
    }
}
