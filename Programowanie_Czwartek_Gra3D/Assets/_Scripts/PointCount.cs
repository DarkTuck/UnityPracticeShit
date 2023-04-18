using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointCount : MonoBehaviour
{
    public int score;
    [SerializeField] TextMeshProUGUI scoretext;
    // Update is called once per frame
    public void ScoreUpdate()
    {
        scoretext.text = $@"SCORE:{score}";
    }
}
