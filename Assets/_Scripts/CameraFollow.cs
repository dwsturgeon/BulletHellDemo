using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = .25f;
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {      
        Vector3 desiredPos = target.position;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
        transform.position = new Vector3(smoothedPos.x, smoothedPos.y, -10f);       
    }

}
