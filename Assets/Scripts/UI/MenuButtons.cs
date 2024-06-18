using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Openlvls()
    {
        SceneManager.LoadScene("levels");
    }

    public void info()
    {
        SceneManager.LoadScene("info");
    }
    public void turorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void start()
    {
        SceneManager.LoadScene("village");
    }

    public void Quit()
    {
        Application.Quit();
    }



}

