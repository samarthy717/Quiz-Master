using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="New Question",fileName ="Question")]
public class QuestionS : ScriptableObject

{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter your question here";
    [SerializeField] string[] answers=new string[4];
    [SerializeField] int cranswerindex;
    public string getquestion()
    {
        return question;
    }
    public int getcorrectanswer()
    {
        return cranswerindex;
    }
    public string getanswer(int i)
    {
        return answers[i];
    }
}
