using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Referece Variables")]
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRend;
    public Color cyan, yellow, pink, purple;
    public GameObject menuShiz;
    public GameObject cam;
    [Header("Value Variables")]
    [Range(5,15)]
        public float jumpForce = 10f;
        public float moveForce = 1f;
    public string currentColor;
    public bool startGame;
    public GameObject controlsPanel;
    public GameObject deathPanel;
    public GameObject pasuePanel;
    public int currentY;
    public int highestY;
    public int camY;
    public TMP_Text currentYscore;
    public TMP_Text highestYscore;
    public SceneChanger scenechanger;
    public AudioSource deadMan;
    public AudioClip deed;


    private Vector2 movement;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRend = this.gameObject.GetComponent<SpriteRenderer>();
        startGame = false;
        rigid.bodyType = RigidbodyType2D.Kinematic;
        SetRandomcolor();
        Saving.Load();// loads saved high score
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) //press the space button to start the game
        {
            if(!startGame)
            {
                rigid.bodyType = RigidbodyType2D.Dynamic;
                startGame = true;
                controlsPanel.SetActive(false);
                Time.timeScale = 1;
            }
            
        }
        movement.x = Input.GetAxisRaw("Horizontal") * moveForce;//allows for moving left and right
        currentY = (int)this.transform.position.y;//players position on the y axis
        camY = (int)cam.transform.position.y;// cameras position on the y axis
        currentYscore.text = "Current Y = " + currentY.ToString();//show current y in canvas text
        highestYscore.text = "Highest Y = " + highestY.ToString();//show highest y in canvas text
        if (currentY > highestY)
        {
            highestY = currentY;
            Saving.Save();//saves the highest y in binary
            
        }
        if (currentY <= camY -5)//if the player is 5 spaces below the cameras y axis activate thanatos.  *thanatos is the incarnation of death in greek mythology
        {
            deathPanel.SetActive(true);
            
            Time.timeScale = 0;
        }
        if (Input.GetButtonDown("Cancel"))//press escape to pause
        {
            if (pasuePanel.activeSelf == false && deathPanel.activeSelf == false)
            {
                pauseScreen();
                deadPlayer();
            }
            else if (pasuePanel.activeSelf == true)
            {
                resumeGame();
            }
        }
        if (deathPanel.activeSelf == true)
        {
            Debug.Log("Running");
            deadPlayer();
        }


    }
    public void deadPlayer()
    {
        Debug.Log("Sprinting");
        deadMan.PlayOneShot(deed);
        scenechanger.deadPerson();
    }
    public void pauseScreen()//pause the game and show the pause panel
    {
        pasuePanel.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void resumeGame()//resume the game and hide the pause panel
    {
        pasuePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigid.velocity;
        velocity.x = movement.x;
        rigid.velocity = velocity;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        
            SetRandomcolor();//when the player collides with the platform it changes colour
        
        rigid.velocity = Vector2.up * jumpForce;//when the player collides with the platform it bounces

        scenechanger.onJump();

    }
    void SetRandomcolor()//sets a random colour
    {
        int index = Random.Range(0, 4);
        switch(index)
        {
            case 0:
                currentColor = "Cyan";
                spriteRend.color = cyan;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRend.color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                spriteRend.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                spriteRend.color = purple;
                break;
            default:
                currentColor = "Cyan";
                spriteRend.color = cyan;
                break;
        }
    }
}
