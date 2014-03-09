using UnityEngine;
using System.Collections;

public class ThrowFootball : MonoBehaviour {

    public GameObject Yeti;
    public GameObject Camera;

    public void TriggerEvent(GameObject origin)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(new Vector3(5, 0, 0) * rigidbody.mass * 300);
    }

    public void Update()
    {
        if (transform.position.y < 1.5f)
        {
            Yeti.GetComponent<SimpleWaypointFollower>().GoToNextWaypoint();
            
            Camera.GetComponent<SimpleWaypointFollower>().GoToNextWaypoint();
            Camera.GetComponent<TrackDragInput>().enabled = true;
            rigidbody.isKinematic = true;
        }
    }
}
