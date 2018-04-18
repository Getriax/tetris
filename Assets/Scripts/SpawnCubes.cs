using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnCubes : MonoBehaviour {
    public GameObject cubeParent;
    public GameObject cubeChild;
    //  public GameObject leftCollider;
    //  public GameObject rightCollider;

    public float where;
    public List<GameObject> cubes;
//    public List<GameObject> leftColliders;
  //  public List<GameObject> rightColliders;
    public int number = 0;
    public bool isTheFigureO = false;
    //    public int number_left = 10;
    //    public int number_right = 10;
    public float addSpeed = 1;
    public bool SpawnCube;
    public Text gameOverText;
    public Text Seconds;
    public Text Minutes;
    public Text LevelTxt;
    public Image witchCube;
    public List<Sprite> figuresSprites;

    float s = 0;
    int h = 0;
    int speedadd = 1;
    int lvl = 1;





    void GameOver()
    {
        for (int i = 0; i < number - 4; i++)
        {
            if (cubes[i] != null)
            {
                if (cubes[i].transform.position.y > 15)
                {
                    gameOverText.text = "Game Over";
                    GameIsOver();
                }
            }
            
        }
    }
    public void GameIsOver()
    {
        
        int besth = PlayerPrefs.GetInt("minutes");
        int bests = PlayerPrefs.GetInt("seconds");
        if (besth == 0 && bests == 0)
        {
            PlayerPrefs.SetInt("seconds", (int)s);
            PlayerPrefs.SetInt("minutes", h);
        }
        if (besth == h)
        {
            if (bests < s)
                PlayerPrefs.SetInt("seconds", (int)s);
        }
        else if (besth < h)
        {
            PlayerPrefs.SetInt("seconds", (int)s);
            PlayerPrefs.SetInt("minutes", h);
        }

        SceneManager.LoadScene("Menu");
    }
	void InstntCube()
    {
        GameObject Pinst = (GameObject)Instantiate(cubeParent);
        Pinst.name = "Cube" + number;
        number++;
        cubes.Add(Pinst);
        for (int i = 0; i < 3; i++)
        {
            GameObject instant = (GameObject)Instantiate(cubeChild);
            instant.name = "Cube" + number;
            number++;
            cubes.Add(instant);
            
        }
    /*    for (int j = 0; j < 4; j++)
        {
            GameObject instantLeft = (GameObject)Instantiate(leftCollider);
            instantLeft.name = "LeftColliderr" + number_left;
            number_left++;
            leftColliders.Add(instantLeft);

            GameObject instantRight = (GameObject)Instantiate(rightCollider);
            instantRight.name = "RightCollider" + number_right;
            number_right++;
            rightColliders.Add(instantRight);
        } */
       
        
    }
    void SetingAParent()
    {
        for (int i = cubes.Count - 3; i <= cubes.Count - 1; i++)
        {
            cubes[i].transform.SetParent(cubes[cubes.Count - 4].transform);
        }
    }
    void RenderingNextCube()
    {
        
        if (where == 1)
        {
            witchCube.sprite = figuresSprites[0];
        }
        if (where == 2)
        {
            witchCube.sprite = figuresSprites[1];
        }
        if (where == 3)
        {
            witchCube.sprite = figuresSprites[2];
        }
        if (where == 4)
        {
            witchCube.sprite = figuresSprites[3];
        }
        if (where == 5)
        {
            witchCube.sprite = figuresSprites[4];
        }
        if (where == 6)
        {
            witchCube.sprite = figuresSprites[5];
        }
        if (where == 7)
        {
            witchCube.sprite = figuresSprites[6];
        }
        if (witchCube.color != Color.white)
        {
            witchCube.color = Color.white;
        }
    }

    void RadnomFigures()
    {

        
        if (where == 1)
        {
            int times = 0;
            // "I"
            for (int i = cubes.Count - 4; i <= cubes.Count - 1; i++)
            {

                cubes[i].transform.position = new Vector3(5, 19 + times);
         //       leftColliders[i].transform.position = new Vector3(4.6f, 19 + times);
         //       rightColliders[i].transform.position = new Vector3(5.4f, 19 + times);
                times++;
                if (times > 3)
                {
                    cubes[i].transform.position = new Vector3(5, 18);
         //           leftColliders[i].transform.position = new Vector3(4.6f, 18);
          //          rightColliders[i].transform.position = new Vector3(5.4f, 19);
                }
            }
        }
        // "T"
        if (where == 2)
        {
            int times = 0;
            int num = -1;
            for (int i = cubes.Count - 4; i <= cubes.Count - 1; i++)
            {
                cubes[i].transform.position = new Vector3(5, 19 - times);
         //       leftColliders[i].transform.position = new Vector3(4.6f, 19 - times);
         //       rightColliders[i].transform.position = new Vector3(5.4f, 19 - times);
                times++;
                if (times > 2)  
                {

                    cubes[i].transform.position = new Vector3(5 + num, 19);
            //        leftColliders[i].transform.position = new Vector3(4.6f + num, 19);
          //          rightColliders[i].transform.position = new Vector3(5.4f + num, 19);
                    num += 2;
                }
            }
        }
        // "O"
        if (where == 3)
        {
            int times = 0;
            int num = 0;
            for (int i = cubes.Count - 4; i <= cubes.Count - 1; i++)
            {
                
                cubes[i].transform.position = new Vector3(5 + times, 19);
          //      leftColliders[i].transform.position = new Vector3(4.6f + times, 19);
          //      rightColliders[i].transform.position = new Vector3(5.4f + times, 19);

                times++;
                if (times > 2)
                {

                    cubes[i].transform.position = new Vector3(5 + num, 18);
               //     leftColliders[i].transform.position = new Vector3(4.6f + num, 18);
               //     rightColliders[i].transform.position = new Vector3(5.4f + num, 18);
                    num++;
                }
            }
        }
        // "L"
        if (where == 4)
        {
            int times = 0;
            
            for (int i = cubes.Count - 4; i <= cubes.Count - 1; i++)
            {
                cubes[i].transform.position = new Vector3(5, 19 + times);
             //   leftColliders[i].transform.position = new Vector3(4.6f, 19 + times);
              //  rightColliders[i].transform.position = new Vector3(5.4f, 19 + times);
                times++;
                if (times > 2)
                {
                    cubes[i].transform.position = new Vector3(5, 18);
                   // leftColliders[i].transform.position = new Vector3(4.6f, 18);
                 //   rightColliders[i].transform.position = new Vector3(5.4f, 18);
                }
                if (times > 3)
                {

                    cubes[i].transform.position = new Vector3(6, 18);
               //     leftColliders[i].transform.position = new Vector3(5.6f, 18);
             //       rightColliders[i].transform.position = new Vector3(6.4f, 18);
                }
            }
        }
        // "J"
        if (where == 5)
        {
            int times = 0;

            for (int i = cubes.Count - 4; i <= cubes.Count - 1; i++)
            {
                cubes[i].transform.position = new Vector3(5, 19 + times);
            //    leftColliders[i].transform.position = new Vector3(4.6f, 19 + times);
          //      rightColliders[i].transform.position = new Vector3(5.4f, 19 + times);
                times++;
                if (times > 2)
                {
                    cubes[i].transform.position = new Vector3(5, 18);
              //      leftColliders[i].transform.position = new Vector3(4.6f, 18);
              //      rightColliders[i].transform.position = new Vector3(5.4f, 18);
                }
                if (times > 3)
                {

                    cubes[i].transform.position = new Vector3(4, 18);
             //       leftColliders[i].transform.position = new Vector3(3.6f, 18);
              //      rightColliders[i].transform.position = new Vector3(4.4f, 18);
                }
            }
        }
        // "S"
        if (where == 6)
        {
            int times = 0;
            int num = 0;
            for (int i = cubes.Count - 4; i <= cubes.Count - 1; i++)
            {
                cubes[i].transform.position = new Vector3(5 + times, 19);
            //    leftColliders[i].transform.position = new Vector3(4.6f + times, 19);
            //    rightColliders[i].transform.position = new Vector3(5.4f + times, 19);
                times++;               
                if (times > 2)
                {
                    cubes[i].transform.position = new Vector3(5 - num, 18);
             //       leftColliders[i].transform.position = new Vector3(4.6f - num, 18);
            //        rightColliders[i].transform.position = new Vector3(5.4f - num, 18);

                    num++;
                }
            }
        }
        // "Z"
        if (where == 7)
        {
            int times = 0;
            int num = 0;
            for (int i = cubes.Count - 4; i <= cubes.Count - 1; i++)
            {
                cubes[i].transform.position = new Vector3(5 - times, 19);
             //   leftColliders[i].transform.position = new Vector3(4.6f - times, 19);
              //  rightColliders[i].transform.position = new Vector3(5.4f - times, 19);
                times++;
                if (times > 2)
                {
                    cubes[i].transform.position = new Vector3(5 + num, 18);
              //      leftColliders[i].transform.position = new Vector3(4.6f + num, 18);
               //     rightColliders[i].transform.position = new Vector3(5.4f + num, 18);
                    num++;
                }
            }
        }
    }
    void TimeFunction()
    {
        s += Time.deltaTime;
        string seconds = s.ToString("F2");
        Seconds.text = " : " + seconds;
        if (s >= 60)
        {
            s = 0;
            h++;
            if (h > 10000)
                Minutes.text = "" + h;
            else if(h > 1000)
            Minutes.text = "  " + h;
           else if(h > 100)
            Minutes.text = "    " + h;
           else if (h > 10)
            Minutes.text = "      " + h;
            else
            Minutes.text = "        " + h;
        }
        if (h == speedadd)
        {
            speedadd++;
            addSpeed += .2f;
            lvl++;
            LevelTxt.text = lvl + "";
            
        }

    }
    void Update()
    {
        TimeFunction();
        if (SpawnCube)
        {
            if (where == 3)
            {
                isTheFigureO = true;
            }
            else
            {
                isTheFigureO = false;
            }
            InstntCube();
            RadnomFigures();
            SetingAParent();
            SpawnCube = false;
            gameObject.GetComponent<DestroyScript>().DestroyCube = true;
            GameOver();
            where = Random.Range(1, 8);
            RenderingNextCube();
        }

    }
	
	
	void Start () {
        where =  Random.Range(1, 8);
        if (where == 3)
        {
            isTheFigureO = true;
        }
        else
        {
            isTheFigureO = false;
        }
        InstntCube();
        RadnomFigures();
        SetingAParent();
        where = Random.Range(1, 8);
        RenderingNextCube();


    }
    
}
