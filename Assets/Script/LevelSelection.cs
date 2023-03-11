using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public bool islock = true;
    public Image lockImage;
    public GameObject[] stars;
    public Sprite starSprite;
    public GameObject Icoon;
    public GameObject[] Icoon_starts;
    public GameObject GUI;
    // public Text Level;
    // public Text Time;

    void Start()
    {
        // PlayerPrefs.DeleteAll();
        // Level = Icoon.GetComponent<Text>();

    }
    public void restart(){
        PlayerPrefs.DeleteAll();
    }
    private void Update(){
        UpdateLevelImage();
        UpdateLevelStatus();
    }
    private void UpdateLevelStatus(){
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if(PlayerPrefs.GetInt("LV" + previousLevelNum.ToString()) > 0){
            islock = false;
        }
    }
    private void UpdateLevelImage(){
        if(islock){
            lockImage.gameObject.SetActive(true);
            
            for(int i=0; i<stars.Length; i++){
                stars[i].gameObject.SetActive(false);
            }
        }
        else{
            lockImage.gameObject.SetActive(false);
            for(int i=0; i<stars.Length; i++){
                stars[i].gameObject.SetActive(true);
            }
            for(int i = 0; i < PlayerPrefs.GetInt("LV" + gameObject.name); i++){
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }
    public void PressSelection(string _Level){
        if(islock == false){
            GUI = GameObject.Find("GUI");
            if(GUI){
                GUI.SetActive(false);
            }
            Icoon.SetActive(true);
            for(int i = 0; i < PlayerPrefs.GetInt("LV" + gameObject.name); i++){
                // Icoon_starts[i].gameObject.GetComponent<Image>().sprite = starSprite;
                Icoon_starts[i].SetActive(true);
            }
            // SceneManager.LoadScene(_Level);

            // Level = GetComponent<Text>();
            // Level.text = _Level;
            // if(_Level == '')
            // Time.text = 
        }
    }
    public void Close(){
        Icoon.SetActive(false);
    }

    public void next(string _Level){
        SceneManager.LoadScene(_Level);
    }
}
