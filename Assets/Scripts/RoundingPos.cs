using UnityEngine;
using System.Collections;

public class RoundingPos : MonoBehaviour {
    bool DoRounding;
    MoveCubes cub;
    Transform[] childd;

    // Use this for initialization
    void Start () {
        childd = gameObject.GetComponentsInChildren<Transform>();
        cub = gameObject.GetComponent<MoveCubes>();
	}
	
	// Update is called once per frame
	void Update () {
        DoRounding = cub.IsEnd;
        

        if(DoRounding)
        {
            for (int i = 0; i < 4; i++)
            {
                if(childd[i] != null)
                {
                    Vector3 pos = childd[i].position;
                    float y = Mathf.Round(pos.y);
                    pos.y = y;
                    childd[i].position = pos;
                }
                    
                
               
            }
        }
	
	}
}
