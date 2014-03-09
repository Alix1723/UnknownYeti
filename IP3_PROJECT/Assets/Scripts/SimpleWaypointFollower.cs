using UnityEngine;
using System.Collections;

public class SimpleWaypointFollower : MonoBehaviour {

    public Transform[] WaypointsArray;
    public bool StartByMoving;
    public bool Loop;
    public bool FaceDirectionOfTravel;
    public float Speed;

    private int i_WaypointIndex = 0;
    private Vector3 v_CurrentTarget;

    void Start()
    {       //Initialization
        if (WaypointsArray[0] != null)
        {
            if (Speed == 0) 
            { 
                Speed = 1.0f; 
            }
            if (StartByMoving)
            {
                v_CurrentTarget = WaypointsArray[0].position;
                i_WaypointIndex = 0;
            }
            else 
            {
                v_CurrentTarget = transform.position;
                i_WaypointIndex = -1;
            }
        }
    }

	void Update () 
    {
            //Moving the object to the desired position
        transform.position = Vector3.MoveTowards(transform.position, v_CurrentTarget, Speed * Time.deltaTime);
        if (FaceDirectionOfTravel & Vector3.Distance(transform.position,v_CurrentTarget)>0.01f)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2((v_CurrentTarget - transform.position).y, (v_CurrentTarget - transform.position).x),0);
        }
	}

    public void GoToNextWaypoint()
    {
            //Advances to the next waypoint
        if (i_WaypointIndex < WaypointsArray.Length-1)
        {
            i_WaypointIndex++;
            v_CurrentTarget = WaypointsArray[i_WaypointIndex].position;
        }
        else if (Loop)  //Loop back to the first waypoint (0)
        {
            i_WaypointIndex = 0;
        }
        //else do nothing
    }

            //Reset the movement back to the first waypoint (0)
    public void ResetMovement()
    {
        i_WaypointIndex = 0;
        v_CurrentTarget = WaypointsArray[i_WaypointIndex].position;
    }
}
