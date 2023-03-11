using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int Star;
    public Text showscore;

    // Start is called before the first frame update
    void Start()
    {
        Star = StarController.stars;
    }

    // Update is called once per frame
    void Update()
    {
        showscore.text = Star.ToString();
    }
}
