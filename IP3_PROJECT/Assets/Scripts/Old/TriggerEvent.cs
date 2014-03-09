using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {
    public GameObject camAnchor;
    public GameObject playerAnchor;
    public GameObject TriggerThisObject;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered light");
        Camera.mainCamera.GetComponent<cameraMovement>().SetFixedTarget(camAnchor);

        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMover>().StopControl(playerAnchor);

        TriggerThisObject.GetComponent<trafficLights>().TriggerInteraction();
    }
}
