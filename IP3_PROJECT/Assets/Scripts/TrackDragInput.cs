using UnityEngine;
using System.Collections;

public class TrackDragInput : MonoBehaviour {

    public int Threshold;

    private float f_DragIncrement = 0;
    private float f_MouseDelta;
    private Vector2 v_LastPos;


    void Start()
    {
        v_LastPos = Input.mousePosition;
    }
    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) & f_DragIncrement < Threshold)
        {
            f_DragIncrement += f_MouseDelta;
        }   
    }

    void Update()
    {
        if (f_DragIncrement >= Threshold)
        {
            //Do something
            gameObject.GetComponent<SimpleWaypointFollower>().GoToNextWaypoint();
        }

        f_MouseDelta = ((Vector2)Input.mousePosition - (Vector2)v_LastPos).magnitude;
        v_LastPos = Input.mousePosition;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height - 40, 200, 30), (int)(f_DragIncrement / Threshold * 100) + "%");
    }
}
