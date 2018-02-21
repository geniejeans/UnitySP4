using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField]
    private float height = 1.0f;
    [SerializeField]
    private float distance = 3.0f;
    [SerializeField]
    private float damping = 5.0f;

    [SerializeField]
    private float bumperCameraHeight = 1.0f; // adjust camera height while bumping 
    [SerializeField]
    private float bumperDistanceCheck = 5f; // length of bumper ray 
    [SerializeField]
    private Vector3 bumperRayOffset; // allows offset of the bumper ray from target origin

    public Transform target;
    public float lookSmooth = 0.09f;

    CharacterControl charController;
    float rotateVel = 0;
 
    // Use this for initialization
    void Start()
    {
        GetComponent<Camera>().transform.parent = target;
        SetCameraTarget(target);
        PlayerPrefs.DeleteAll();
    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<CharacterControl>())
            {
                charController = target.GetComponent<CharacterControl>();
            }
            else
                Debug.LogError("Target needs character controller");
        }
        else
            Debug.LogError("Camera needs target");
    }

    void LateUpdate()
    {
        MoveToTarget();
        LookAtTarget();
    }

    void MoveToTarget()
    {
        Vector3 wantedPosition = target.TransformPoint(0, height, -distance); // check to see if there is anything behind the target 
        RaycastHit hit;
        Vector3 back = target.transform.TransformDirection(-1 * Vector3.forward); // cast the bumper ray out from rear and check to see if there is anything behind 

        if (Physics.Raycast(target.TransformPoint(bumperRayOffset), back, out hit, bumperDistanceCheck) && hit.transform != target) // ignore ray-casts that hit the user. DR
        { // clamp wanted position to hit position
            wantedPosition.x = hit.point.x;
            wantedPosition.z = hit.point.z;
            wantedPosition.y = Mathf.Lerp(hit.point.y + bumperCameraHeight, wantedPosition.y, Time.deltaTime * damping);
        }

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
    }

    void LookAtTarget()
    {  
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }
}
