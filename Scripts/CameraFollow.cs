using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset;   // distance between the camera and the target object
    public float smoothSpeed = 0.125f; // smoother camera movement
/*
    void Start()
    {
        // initial offset (difference between camera and player positions)
        offset = transform.position - target.position;
    }
    */
    void LateUpdate()
    {
        if (target != null)
        {
            // calculate desired position with offset
             Vector3 desiredPosition = (target.position + offset);

            //Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y,transform.position.z);

            // smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // update the camera position
            transform.position = smoothedPosition;
        }
    }
}
