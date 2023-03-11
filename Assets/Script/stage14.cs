using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage14 : MonoBehaviour
{
    // private static bool finish = false;
    public GameObject startpoint;
    //public GameObject plat1;
    public Vector3 localPosition;
    public timer1 time;
    public PlayerController player;
    private int TotalTime;
    private static int curStart = 0;
    public int levelIndex;

    float alpha = 0f;
    /*public*/ private float speed = 0.03f;
    // float starttime ;
    static float timer;
    bool replay = false;

    public GameObject Icoon;
    public GameObject[] Icoon_starts;

    // Start is called before the first frame update
    void Start()
    {
        // starttime = 0;
        Time.timeScale = 1;
        alpha = 0f;
       // plat1.transform.localPosition = new Vector2(Mathf.PingPong(alpha, 40), plat1.transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        player.SetSpeed();
        if(replay == true){
            timer = 0;
            replay = false;
         //   plat1.transform.localPosition = new Vector2(Mathf.PingPong(alpha, 40), plat1.transform.localPosition.y);
        }
        timer += Time.deltaTime;
        if(timer > 1.5f ){
           // plat1.transform.localPosition = new Vector2(Mathf.PingPong(alpha, 40), plat1.transform.localPosition.y);
            alpha += speed ; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Contains("EndPoint")){
            TotalTime = 60 - time.m_seconds;
            if(TotalTime <= 10 && curStart < 3){
                StarController.stars += (3 - curStart);
                curStart = 3;
            }else if(TotalTime <= 20 && curStart < 2){
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
            // SceneManager.LoadScene(collision.gameObject.GetComponent<SceneInfo>().SceneName);
        }
        if (collision.gameObject.tag == "trap"){
            alpha = 0f;
            this.transform.position = startpoint.transform.localPosition;
            replay = true;
        }
    }
    public void Replay()
    {
        alpha = 0f;
        replay = true;
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
