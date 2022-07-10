using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject[] EndingObjs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEnding());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartEnding()
    {
        WaitForSeconds WFS = new WaitForSeconds(4f);
        yield return WFS;
        EndingObjs[0].SetActive(true);
        yield return WFS;
        EndingObjs[0].SetActive(false);
        EndingObjs[1].SetActive(true);
        yield return WFS;
        EndingObjs[1].SetActive(false);
        EndingObjs[2].SetActive(true);
        yield return WFS;
        EndingObjs[2].SetActive(false);
        EndingObjs[3].SetActive(true);
        yield return WFS;
        EndingObjs[3].SetActive(false);
        EndingObjs[4].SetActive(true);
        yield return WFS;
        EndingObjs[4].SetActive(false);
        EndingObjs[5].SetActive(true);
        yield return WFS;
        EndingObjs[5].SetActive(false);
        EndingObjs[6].SetActive(true);
    }
}
