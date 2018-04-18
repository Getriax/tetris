using UnityEngine;
using System.Collections;

public class Triggering : MonoBehaviour
{
    MoveCubes mov;
    GameObject parent;
    int n;
	void Start () {
        n = GameObject.Find("GameMenager").GetComponent<SpawnCubes>().number;
        parent = GameObject.Find("Cube" + (n - 4));
        mov = parent.GetComponent<MoveCubes>();

    }

     void OnTriggerEnter2D(Collider2D other)
      {

          for (int i = n - 5; i >= 0; i--)
          {
            /*   if (other.gameObject.name == "Cube" + i && mov.RotateTime >= 0)
              {

                  Quaternion rot = parent.transform.rotation;
                  float r = rot.eulerAngles.z;
                  r -= 90;
                  rot = Quaternion.Euler(0, 0, r);
                  parent.transform.rotation = rot;
                  mov.RotateTime = 0.1f;
              } */
            if (other.gameObject.name == "Cube" + i)
                 {
                     
                     mov.Trig();
                 }
             }
}


    // Update is called once per frame
    void Update () {
	
	}
}
