using UnityEngine;
using System.Collections;

public class CollidersPos : MonoBehaviour {
    string theNumber, lenth;
    string l;
    int strLen, howManyNumbers;
    public bool isItRightColl;
    GameObject theCube;

    int n;
    MoveCubes theScript;
    GameObject parent;
    // Use this for initialization
    void Start () {
        n = GameObject.Find("GameMenager").GetComponent<SpawnCubes>().number;
        parent = GameObject.Find("Cube" + (n - 4));
        theScript = parent.GetComponent<MoveCubes>();

        theNumber =  gameObject.name;
        strLen = theNumber.Length;
        
        if (theNumber[0].CompareTo('R') == 0)
        {
            isItRightColl = true;
        }
        else
        {
            isItRightColl = false;
        }
        
        for (int i = 0; i <= strLen; i++)
        {
            if (i > 14)
            {
                howManyNumbers++;
            }      
        }
        for (int j = 13; j <= 13 + howManyNumbers; j++)
        {
            lenth += theNumber[j];
        }

        theCube = GameObject.Find("Cube" + lenth);
        
        
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = n - 5; i >= 0; i--)
        {
            if (other.gameObject.name == "LeftColliderr" + i || other.gameObject.name == "RightCollider" + i)
            {
                if (isItRightColl)
                {
        //            theScript.dontBlockRight = false;
                }
                else
                {
        //            theScript.dontBlockLeft = false;
                }

            }
        }
    }
    void OnTriggerExit2D()
    {
        if (isItRightColl)
        {
   //         theScript.dontBlockRight = true;
        }
        else
        {
    //        theScript.dontBlockLeft = true;
        }
    }


    // Update is called once per frame
    void Update () {
        Vector3 collPosition = gameObject.transform.position;
        Vector3 cubPossition = theCube.transform.position;

        if (isItRightColl)
        {
            collPosition.x = cubPossition.x + 0.4f;
        }
        else
        {
            collPosition.x = cubPossition.x - 0.4f;
        }
        collPosition.y = cubPossition.y;

        gameObject.transform.position = collPosition;

	}
}
