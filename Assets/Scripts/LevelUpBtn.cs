using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpBtn : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    [SerializeField]
    private GameObject levelbar;
    private void Start()
    {
        levelbar.GetComponent<LevelCharge>().Level++;
    }
}
