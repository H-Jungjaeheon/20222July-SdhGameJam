using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public Button gamestart;
    public Button powerupboardBtn;
    public Button gotitle;

    public Text goldtxt;

    public GameObject powerUpBoard;

    private void Start()
    {
        gamestart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("InGame");
        });
        gotitle.onClick.AddListener(() =>
        {
            StartCoroutine(GoTitle());
        });
        powerupboardBtn.onClick.AddListener(() =>
        {
            Debug.Log("�Ŀ��� ����� ����");
            powerUpBoard.SetActive(true);
        });
    }
    private void Update()
    {
        goldtxt.text = GameManager.Instance.Gold.ToString() + "��";
    }
    private IEnumerator GoTitle()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Title");
    }
}
