using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MoveCubes : MonoBehaviour
{
    SpawnCubes spawn;
    TouchMenager tM;
    public float speed;
    public float addSpeed = 1;
    bool checkO;
    int num;
    int hB;
    int returnValue;
    float time = 0.5f;
 //   public float RotateTime;
    GameObject gameMenager;
    Transform[] child;
    BoxCollider2D[] colliders;
    public bool IsEnd = false;
//    public bool dontBlockLeft = true;
 //   public bool dontBlockRight = true;
    bool colliderSize = true;
    //  public Button but;
    int lastMove = 1;
    float timeToMakeLastMove = 0.4f;
    int position_0 = 1;
    
    
   


    void Start()
    {
        child = gameObject.GetComponentsInChildren<Transform>();
        colliders = gameObject.GetComponentsInChildren<BoxCollider2D>();
        /*     while (forI)
             {
                 if (GameObject.Find("Cube" + serch) == null)
                 {
                     serch += 4;
                 }
                 else
                 {
                     cube = GameObject.Find("Cube" + serch);
                     forI = false;
                 }

             } */

        gameMenager = GameObject.Find("GameMenager");
        spawn = gameMenager.GetComponent<SpawnCubes>();
        checkO = spawn.isTheFigureO;
        num = spawn.number;
        
        

    }
    bool IsCollisionFree(float under)
    {
        returnValue = 0;
        for (int i = 0; i < 4; i++)
        {
            float xP = Mathf.Round(child[i].position.x);
            float yP = Mathf.Round(child[i].position.y) - under;
            for (int j = num - 5; j >= 0; j--)
            {
                if (GameObject.Find("Cube" + j) != null)
                {
                    float cXP = Mathf.Round(GameObject.Find("Cube" + j).transform.position.x);
                    float cYP = Mathf.Round(GameObject.Find("Cube" + j).transform.position.y);


                    if (xP == cXP && yP == cYP)
                    {
                        returnValue++;
                    }
                }
               
            }
        }

        if (returnValue > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Trig()
    {
        
        lastMove = 0;
          
    }
    void EndMoveing()
    {
        if (transform.rotation.eulerAngles.z >= 0 && transform.rotation.eulerAngles.z < 2)
        {
            for (int i = 0; i < 4; i++)
            {
                colliders[i].size = new Vector2(0.4f, 0.1f);
                colliders[i].offset = new Vector2(0, 0.45f);
            }
        }
        else if (transform.rotation.eulerAngles.z >= 180 && transform.rotation.eulerAngles.z < 182)
        {
            for (int i = 0; i < 4; i++)
            {
                colliders[i].size = new Vector2(0.4f, 0.1f);
                colliders[i].offset = new Vector2(0, -0.45f);
            }
        }
        else if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z < 92)
        {
            for (int i = 0; i < 4; i++)
            {
                colliders[i].size = new Vector2(0.1f, 0.4f);
                colliders[i].offset = new Vector2(0.45f, 0);
            }
        }
        else if (transform.rotation.eulerAngles.z >= 270 && transform.rotation.eulerAngles.z < 272)
        {
            for (int i = 0; i < 4; i++)
            {
                colliders[i].size = new Vector2(0.1f, 0.4f);
                colliders[i].offset = new Vector2(-0.45f, 0);
            }

        }
        spawn.SpawnCube = true;
        gameObject.transform.DetachChildren();
        Destroy(this);
    }
    
    void CollidersSize()
    {
        if (transform.rotation.eulerAngles.z >= 0 && transform.rotation.eulerAngles.z < 2 || transform.rotation.eulerAngles.z >= 180 && transform.rotation.eulerAngles.z < 182)
        {
            for (int i = 0; i < 4; i++)
            {
                colliders[i].size = new Vector2(0.4f, 0.99f);
                
            }
                
        }
        else if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z < 92 || transform.rotation.eulerAngles.z >= 270 && transform.rotation.eulerAngles.z < 272)
        {
            for (int i = 0; i < 4; i++)
            {
                colliders[i].size = new Vector2(0.99f, 0.4f);
            }   
        }
    }
    public void MoveLeft()
    {

        bool doMove = true;


        for (int i = 0; i < 4; i++)
        {
            if (child[i].position.x <= 0) // -hB + 9
            {
                doMove = false;
            }
        }
        if (doMove)
        {
            Vector3 pos = transform.position;
            pos.x -= 1;
            transform.position = pos;
        }
        if (!IsCollisionFree(0))
        {
            Vector3 pp = transform.position;
            pp.x += 1;
            transform.position = pp;
        }
    }
    public void MoveRight()
    {
    
        bool doMove = true;

        for (int i = 0; i < 4; i++)
        {
            if (child[i].position.x >= 10)
            // hB + 0.5
            {
                doMove = false;
            }
        }
        if (doMove)
        {
            Vector3 pos = transform.position;
            pos.x += 1;
            transform.position = pos;
        }
        if (!IsCollisionFree(0))
        {
            Vector3 pp = transform.position;
            pp.x -= 1;
            transform.position = pp;
        }


    }
    public void Rotate()
    {
        if (!checkO)
        {
            Quaternion rot = transform.rotation;
            float r = rot.eulerAngles.z;
            r += 90;
            rot = Quaternion.Euler(0, 0, r);
            transform.rotation = rot;
            if (!IsCollisionFree(0))
            {
                Quaternion back = transform.rotation;
                float b = back.eulerAngles.z;
                b -= 90;
                back = Quaternion.Euler(0, 0, b);
                transform.rotation = back;
            }
        }
    }

    public void DownButtonDown()
    {
        addSpeed = 6;
    }
    public void DownButtonUp()
    {
        addSpeed = 1;
    }
	
	void Update () {
        if (IsCollisionFree(1))
            time -= Time.deltaTime * addSpeed * speed * position_0;
        if (lastMove == 0)
        {
            timeToMakeLastMove -= Time.deltaTime;
        }
        if (timeToMakeLastMove <= 0)
        {
            if (!IsCollisionFree(1) || child[0].position.y <= 0 || child[1].position.y <= 0 || child[2].position.y <= 0 || child[3].position.y <= 0)
            EndMoveing();
        }

        // TouchInput(but);
        speed = spawn.addSpeed;
        CollidersSize();
        
   //     RotateTime -= Time.deltaTime * addSpeed;
        if (time <= 0)
        {
            Vector3 wh = transform.position;
            wh.y -= 1;
            transform.position = wh;
            time = 0.5f;
        }
        

        float cameraRatio = (float)Screen.width / (float)Screen.height;
        float HorizontalBorders = Camera.main.orthographicSize * cameraRatio;
        hB = (int)HorizontalBorders;
        
        //Ruch w prawo
        if (Input.GetKeyUp(KeyCode.RightArrow))
            {
            MoveRight();
            }
        
           
        
            //Ruch w lewo
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {

            MoveLeft();
             }
        
       
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            addSpeed = 6; 
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            addSpeed = 1;
        }
        if (!checkO)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Rotate();

            }
        }

        
       
            
        
        for (int i = 0; i < 4; i++)
        {
            
                Vector3 position = child[i].position;
                if (position.y <= 0)
                {
                // position.y - 0.5f <= -Camera.main.orthographicSize + 7.5f
                position_0 = 0;
                position.y = 0;
                    child[i].position = position;
                    IsEnd = true;


                Trig();
                }
                if (position.x > 10.5|| position.x <= -0.5 )
                // hB + 1.5 - hB + 8.5
                {
                    Quaternion rot = transform.rotation;
                    float r = rot.eulerAngles.z;
                    r -= 90;
                    rot = Quaternion.Euler(0, 0, r);
                    transform.rotation = rot;
                }
            
        
        }
       
       
        
    


    }
}
