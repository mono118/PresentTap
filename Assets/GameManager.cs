using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameManager : MonoBehaviour
{
    //時間表示
    public GameObject Timer; //時間テキスト
    TimeController timeCont;
    public GameObject StartTimer; //開始のカウントダウン
    public float countTime = 4.0f; //ゲーム開始までの秒数
    bool gameStart = false; //ゲーム開始の管理
    //UI関係
    public GameObject panel;
    public GameObject Score;
    public GameObject TapButton;

    public int TapCount = 0; //タップ数

    // Start is called before the first frame update
    void Start()
    {
        timeCont = GetComponent<TimeController>();
        panel.SetActive(false);
        TapButton.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart){
            if(timeCont.isTimeOver){ //時間切れ
                //タップボタンの無効化
                Button bt = TapButton.GetComponent<Button>();
                bt.interactable = false;
                Score.GetComponent<Text>().text = TapCount.ToString() + "回";
                panel.SetActive(true); //panelを表示
                TapButton.SetActive(false);
            }
            if(timeCont != null){
                Timer.GetComponent<Text>().text = timeCont.displayTime.ToString("F1");
            }
        }else{
            countTime -= Time.deltaTime;
            int currentTime = (int)countTime;
            if(countTime < 1){
                StartTimer.GetComponent<Text>().fontSize = 200;
                StartTimer.GetComponent<Text>().text = "START!";
                Invoke("InactiveST", 1.0f);
                gameStart = true;
                TapButton.GetComponent<Button>().interactable = true;
                return;
            }
            StartTimer.GetComponent<Text>().text = currentTime.ToString();
        }
    }

    //ボタン押下時
    public void ButtonTap(){
        TapCount += 1;
        Debug.Log("TAP COUNT: " + TapCount);
    }
    //リスタート
    public void Restart(){
        SceneManager.LoadScene("GameStage");
    }
    //タイマーの非表示
    void InactiveST(){
        StartTimer.SetActive(false);
    }
}
