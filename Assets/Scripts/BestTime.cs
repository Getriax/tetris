using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BestTime : MonoBehaviour {

    public Text minuty;
    public Text sekundy;
	void Start ()
    {
        int s = PlayerPrefs.GetInt("seconds");
        int h = PlayerPrefs.GetInt("minutes");
        if (h < 10)
            sekundy.text = "" + s;
        else if (h < 100)
            sekundy.text = "  " + s;
        else if (h < 1000)
            sekundy.text = "     " + s;
        else if (h < 10000)
            sekundy.text = "       " + s;
        minuty.text = h + ": ";
	
	}
	
	
}
