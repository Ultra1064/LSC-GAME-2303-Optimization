using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public ScoreStat score;

    [SerializeField] Text text;


    void Awake ()
    {
        score.score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score.score;
    }
}
