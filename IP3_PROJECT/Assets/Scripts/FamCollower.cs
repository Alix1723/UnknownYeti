using UnityEngine;
using System.Collections;

public class FamCollower : MonoBehaviour {
    public GameObject Target;

	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + new Vector3(0, 4, -10), Time.deltaTime * 4);
        transform.rotation = Quaternion.LookRotation((Target.transform.position - transform.position).normalized);
	}
}
