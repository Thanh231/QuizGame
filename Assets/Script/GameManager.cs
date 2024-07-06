using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int numberCurrentQuestion;
    int totalQuestion;
    public Quiz quiz;
    public TextMeshProUGUI totalQuestionText;
    public TextMeshProUGUI scoreText;
    int score;
    public GameObject gameScreen;
    public GameObject endScreen;
    public TextMeshProUGUI finalScore;

    private void Start()
    {
        totalQuestion = quiz.questions.Count;
        totalQuestionText.text = numberCurrentQuestion + "/" + totalQuestion;
        scoreText.text = "Score: "+ score;
        gameScreen.SetActive(true);
        endScreen.SetActive(false);
        
    }
    public void correctAnswer()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
    public void NextQuestion()
    {
        numberCurrentQuestion++;
        totalQuestionText.text = numberCurrentQuestion + "/" + totalQuestion;
    }
    public void EndScreenEnable()
    {
        gameScreen.SetActive(false);
        endScreen.SetActive(true);
        finalScore.text = "Your Score: \n" + score;
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
