using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int CurrentScore = 0;
    [SerializeField]private TextMeshProUGUI scoreText;

    private void Start()
    {
        LoadScore();
        LoadUIScore();
    }

    public void AddScore(int score)
    {
        CurrentScore = CurrentScore + score;
        LoadUIScore();
        saveScore();
    }

    private void Subtractscore(int score)
    {
        CurrentScore = CurrentScore - score;
        LoadUIScore();
        saveScore();
    }

    private void LoadScore()
    {
        Debug.Log("Cargar Puntaje");
        CurrentScore = PlayerPrefs.GetInt("Score");
    }

    private void saveScore()
    {
        Debug.Log("Guardar Puntaje");
        PlayerPrefs.SetInt("Score", CurrentScore);
    }

    private void LoadUIScore()
    {
        scoreText.text = CurrentScore.ToString();
    }
    
}
