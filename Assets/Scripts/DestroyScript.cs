using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class DestroyScript : MonoBehaviour
{
    public List<GameObject> CubList;
    public List<GameObject> cubb;
    public bool DestroyCube;
    void DestroyObjects()
    {
        for (int y = 0; y < 15; y++)
        {
            for (int x = 0; x < 11; x++)
            {

                for (int j = 0; j < cubb.Count - 4; j++)
                {
                    if (cubb[j] != null)
                    {
                        float xPos = Mathf.Round(cubb[j].transform.position.x);
                        float yPos = Mathf.Round(cubb[j].transform.position.y);
                        if (xPos == x && yPos == y)
                        {
                            CubList.Add(cubb[j]);
                            
                        }
                    }
                    
                    
                }
         }
         //   Debug.Log(CubList.Count + " na y " + y);
        //    for (int c = 0; c < CubList.Count; c++)
        //    {
        //        Debug.Log(CubList[c] + "Jako klocek nr" + c);
        //    }
            if (CubList.Count == 11)
            {
                for (int i = 0; i < 11; i++)
                {
                    Destroy(CubList[i].gameObject);
                }
                for (int q = 0; q < cubb.Count - 4; q++)
                {
                    if (cubb[q] != null)
                    {
                        if (cubb[q].transform.position.y > y)
                        {
                            Vector3 positionY = cubb[q].transform.position;
                            positionY.y -= 1;
                            cubb[q].transform.position = positionY;
                        }
                    }
                    
                }

            }
            if (CubList.Count > 0)
            {
                int CubListCount = CubList.Count;
                for (int r = 0; r < CubListCount; r++)
                {
                    CubList.RemoveAt(0);
                }
            }
            
            


        }

       /* for (int i = 0; i < cubb.Count - 4; i++)
          {
              float xPos = Mathf.Round(cubb[i].transform.position.x);
              float yPos = Mathf.Round(cubb[i].transform.position.y);

              for (int y = 0; y < 15; y++)
              {
                  for (int x = 0; x < 11; x++)
                {
                    if (xPos == x && yPos == y)
                    {
                        CubList.Add(cubb[i]);
                        Debug.Log("added");
                    }
                }
                  if (CubList.Count >= 10)
                {
                    foreach (GameObject go in CubList)
                    {
                        Destroy(go);
                    }
                }
                  else
                {
                    
                    for (int r = 0; r < CubList.Count; r++)
                    {
                        CubList.RemoveAt(r);
                    }
                }
               
              }
          } */

    }
	
    void Update()
    {
        cubb = gameObject.GetComponent<SpawnCubes>().cubes;
    
                DestroyObjects();

    }
}
