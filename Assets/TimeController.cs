using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float limitTime = 0; //制限時間
    public float displayTime = 0; //表示時間
    public float plusTime; //開始時点の経過時間
    public bool isTimeOver = false;
    float times = 0; //現在時間

    // Start is called before the first frame update
    void Start()
    {
        displayTime = limitTime;
        plusTime = GetComponent<GameManager>().countTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeOver == false){
            times += Time.deltaTime;
            displayTime = limitTime - times + plusTime;
            if(displayTime <= 0.0f){
                displayTime = 0.0f;
                isTimeOver = true;
            }
            Debug.Log("TIME: " + displayTime + "plus" + plusTime);
        }
    }
}
