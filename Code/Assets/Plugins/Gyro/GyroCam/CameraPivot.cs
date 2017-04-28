using UnityEngine;
using System.Collections;

public class CameraPivot : MonoBehaviour
{

    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        
        Quaternion q1 = Input.gyro.attitude;
        if (Input.gyro.attitude == null)
        {
            Debug.Log("gyro not activated");
        }
            
        Quaternion q2 = new Quaternion(q1.y, -q1.z, -q1.x, q1.w);
        transform.localRotation = q2;
    }
}
