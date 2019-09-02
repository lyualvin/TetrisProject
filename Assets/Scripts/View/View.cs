using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class View : MonoBehaviour
{

    private Ctrl ctrl;
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform gameUI;
    private GameObject restartButton;
    private GameObject gameOverUI;
    private GameObject settingUI;
    private GameObject rankUI;

    private GameObject mute;

    private Text score;
    private Text highScore;
    private Text gameOverScore;

    private Text rankScore;
    private Text rankHighScore;
    private Text rankNumberGame;


    // Start is called before the first frame update
    void Awake()
    {
        logoName = transform.Find("Canvas/LogoName") as RectTransform;
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        settingUI = transform.Find("Canvas/SettingUI").gameObject;
        gameOverUI = transform.Find("Canvas/GameOverUI").gameObject;
        rankUI = transform.Find("Canvas/RankUI").gameObject;
        restartButton = transform.Find("Canvas/MenuUI/RestartButton").gameObject;

        ctrl = GameObject.FindGameObjectWithTag("Ctrl").GetComponent<Ctrl>();
        mute = transform.Find("Canvas/SettingUI/AudioButton/Mute").gameObject;

        score = transform.Find("Canvas/GameUI/ScoreLabel/Text").GetComponent<Text>();
        highScore = transform.Find("Canvas/GameUI/HighScoreLabel/Text").GetComponent<Text>();
        gameOverScore = transform.Find("Canvas/GameOverUI/Text").GetComponent<Text>();

        rankScore = transform.Find("Canvas/RankUI/ScoreLabel/Text").GetComponent<Text>();
        rankHighScore = transform.Find("Canvas/RankUI/HighLabel/Text").GetComponent<Text>();
        rankNumberGame = transform.Find("Canvas/RankUI/NumberGamesLabel/Text").GetComponent<Text>();

    }

    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true); 
        logoName.DOAnchorPosY(-86.7f, 0.5f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(75f, 0.5f);
    }

    public void HideMenu()
    {
        logoName.DOAnchorPosY(86.7f, 0.5f).OnComplete(delegate { logoName.gameObject.SetActive(false);});
        menuUI.DOAnchorPosY(-75f, 0.5f).OnComplete(delegate { menuUI.gameObject.SetActive(false); });
    }
    public void UpdateGameUI(int score, int highScore = 0)
    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
    }
    public void ShowGameUI(int score, int highScore =0)
    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-79.02f, 0.5f);
    }

    public void HideGameUI()
    {
        gameUI.DOAnchorPosY(79.02f, 0.5f).OnComplete(delegate { gameUI.gameObject.SetActive(false); });
         
    }

    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void ShowGameOverUI(int score = 0)
    { 
        gameOverUI.SetActive(true);
        gameOverScore.text = score.ToString();
    }
    public void HideGameOverUI()
    { 
        gameOverUI.SetActive(false);
    }

    public void OnHomeButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnSettingButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(true);
    } 

    public void SetMuteActice(bool isActice)
    {
        mute.SetActive(isActice);
    }

    public void OnSettingUIClick()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(false);
    }

    //public void OnRankButtonClick()
    //{
    //    ctrl.audioManager.PlayCursor();
    //    rankUI.SetActive(true);
    //}

    public void ShowRankUI(int score, int highScore, int numberGame)
    {
        this.rankScore.text = score.ToString();
        this.rankHighScore.text = highScore.ToString();
        this.rankNumberGame.text = numberGame.ToString();
        rankUI.SetActive(true);

    }
    public void OnRankUIClick()
    {
        ctrl.audioManager.PlayCursor();
        rankUI.SetActive(false);
    }
}
