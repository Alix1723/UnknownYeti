using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

    public GameObject playerObject;

    public GameObject curTarget;

    public bool IsFixed = false;

    private float speed = 10;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, curTarget.transform.position + (!IsFixed ? new Vector3(0, 1, -6) : Vector3.zero), Time.deltaTime * speed);
        transform.rotation = Quaternion.Slerp(transform.rotation,!IsFixed ?  Quaternion.LookRotation(new Vector3(0, 0, 1)) : curTarget.transform.rotation, Time.deltaTime * speed);
    }
    
    public void SetFixedTarget(GameObject target)
    {
        curTarget = target;
        IsFixed = true;
        speed = 2;
        Debug.Log("Moving to focus on " + target.name);
    }

    public void ReturnFocusToPlayer()
    {
        curTarget = playerObject;
        IsFixed = false;
        speed = 8;
        Debug.Log("Returning to player");
    }
}
