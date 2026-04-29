using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsPanel : MonoBehaviour
{
    public TextMeshProUGUI Title, Info;
    public void SetTitle(string value)
    {
        Title.text = value;
    }
    public void SetInfo(string value)
    {
        Info.text = value;
    }
}
