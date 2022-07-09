using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���� ���� ��ư")]
    [Header("���� ���� ��ư")]
    private Button gameStartbtn;

    [SerializeField]
    [Tooltip("�Ŀ��� â")]
    [Header("�Ŀ��� â")]
    private Button powerUpBtn;

    [SerializeField]
    [Tooltip("�ڷΰ���")]
    [Header("�ڷΰ��� ��ư")]
    private Button backBtn;

    [SerializeField]
    private GameObject powerUpBoard;


    
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
    #region �Ŀ���â ���� �Լ�
    /// <summary>
    /// �Ŀ���â ����
    /// </summary>
    private void PowerUpBoardActive()
    {
        powerUpBoard.SetActive(true);
    }
    #endregion
    #region Ÿ��Ʋ�� ���� �Լ�
    /// <summary>
    /// �ٽ� Ÿ��Ʋ�� ���� �Լ�
    /// </summary>
    private void backScene()
    {
        SceneManager.LoadScene("Title");
    }
    #endregion
    #region ���� ���� �Լ�
    private void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }
    #endregion
    #region ���� ������ �Լ�
    ///// <summary>
    ///// ���� ������
    ///// </summary>
    //private void GameQuit()
    //{
    //    Application.Quit();
    //}
    #endregion//�ּ�
}
