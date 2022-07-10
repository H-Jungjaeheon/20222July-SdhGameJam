using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField] private float CloudMoveSpeed;
    [SerializeField] private GameObject[] BG = new GameObject[2];

    void Update()
    {
        BGObjMove();
    }
    private void BGObjMove()
    {
        for(int BGObjIndex = 0; BGObjIndex < 2; BGObjIndex++)
        {
            BG[BGObjIndex].transform.position -= new Vector3(CloudMoveSpeed * Time.deltaTime, 0, 0);
            if(BG[BGObjIndex].transform.position.x <= -17.77f)
                BG[BGObjIndex].transform.position = new Vector3(17.76f, BG[BGObjIndex].transform.position.y, 0);
        }
    }
}
