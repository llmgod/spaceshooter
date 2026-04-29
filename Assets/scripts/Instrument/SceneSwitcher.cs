using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Switch(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Quit()
    {
        Application. Quit();
    }
}
