using UnityEngine;
using System.Collections;

public class ThrowFootballColliderTrigger : MonoBehaviour {

    public GameObject FootballToTrigger;
    private bool latch = false;

    void OnTriggerEnter(Collider other)
    {
        if (!latch)
        {
            FootballToTrigger.GetComponent<ThrowFootball>().TriggerEvent(gameObject);
            latch = true;
        }
    }
}
