using UnityEngine;
using System.Collections;

public class CubeMober : MonoBehaviour {

    private bool isSphere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        float AXIS_Y = Input.GetAxis("Horizontal");
        float AXIS_X = Input.GetAxis("Vertical");
        rigidbody.AddTorque(Time.deltaTime * new Vector3(AXIS_X, 0, -AXIS_Y) * rigidbody.mass * 500);

        if (Input.GetButtonDown("Jump"))
        {
            isSphere = !isSphere;

            if (GetComponent<BoxCollider>())
            {
                Destroy(GetComponent<BoxCollider>());
                gameObject.AddComponent<SphereCollider>();
            }
            else
            {
                Destroy(GetComponent<SphereCollider>());
                gameObject.AddComponent<BoxCollider>();
            }
        }
	}

    void FixedUpdate()
    {

    }
}
