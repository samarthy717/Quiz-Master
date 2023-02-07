using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ender;
    [SerializeField] GameObject restartbutton;
    Quiz quizzer;
    // Start is called before the first frame update
    void Start()
    {
        ender = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void endgame() {
        ender.text = "Congratulations!\n" + "Score: " + quizzer.score + "%";
    }
    public void restart()
    {

    }
}
