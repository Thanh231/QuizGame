using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question",menuName = "Create New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter your question";
    [SerializeField] string[] anwer = new string[4];
    public int correctIndex;

    public string GetQuestion()
    {
        return question;
    }    
    public string GetAnswer(int index)
    {
        return anwer[index];
    }
    public int GetCorrectIndex()
    {
        return correctIndex;
    }
}
