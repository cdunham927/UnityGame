using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public float lerpSpd;

    public void SetTarget(Transform tr)
    {
        target = tr;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10f), lerpSpd * Time.fixedDeltaTime);
        }
    }
}
