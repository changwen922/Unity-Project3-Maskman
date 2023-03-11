using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage8 : MonoBehaviour
{
    // private static bool finish = false;
    public GameObject startpoint;
    public GameObject plat1;
    public GameObject plat2;
    public Vector3 localPosition;
    public PlayerController player;
    public timer1 time;
    private int TotalTime;
    private static int curStart = 0;
    public int levelIndex;

    public GameObject Icoon;
    public GameObject[] Icoon_starts;

    float alpha = 0f;
    float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        plat1.transform.localPosition = new Vector2(plat1.transform.localPosition.x ,Mathf.PingPong(alpha, 9));
        plat2.transform.localPosition = new Vector2(plat2.transform.localPosition.x ,Mathf.PingPong(alpha, 9));
        alpha += speed ; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Contains("EndPoint")){
            TotalTime = 60 - time.m_seconds;
            if(TotalTime <= 18 && curStart < 3){
                StarController.stars += (3 - curStart);
                curStart = 3;
            }else if(TotalTime <= 30 && curStart < 2){
                StarController.stars += (2 - curStart);
                curStart = 2;
            }else if(TotalTime <= 50 && curStart < 1){
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
            alpha = 0;
            plat1.transform.localPosition = new Vector2(plat1.transform.localPosition.x ,Mathf.PingPong(alpha, 8));
            plat2.transform.localPosition = new Vector2(plat2.transform.localPosition.x ,Mathf.PingPong(alpha, 8));
            this.transform.position = startpoint.transform.localPosition;
        }
    }
    public void Replay()
    {
        alpha = 0;
        plat1.transform.localPosition = new Vector2(plat1.transform.localPosition.x ,Mathf.PingPong(alpha, 8));
        plat2.transform.localPosition = new Vector2(plat2.transform.localPosition.x ,Mathf.PingPong(alpha, 8));
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
