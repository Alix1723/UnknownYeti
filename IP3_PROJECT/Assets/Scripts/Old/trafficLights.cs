using UnityEngine;
using System.Collections;

public class trafficLights : MonoBehaviour {

    public GameObject redLight;
    public GameObject amberLight;
    public GameObject greenLight;
    public GameObject pedGreenLight;
    public GameObject pedRedLight;

    public GameObject waitText;
    public GameObject button;

    public GameObject camAnchor;
    public GameObject playerAnchor;
    public GameObject playerEndAnchor;

    //private int TimerIncrement = 100;
    private bool isActive;
    private bool isPressed;
	
	void Start () {
        redLight.SetActive(false);
        amberLight.SetActive(false);
        pedGreenLight.SetActive(false);
        waitText.SetActive(false);
        isActive = false;
        isPressed = false;
	}
	
	void Update () {
        //TODO: revamp this terrible input handling 
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0) & !isPressed)
            {
                waitText.SetActive(true);
                isPressed = true;
            }
            else if (Input.GetMouseButtonDown(0) & isPressed)
            {
                waitText.SetActive(false);
                redLight.SetActive(false);
                greenLight.SetActive(true);
                pedRedLight.SetActive(false);
                pedGreenLight.SetActive(true);

                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMover>().ResumeControl(playerEndAnchor);
                Camera.mainCamera.GetComponent<cameraMovement>().ReturnFocusToPlayer();
                Debug.Log("Returning to player control");
            }
        }
	}

    public void TriggerInteraction()
    {
        isActive = true;
    }
    
}
