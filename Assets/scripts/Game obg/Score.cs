using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TextMeshProUGUI Text;
    public int Value = 0;
    public float Scale = 1f;

    public void Awake()
    {
        Instance = this;
    }
    public void ChangeScore(int score)
    {
       Value += (int)(score * Scale);
        Text.text = Value.ToString();
    }
}
