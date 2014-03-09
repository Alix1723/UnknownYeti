using UnityEngine;
using System.Collections;

public class WaypointMover : MonoBehaviour {

    public Transform[] waypoints;

    private Vector3 targetPos;

    void Start()
    {
        targetPos = waypoints[1].position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 8);
    }

    void OnGUI()
    {
        if (Vector3.Distance(transform.position, targetPos) < 2.0f)
        {
            if (GUI.Button(new Rect(0, Screen.height / 2, Screen.width / 3, Screen.height / 2), "LEFT"))
            {
                targetPos = waypoints[0].transform.position;
            }
            if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 2, Screen.width / 3, Screen.height / 2), "MIDDLE"))
            {
                targetPos = waypoints[1].transform.position;
            }
            if (GUI.Button(new Rect((Screen.width / 3) * 2, Screen.height / 2, Screen.width / 3, Screen.height / 2), "RIGHT"))
            {
                targetPos = waypoints[2].transform.position;
            }
        }
    }
}
