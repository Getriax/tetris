using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchMenager : MonoBehaviour
{
    GameObject mainCube;
    GameObject gameMenager;
    int numberOfParent;
    SpawnCubes spawn;
    MoveCubes moveCubes;
    bool Gui = false;
    public Texture back;
    public GUIStyle skin;
    
    void Start()
    {
        
        gameMenager = GameObject.Find("GameMenager");
        spawn = gameMenager.GetComponent<SpawnCubes>();
    }

    void Update()
    {
        numberOfParent = spawn.number;
        mainCube = GameObject.Find("Cube" + (numberOfParent - 4));
        moveCubes = mainCube.GetComponent<MoveCubes>();
    }

   public void MoveLeft()
    {
        moveCubes.MoveLeft();
    }
   public void MoveRight()
    {
        moveCubes.MoveRight();
    }
    public void Rotate()
    {
        moveCubes.Rotate();
    }
    public void DownButtonDown()
    {
        moveCubes.DownButtonDown();
    }
    public void DownButtonUp()
    {
        moveCubes.DownButtonUp();
    }
    public void Pause()
    {
        Gui = true;
        Time.timeScale = 0;
    }
    void OnGUI()
    {
        if (Gui)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 110, Screen.height / 2 - 70, 200, 200));
           if ( GUILayout.Button("Restrume", skin) )
            {
                Gui = false;
                Time.timeScale = 1;
            }

           if ( GUILayout.Button("End", skin) )
            {
                spawn.GameIsOver();
            }
            GUILayout.EndArea();
        }
            
        
        
    }




























    /* public static bool guiTouch = false;
     public Button LeftBut;
     public Button RightButt;
     public void TouchInput(Button butt)
     {
         if (Input.touchCount > 0)
         {
             if (butt.gameObject.GetComponent<Collider2D>() == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)))
             {
                 Debug.Log(Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)));
                 switch (Input.GetTouch(0).phase)
                 {
                     case TouchPhase.Began:
                         guiTouch = true;
                         SendMessage("OnFirstTouchBegan", SendMessageOptions.DontRequireReceiver);
                         if(LeftBut == butt)
                         SendMessage("MoveLeft", SendMessageOptions.DontRequireReceiver);
                         else if(RightButt == butt)
                         SendMessage("MoveRight", SendMessageOptions.DontRequireReceiver);
                         else
                         SendMessage("DontWork", SendMessageOptions.DontRequireReceiver); 
                         break;

                     case TouchPhase.Stationary:
                         guiTouch = true;
                         SendMessage("OnFirstTouchStayed", SendMessageOptions.DontRequireReceiver);

                         break;

                     case TouchPhase.Moved:
                         guiTouch = true;
                         SendMessage("OnFirstTouchMoved", SendMessageOptions.DontRequireReceiver);

                         break;

                     case TouchPhase.Ended:
                         guiTouch = false;
                         SendMessage("OnFirstTouchEnded", SendMessageOptions.DontRequireReceiver);
                         break;

                 }
             }
         }
         if (Input.touchCount > 1)
         {
             if (butt == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)))
             {
                 switch (Input.GetTouch(1).phase)
                 {
                     case TouchPhase.Began:
                         guiTouch = true;
                         SendMessage("OnSecondTouchBegan", SendMessageOptions.DontRequireReceiver);
                         break;

                     case TouchPhase.Stationary:
                         guiTouch = true;
                         SendMessage("OnSecondTouchStayed", SendMessageOptions.DontRequireReceiver);
                         break;

                     case TouchPhase.Moved:
                         guiTouch = true;
                         SendMessage("OnSecondtTouchMoved", SendMessageOptions.DontRequireReceiver);
                         break;

                     case TouchPhase.Ended:
                         guiTouch = false;
                         SendMessage("OnSecondTouchEnded", SendMessageOptions.DontRequireReceiver);
                         break;

                 }
             }
         }
     }*/
}