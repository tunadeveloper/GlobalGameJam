using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttoncontroller : MonoBehaviour
{
    public void tekrarOyna()
    {
        SceneManager.LoadScene(1);
    }

    public void Cýk()
    {
        Application.Quit();
    }

    public void Anamenu()
    {
        SceneManager.LoadScene(0);
    }
}
