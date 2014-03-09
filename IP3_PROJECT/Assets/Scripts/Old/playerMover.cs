using UnityEngine;
using System.Collections;

public class playerMover : MonoBehaviour {

    public float CurrentTargetX;
    public bool IsControlled = true;
    public float MoveSpeed = 5;
    
	void Update () {
        if (IsControlled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 tPos = Camera.mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                Debug.Log(tPos);
                CurrentTargetX = tPos.x;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(CurrentTargetX, 1, 0), Time.deltaTime * MoveSpeed);
    
    }

    public void StopControl(GameObject target)
    {
        IsControlled = false;
        CurrentTargetX = target.transform.position.x;
    }

    public void ResumeControl()
    {
        IsControlled = true;
        //CurrentTargetX = target.transform.position.x;
    }

        public void ResumeControl(GameObject optTarget)
        {
            IsControlled = true;
            CurrentTargetX = optTarget.transform.position.x;
        }
}
