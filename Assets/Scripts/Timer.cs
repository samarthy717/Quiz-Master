using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]float TimerToanswerquestion = 30f;
    [SerializeField]float TimerToDisplayAnswer = 10f;
    public float FillFraction;
    [SerializeField]float Timery= 30f;
    public int k = 0;
    public bool loadnextquestion=true;
    [SerializeField] AudioSource quiztimer;
    [SerializeField] AudioSource backtimer;
    private void Awake()
    {
        quiztimer = GetComponent<AudioSource>();
        backtimer = GetComponent<AudioSource>();
    }
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        if (k == 0) { Timery = 0; }
    }
    private void UpdateTimer()
    {
        Timery -= Time.deltaTime;
        if (Timery <= 0&&k==0)
        {
            Timery = TimerToDisplayAnswer;
            k = 1;
        }
        else if(Timery > 0 && k == 0)
        {
            FillFraction = Timery / TimerToanswerquestion;
        }
        if (k==1&&Timery<=0)
        {
            Timery = TimerToanswerquestion;
            k = 0;
            loadnextquestion = true;
        }
        else if (k == 1 && Timery > 0)    
        {
            FillFraction = Timery / TimerToDisplayAnswer;
           quiztimer.Pause();
           //backtimer.Play();
        }
        //Debug.Log("Value  "+Timery+"   "+FillFraction);

    }
}
