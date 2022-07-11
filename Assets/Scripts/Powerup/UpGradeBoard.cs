using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeBoard : MonoBehaviour
{
    [SerializeField]
    protected float[] needMoney;
    [SerializeField]
    protected string skillName;
    [SerializeField]
    protected Sprite skillImage;
    [SerializeField]
    protected Button upGradeBtn;
    [SerializeField]
    protected int level;
}
