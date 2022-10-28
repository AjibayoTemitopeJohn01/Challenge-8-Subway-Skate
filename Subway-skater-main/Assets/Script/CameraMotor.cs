using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    public Transform lookTarget;
    public Vector3 offset = new Vector3(0f, -2f, -1f);

    public bool IsMoving { get; set; }
    public Vector3 rotation = new Vector3(15, 0, 0);

    private void LateUpdate()
    {
        if (!IsMoving)
            return;
        Vector3 desiredPosition = lookTarget.position + offset;
        desiredPosition.x = 0f;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation),0.1f);
    }
}
