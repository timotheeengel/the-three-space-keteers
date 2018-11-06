using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int iScore;

    public string sScoreText;

    private Text tScoreText;
    // Use this for initialization
	void Start ()
    {
        iScore = 0;
        tScoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        tScoreText.text = sScoreText + iScore;
	}

	public void ResetScore()
	{
		iScore = 0;
	}
}
