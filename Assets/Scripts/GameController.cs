using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text imgYouScore;
    public TMP_Text imgComScore;
    public TMP_Text textResult;

    public Image imgYou;
    public Image imgCom;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorSprite;

    int youScore = 0;
    int comScore = 0;

    void CheckResult(int yourResult)
    {
        int com = Random.Range(1, 4);

        // Update hand icons
        imgYou.sprite = GetSprite(yourResult);
        imgCom.sprite = GetSprite(com);

        // Game logic
        int k = yourResult - com;

        if (k == 0)
        {
            textResult.text = "Draw";
        }
        else if (k == 1 || k == -2)
        {
            textResult.text = "You Win!";
            youScore++;
        }
        else
        {
            textResult.text = "You Lose!";
            comScore++;
        }

        // Update displayed score
        imgYouScore.text = youScore.ToString();
        imgComScore.text = comScore.ToString();

        // Check win condition
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (youScore >= 5)
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (comScore >= 5)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void OnButtonClick(GameObject buttonObject)
    {
        int you = int.Parse(buttonObject.name.Substring(0, 1));
        CheckResult(you);
    }

    Sprite GetSprite(int number)
    {
        switch (number)
        {
            case 1: return rockSprite;
            case 2: return paperSprite;
            case 3: return scissorSprite;
        }
        return null;
    }
}
