
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    public List<QuestionSO> questions;
    QuestionSO currentQuestion;
    public TextMeshProUGUI questionText;
    public GameObject[] answerButton;

    [Header("Sprite")]
    public Sprite defaultSprite;
    public Sprite correctSprite;

    [Header("Timer")]
    public Image timerImage;
    public Timer timer;
    bool hasAnswerEarly;

    [Header("Game Manager")]
    public GameManager gameManager;
    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            gameManager.NextQuestion();
            GetNextQuestion();
            hasAnswerEarly = true;
        }
        else if(hasAnswerEarly && !timer.isAnswering)
        {
            DisplayAnswer(-1);
            SetStateButton(false);
        }
    }
    public void DisPlayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
    public void OnSelected(int index)
    {
        hasAnswerEarly = false;
        DisplayAnswer(index);
        SetStateButton(false);
        timer.CancelTimer();
    }
    public void DisplayAnswer(int index)
    {
        int correct = currentQuestion.GetCorrectIndex();
        if (index == correct)
        {
            questionText.text = "Correct!";
            Image button = answerButton[index].GetComponent<Image>();
            button.sprite = correctSprite;
            gameManager.correctAnswer();
        }
        else
        {
            questionText.text = "Sorry! the correct answer: " + currentQuestion.GetAnswer(correct);
            Image button = answerButton[correct].GetComponent<Image>();
            button.sprite = correctSprite;
        }
    }
    public void SetStateButton(bool state)
    {
        for (int i = 0;i < answerButton.Length;i++)
        {
            Button buttonTemp = answerButton[i].GetComponent<Button>();
            buttonTemp.interactable = state;
        }
    }
    public void SetDefaultState()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image buttomImage = answerButton[i].GetComponent<Image>();
            buttomImage.sprite = defaultSprite;
        }
    }
    public void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            RandomQuestion();
            DisPlayQuestion();
            SetDefaultState();
            SetStateButton(true);
            timer.loadNextQuestion = false;
        }
        else
        {
            gameManager.EndScreenEnable();
        }
    }
    public void RandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        questions.RemoveAt(index);
    }
}
