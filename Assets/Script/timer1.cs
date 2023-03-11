using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer1 : MonoBehaviour
{
    public int m_seconds;                 //倒數計時經換算的總秒數

    public int m_min = 1;              //用於設定倒數計時的分鐘
    public int m_sec = 0;              //用於設定倒數計時的秒數

    public Text m_timer;           //設定畫面倒數計時的文字
    public GameObject m_gameOver;  //設定 GAME OVER 物件
    public GameObject m_button;

    public AudioClip[] stepClips = new AudioClip[1];

    [SerializeField]
    private AudioSource stepSource;

    enum AudioType{
        gameover = 0,
    }

    void Start()
    {
        StartCoroutine(Countdown());
        m_gameOver.SetActive(false);   //呼叫倒數計時的協程
        m_button.SetActive(false);
    }

    IEnumerator Countdown()
    {
        m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        m_seconds = (m_min * 60) + m_sec;       //將時間換算為秒數

        while (m_seconds > 0)                   //如果時間尚未結束
        {
            yield return new WaitForSeconds(1); //等候一秒再次執行

            m_seconds--;                        //總秒數減 1
            m_sec--;                            //將秒數減 1

            if (m_sec < 0 && m_min > 0)         //如果秒數為 0 且分鐘大於 0
            {
                m_min -= 1;                     //先將分鐘減去 1
                m_sec = 59;                     //再將秒數設為 59
            }
            else if (m_sec < 0 && m_min == 0)   //如果秒數為 0 且分鐘大於 0
            {
                m_sec = 0;                      //設定秒數等於 0
            }
            m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        }

        yield return new WaitForSeconds(1);   //時間結束時，顯示 00:00 停留一秒
        m_gameOver.SetActive(true);           //時間結束時，畫面出現 GAME OVER
        m_button.SetActive(true);
        stepSource.PlayOneShot(stepClips[(int)AudioType.gameover], 4f);

        Time.timeScale = 0;                   //時間結束時，控制遊戲暫停無法操作
    }
}
