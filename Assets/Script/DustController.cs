// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DustController : MonoBehaviour
// {
//     float i;
//     float timer;
//     private Vector3 scaleChange;
//     // private Rigidbody2D rbody2D;

//     // Start is called before the first frame update
//     void Start()
//     {
//         // this.transform.localScale -= new Vector3(5f, 5f, 5f);
//         Destroy(this.gameObject, 0.15f);
//         timer = 0;        
//         i = 5f;
//         // this.transform.localScale = new Vector3(2, 2, 2);
//         // scaleChange = new Vector3(-0.05f, -0.05f, -0.05f);
//         // rbody2D = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // timer += Time.deltaTime;
//         // if(timer % 0.03 == 0){
//             // this.transform.localScale += scaleChange;
//             // if(this.transform.localPosition.x <= 0){
//                 // Destroy(this);
//             // }
//             // i -= 0.6f;
//         // }
//         this.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
//         if(this.transform.localScale.x <= 0){
//             Destroy(this);
//         }
//     }
// }
