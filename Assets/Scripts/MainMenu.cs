using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("게임 시작 버튼")]
    [Header("게임 시작 버튼")]
    private Button gameStartbtn;

    [SerializeField]
    [Tooltip("파워업 창띄우는 버튼")]
    [Header("파워업")]
    private Button powerUpBtn;
    [SerializeField]
    [Tooltip("파워업 창")]
    private GameObject powerUpBoard;

    [SerializeField]
    [Tooltip("뒤로가기")]
    [Header("뒤로가기 버튼")]
    private Button backBtn;

    [SerializeField]
    [Header("Money")]
    private Text moneyText;
    
    private int money;
    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            moneyText.text = money.ToString();
        }
    }

    
    private void Start()
    {
        gameStartbtn.onClick.AddListener(() =>
        {
            GameStart();
        });
        powerUpBtn.onClick.AddListener(() =>
        {
            PowerUpBoardActive();
        });
        backBtn.onClick.AddListener(() =>
        {
            backScene();
        });
    }
    #region 파워업창 띄우는 함수
    /// <summary>
    /// 파워업창 띄우기
    /// </summary>
    private void PowerUpBoardActive()
    {
        powerUpBoard.SetActive(true);
    }
    #endregion
    #region 타이틀로 가는 함수
    /// <summary>
    /// 다시 타이틀로 가는 함수
    /// </summary>
    private void backScene()
    {
        SceneManager.LoadScene("Title");
    }
    #endregion
    #region 게임 시작 함수
    private void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }
    #endregion
    #region 게임 나가는 함수
    ///// <summary>
    ///// 게임 나가기
    ///// </summary>
    //private void GameQuit()
    //{
    //    Application.Quit();
    //}
    #endregion//주석
}
