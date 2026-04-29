using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Powerup : MonoBehaviour
{
    public PowerupType powerupType;
    public int level { get; private set; } = 0;
    public Sprite[] Images;
    public Image Back, Front;
    public bool isActive { get; private set; } = false;
    public float Duration;
    private float TimeLeft;

    private void Awake()
    {
        UpdateUI();
        Front.fillAmount = 0;
    }
    public void Upgrade()
    {
        if (isActive)
        {
            TimeLeft += Duration * 0.25f;
            if (TimeLeft > Duration)
            {
                TimeLeft = Duration;
            }
        }
        else
        {
            level++;
            Front.fillAmount = 1;
            TimeLeft = Duration;
            if (level > Images.Length)
            {
                level = Images.Length;
            }
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        if (level <= 0)
        {
            Back.sprite = Images[0];
            Front.sprite = Images[0];
        }
        else
        {
            Back.sprite = Images[level - 1];
            Front.sprite = Images[level - 1];
        }
    }
    public void SetFillAmount(float value)
    {
        Front.fillAmount = value;
    }

    public void Activate(bool startTimer=true)
    {
        if (level > 0)
        {
            isActive = true;
            if (startTimer)
            {
                StartCoroutine(UpdatePowerup());
            }
        }
        
    }
    public void Deactivate()
    {
        Front.fillAmount = 0;
        isActive = false;
        level = 0;
        UpdateUI();
    }
    private IEnumerator UpdatePowerup()
        {
        while (TimeLeft > 0)
         {
            TimeLeft -= Time.deltaTime;
            Front.fillAmount = TimeLeft / Duration;
            yield return null;
         }
        Deactivate();
        }
}
