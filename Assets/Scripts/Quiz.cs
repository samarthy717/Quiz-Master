using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{ 
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] QuestionS question;
    [Header("Buttons")]
    [SerializeField] GameObject[] Buttons;
    [SerializeField] Sprite correctanswerimage;
    [SerializeField] Sprite defaultanswerimage;
    [Header("Timer")]
    [SerializeField] Image TimerImage;
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scorer;
    [SerializeField] Slider slidy;
    [Header("Sounds")]
    [SerializeField] AudioSource correcty;
    [SerializeField] AudioSource wrongy;
    bool isansweredearly = false;
    Timer timer;
    [SerializeField] List<QuestionS> Quizquestions=new List<QuestionS>();
    float quesseen = 0;
    float cranswer = 0;
    public float score = 0;
    float totalques = 0;
    GameManager GM;
    public bool gmover = false;
     void Awake()
    {
        totalques = Quizquestions.Count;
        displayquestion();
        slidy = FindObjectOfType<Slider>();
        timer = FindObjectOfType<Timer>();
        scorer = GetComponent<TextMeshProUGUI>();
        correcty = GetComponent<AudioSource>();
        wrongy = GetComponent<AudioSource>();
        slidy.maxValue = totalques+1;
    }
    private void Update()
    {
        TimerImage.fillAmount = timer.FillFraction;
        if (timer.loadnextquestion)
        {
            displayquestion();
            //scorer.text = "Score: " + score + " %";
            timer.loadnextquestion = false;
            isansweredearly = false;
        }
        else if (!isansweredearly&&(timer.k==1))
        {
            onbuttonclick(5);
        }
        slidy.value = quesseen;
        Debug.Log(score);

    }
    void getrandomquestion()
    {
        if (Quizquestions.Count > 0)
        {
            int p = Random.Range(0, Quizquestions.Count);
            question = Quizquestions[p];
            if (Quizquestions.Contains(question))
            {
                Quizquestions.Remove(question);
            }
        }
        else
        {
            gmover = true;
        }
    }
    public void onbuttonclick(int n) {
        if (n == question.getcorrectanswer())
        {
            cranswer++;
            questiontext.text = "Awesome! Correct Answer";
            Image buttonimage = Buttons[n].GetComponent<Image>();
            buttonimage.sprite = correctanswerimage;
            isansweredearly = true;
            correcty.Play();
        }
        else
        {
            wrongy.Play();
            if ((n == 5)) { questiontext.text = "Sorry ,Time Up"; }
            else { questiontext.text = "Sorry , Wrong Answer"; }
            int p = question.getcorrectanswer();
            Image buttonimage = Buttons[p].GetComponent<Image>();
            buttonimage.sprite = correctanswerimage;
            isansweredearly = true;
        }
        setbuttonstate(false);
        timer.CancelTimer();
        score = Mathf.RoundToInt(((cranswer / quesseen) * 100));       
    }
    void displayquestion()
    {
        quesseen++;
        getrandomquestion();
        questiontext.text = question.getquestion();
        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI buttontext = Buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            Image buttonimage = Buttons[i].GetComponent<Image>();
            buttontext.text = question.getanswer(i);
            buttonimage.sprite = defaultanswerimage;
        }
        setbuttonstate(true);
    }

    public void setbuttonstate(bool state)
    { 
        for(int i = 0; i < 4; i++)
        {
            Button Butt = Buttons[i].GetComponent<Button>();
            Butt.interactable = state;
        }
    }


}
