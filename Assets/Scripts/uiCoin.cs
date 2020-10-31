using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class uiCoin : MonoBehaviour
{
    public static uiCoin scoremanager;
    int score;
    public TextMeshProUGUI scr;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scr.text = "x0";
        if (scoremanager == null)
        {
            scoremanager = this;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSCore(int s)
    {
        score += s;
        scr.text = "x" + score.ToString();
    }
}
