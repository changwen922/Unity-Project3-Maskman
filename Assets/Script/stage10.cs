using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage10 : MonoBehaviour
{
    // private static bool finish = false;
    public GameObject startpoint;
    public Vector3 localPosition;
    public PlayerController player;
    private Rigidbody2D rbody2D;

    public timer1 time;
    private int TotalTime;
    private static int curStart = 0;
    public int levelIndex;
    public GameObject Icoon;
    public GameObject[] Icoon_starts;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        player.fastspeed = 13;
        player.jumpspeed = 4;
        player.bigjumpspeed = 3;
        rbody2D = gameObject.GetComponent<Rigidbody2D>();
        rbody2D.drag = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetIsOnGround() == false){
            player.speed = 13;
        }else{
            player.speed = 5;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Contains("EndPoint")){
            TotalTime = 60 - time.m_seconds;
            if(TotalTime <= 15 && curStart < 3){
                StarController.stars += (3 - curStart);
                curStart = 3;
            }else if(TotalTime <= 30 && curStart < 2){
                StarController.stars += (2 - curStart);
                curStart = 2;
            }else if(TotalTime <= 45 && curStart < 1){
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
        }
        if (collision.gameObject.tag == "trap"){
            this.transform.position = startpoint.transform.localPosition;
        }
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
