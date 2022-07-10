using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    [SerializeField] private float GroundMoveSpeed;
    [SerializeField] private GameObject[] Grounds;

    void Update()
    {
        GroundObjMove();
    }
    private void GroundObjMove()
    {
        for (int CloudObjIndex = 0; CloudObjIndex < Grounds.Length; CloudObjIndex++)
        {
            Grounds[CloudObjIndex].transform.position -= new Vector3(GroundMoveSpeed * Time.deltaTime, 0, 0);
            if (Grounds[CloudObjIndex].transform.position.x <= -18.5f)
                Grounds[CloudObjIndex].transform.position = new Vector3(19.2f, Grounds[CloudObjIndex].transform.position.y, 0);
        }
    }
}
