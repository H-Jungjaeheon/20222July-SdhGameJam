using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���� ���� ��ư")]
    [Header("���� ���� ��ư")]
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
    #region MainMenu���� ���� �Լ�
    /// <summary>
    /// ���θ޴��� �����
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
    #endregion
    


}