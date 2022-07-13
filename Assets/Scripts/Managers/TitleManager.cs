using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("게임 종료 버튼")]
    [Header("게임 종료 버튼")]
    private Button gameQuit;

    [SerializeField]
    private Image fade;
    [SerializeField]
    private Text starttxt;


    private bool isStart;

    private void Update()
    {
        if (Input.anyKey && isStart == false)
        {
            GoMainMenuScene();
            isStart = true;
        }
    }
    #region MainMenu으로 가는 함수
    /// <summary>
    /// 메인메뉴로 가즈아
    /// </summary>
    private void GoMainMenuScene()
    {
        starttxt.gameObject.SetActive(false);
        StartCoroutine(nameof(Fade));
    }
    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
        fade.gameObject.SetActive(false);
        SceneManager.LoadScene("Main");
    }
    private void Start()
    {
        gameQuit.onClick.AddListener(() =>
        {
            QuitGame();
        });
    }

    #endregion
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }




}
