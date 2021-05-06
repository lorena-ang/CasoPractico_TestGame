using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Setup() 
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
