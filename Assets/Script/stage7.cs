using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage7 : MonoBehaviour
{
    public timer1 time;
    // private static bool finish = false;
    private int TotalTime;
    public GameObject startpoint;
    public PlayerController player;
    private static int curStart = 0;
    public int levelIndex;

    public GameObject Icoon;
    public GameObject[] Icoon_starts;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        player.fastspeed = 8;
        player.jumpspeed = 12;
        player.bigjumpspeed = 5;

        /*預設
        public float speed = 5;
        public float fastspeed = 8;
        public float jumpspeed = 10;
        public float bigjumpspeed = 11;*/
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("time:" + time.m_seconds.ToString());
        // TotalTime = 60 - time.m_seconds;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Contains("EndPoint")){
            TotalTime = 60 - time.m_seconds;
            if(TotalTime <= 18 && curStart < 3){
                StarController.stars += (3 - curStart);
                curStart = 3;
            }else if(TotalTime <= 25 && curStart < 2){
                StarController.stars += (2 - curStart);
                curStart = 2;
            }else if(TotalTime <= 30 && curStart < 1){
                StarController.stars += (1 - curStart);
                curStart = 1;
            }else{
                if(curStart == 0){
                    StarController.stars += (0 - curStart);
                    curStart = 1;
                }
            }
            PlayerPrefs.SetInt("LV" + levelIndex, curStart);

            //Debug.Log(PlayerPrefs.GetInt("LV" + levelIndex, curStart));
            Debug.Log(StarController.stars);
            Time.timeScale = 0;
            Icoon.SetActive(true);
            for(int i = 0; i < curStart; i++){
                // Icoon_starts[i].gameObject.GetComponent<Image>().sprite = starSprite;
                Icoon_starts[i].SetActive(true);
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(collision.gameObject.GetComponent<SceneInfo>().SceneName);
            // TotalTime = 60 - time.m_seconds;
            // // Debug.Log(SceneManager.GetActiveScene().buildIndex);
            // if(TotalTime <= 8){
            //     Debug.Log("get start: 3");
            // }else if(TotalTime <= 12){
            //     Debug.Log("get start: 2");
            // }else if(TotalTime <= 20){
            //     Debug.Log("get start: 1");
            // }else{
            //     Debug.Log("get start: 0");
            // }

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            //SceneManager.LoadScene(collision.gameObject.GetComponent<SceneInfo>().SceneName);
        }
        if (collision.gameObject.tag == "trap"){
            this.transform.position = startpoint.transform.localPosition;
        }
        //if (collision.gameObject.tag == "box"){
            //this.transform.position = player.transform.localPosition;
        //}
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
    public void BackButton(){
        Debug.Log("Back");
        // SceneManager.LoadScene("選單");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }


    public void next(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
