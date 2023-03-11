using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float fastspeed = 8;
    public float jumpspeed = 10;
    public float bigjumpspeed = 5;
    private Rigidbody2D rbody2D;
    private bool isOnGround;
    
    // public AudioClip[] die = new AudioClip[1];

    // [SerializeField]
    // private AudioSource diesound;

    // enum AudioType{
    //     Die = 0,
    //     // Jump2 = 1
    // }



    public AudioClip[] stepClips = new AudioClip[2];

    [SerializeField]
    private AudioSource stepSource;

    enum AudioType{
        Jump = 0,
        die = 1
    }

    private Animator animator;
    //private bool keydown;
    public const int KEY_UP = 0;
	public const int KEY_LEFT = 1;
	public const int KEY_RIGHT = 2;
	public const int KEY_FIRT = 3;
	
	//连续按键的事件限制
	public const int FRAME_COUNT = 100;
	//仓库中储存技能的数量
	public const int SAMPLE_SIZE = 2;
	//每组技能的按键数量
	public const int SAMPLE_COUNT = 2;
	//技能仓库
	int[,] Sample = 
	{
	    
		{/*KEY_RIGHT,*/KEY_UP,KEY_FIRT},
	
		{/*KEY_LEFT,*/KEY_UP,KEY_FIRT},
	};
    //记录当前按下按键的键值
	int  currentkeyCode =0;
	//标志是否开启监听按键
	bool startFrame = false;
	//记录当前开启监听到现在的时间
	int  currentFrame = 0;
	//保存一段时间内玩家输入的按键组合
	List<int> playerSample;
	//标志完成操作
	bool isSuccess= false;
    //public GameObject player;
    //public Vector3 localPosition;
    float timelost_right = 0;
    float timelost_left = 0;
    bool right_fast = false;
    bool left_fast = false;

    private float timer;
	
    //public GameObject dust;
    //public GameObject foot;

    void Start()
    {
        rbody2D = gameObject.GetComponent<Rigidbody2D>();
        isOnGround = false;
        animator = gameObject.GetComponent<Animator> ();
        playerSample  = new List<int>();
        timelost_right = 0;
        timelost_left = 0;
        right_fast = false;
        left_fast = false;
        speed = 5;
            
    }
    
    void Update()
    {
        // isGrounded = Physics.CheckSphere(groundCheckPos.position, groundDistance, groundMask);

        

        timer += Time.deltaTime;
        float dirx = Input.GetAxisRaw("Horizontal");
        
        if(right_fast != true && left_fast != true){
            rbody2D.velocity = new Vector2(dirx * speed, rbody2D.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            if (Time.time - timelost_right < 0.5f){///0.5秒之内按下有效
                    right_fast = true;
            }
            timelost_right = Time.time;

        }

        if(right_fast == true){
            if(Input.GetKey(KeyCode.RightArrow)){
                if(isOnGround){
                    //Instantiate(dust, foot.transform.position, foot.transform.rotation);
                    animator.speed = 2.5f;
                }
                rbody2D.velocity = new Vector2(dirx * fastspeed, rbody2D.velocity.y);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)){
            right_fast = false;
            animator.speed = 1f;
        }

        // if (Input.GetKey(KeyCode.RightArrow)){
        //     stepSource.PlayOneShot(stepClips[(int)AudioType.Step], 8f);
        // }
        // if (Input.GetKey(KeyCode.LeftArrow)){
        //     stepSource.PlayOneShot(stepClips[(int)AudioType.Step], 8f);
        // }

        // 方向鍵左
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if (Time.time - timelost_left < 0.5f){///0.5秒之内按下有效
                    left_fast = true;
            }
            timelost_left = Time.time;
        }

        if(left_fast == true){
            if(Input.GetKey(KeyCode.LeftArrow)){
                if(isOnGround){
                    // Instantiate(dust, foot.transform.position, foot.transform.rotation);
                    animator.speed = 2.5f;
                }
                rbody2D.velocity = new Vector2(dirx * fastspeed, rbody2D.velocity.y);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)){
            left_fast = false;
            animator.speed = 1f;
        }
    

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            stepSource.PlayOneShot(stepClips[(int)AudioType.Jump], 4f);
           
            isOnGround = false;
            rbody2D.velocity += new Vector2(0, jumpspeed);
        }
        UpdateKey();
        
		
		if(Input.anyKeyDown)
		{
			
			if(isSuccess)
			{
				//按键成功后重置
				isSuccess = false;
				Reset();
			}
			
			if(!startFrame)
			{
				//启动时间计数器
				startFrame = true;
			}
			
			//将按键值添加如链表中
			playerSample.Add(currentkeyCode);
			//遍历链表
			int size = playerSample.Count;
            if (size<SAMPLE_COUNT){

            }//按键数不够
            else{
                for (int k=0;k<size-SAMPLE_COUNT;k++){
                    playerSample.Remove(playerSample[k]);
                }
                for (int i = 0; i < SAMPLE_SIZE; i++){
                    int SuccessCount = 0;
                    for (int j = 0; j < SAMPLE_COUNT; j++){
                        int temp = playerSample[j];
                        if (temp == Sample[i, j]){
                            SuccessCount++;
                        }
                    }
　　　　　　　　　　　　　　　　　　　　//玩家按下的组合按键与仓库中的按键组合相同表示释放技能成功
                    if (SuccessCount == SAMPLE_COUNT){
                        isSuccess = true;                    
                        
                        if(timer >= 1f){
                            isOnGround = false;
                            rbody2D.velocity += new Vector2(0, bigjumpspeed);
                            timer = 0;
                            // stepSource.PlayOneShot(stepClips[(int)AudioType.Jump2], 6f);
                        }
                        break;
                    }
                }
            }

		}
		
		if(startFrame)
		{
			//计数器++
			currentFrame++;
		}
		
		if(currentFrame >= FRAME_COUNT)
		{
			//计数器超时
			if(!isSuccess)
			{
				Reset();
			}
		}
        //if (Input.GetKey(KeyCode.UpArrow) && isOnGround)
        //{
            //keydown = true;    
        //}
        //if (keydown){
            //if (Input.GetKey(KeyCode.Space)){
                //isOnGround = false;
                //rbody2D.velocity += new Vector2(0, bigjumpspeed);
                //keydown = false;
            //}
        //}


        if (!isOnGround)
        {
            // Debug.Log("isOnGround");
            animator.SetInteger("state", 2);
        }
        else if (isSuccess)
        {
            // Debug.Log("isSuccess");
            animator.SetInteger("state", 3);
            if(dirx != 0){
                animator.SetInteger("state", 1);
            }else{
                animator.SetInteger("state", 0);
            }
        }
        else if (dirx != 0)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
        if (dirx * transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(-1 * this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        }
       
        if (Input.GetKeyDown(KeyCode.R)){
            Replay();
        }
        


    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        if (collision.gameObject.tag == "trap"){
            // diesound.PlayOneShot(die[(int)AudioType.Die], 4f);
            stepSource.PlayOneShot(stepClips[(int)AudioType.die], 6f);


        }
    }
    private void OnCollisionExit2D(Collision collision)
    {
        isOnGround = false;
    }
    void Reset ()
	{
	 	//重置按键相关信息
	 	currentFrame = 0;
		startFrame = false;
		playerSample.Clear();
	}
    void UpdateKey()
	{
		//获取当前键盘的按键信息
		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			currentkeyCode = KEY_UP;
		}
		
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			currentkeyCode = KEY_LEFT;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			currentkeyCode = KEY_RIGHT;
		}
		if (Input.GetKeyDown (KeyCode.Space))
		{
			currentkeyCode = KEY_FIRT;
		}
	}
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public bool GetIsOnGround(){
        return isOnGround;
    }

    public void SetSpeed(){
        animator.speed = 1f;
    }

} 
