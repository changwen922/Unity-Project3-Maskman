using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneTransition(string _sceneName){
        SceneManager.LoadScene(_sceneName);
    }
    public void BackButton(){
        SceneManager.LoadScene("開始");
    }
}
