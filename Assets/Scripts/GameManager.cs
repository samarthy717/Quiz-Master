using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quizzer;
    EndScreen ender;
    void Start()
    {
        quizzer = FindObjectOfType<Quiz>();
        ender = FindObjectOfType<EndScreen>();
        quizzer.gameObject.SetActive(true);
        ender.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quizzer.gmover)
        {
            quizzer.gameObject.SetActive(false);
            ender.gameObject.SetActive(true);
        }
    }
    public void replaylvl()
    {
        quizzer.gmover = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
