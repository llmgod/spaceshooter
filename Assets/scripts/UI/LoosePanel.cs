using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosePanel : MonoBehaviour
{
    public Score Score;
    public StatsPanel ScoreStats;
    public void OnEnable()
    {
        ScoreStats.SetTitle("SCORE");
        ScoreStats.SetInfo(Score.Value.ToString());
    }
}
