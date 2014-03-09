using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture2D MainBackground;
    public Texture2D MainLogo;
    public Texture2D DefaultBackground;

    public Texture2D[] Cutscene2DArray;

    private int i_menuIndex = 0;

    void OnGUI()
    {
        //Title menu
        if(i_menuIndex == 0)
        {
            GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), MainBackground);
            GUI.DrawTexture(new Rect(Screen.width / 4, Screen.height / 6, Screen.width / 2, Screen.width / 4), MainLogo);

            //Next screen
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 5 * 3, 400, 200), "Play"))
            {
                i_menuIndex = 1; 
            }
        }
        //Choose gender
        else if (i_menuIndex == 1)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MainBackground);

            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 3, 200, 70), "Are you a...");

            if (GUI.Button(new Rect(Screen.width / 3 - 125, Screen.height / 5 * 3, 250, 200), "Boy"))
            {
                //TODO: Add a persistent variable for gender, and have it be set here
                i_menuIndex = 2; 
            }

            if (GUI.Button(new Rect((Screen.width / 3) * 2 - 125, Screen.height / 5 * 3, 250, 200), "Girl"))
            {
                //TODO: Add a persistent variable for gender, and have it be set here
                i_menuIndex = 2; 
            }
        }

            //Intro cutscene
        else if(i_menuIndex>1)
        {
            //TODO: Replace with an actual 3D custcene and not rubbish mspaint-level placeholders
            if(i_menuIndex-2 < Cutscene2DArray.Length)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Cutscene2DArray[i_menuIndex - 2]);

                if (GUI.Button(new Rect(Screen.width / 5*3, Screen.height / 4 * 3, 200, 100), "->"))
                {
                    i_menuIndex++;
                }
            }
                else
                {
                    //Application.LoadLevel(Application.loadedLevel+1);
                }
        }   
    }
}
