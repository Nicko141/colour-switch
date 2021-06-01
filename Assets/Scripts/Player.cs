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
   

    private Vector2 movement;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRend = this.gameObject.GetComponent<SpriteRenderer>();
        startGame = false;
        rigid.bodyType = RigidbodyType2D.Kinematic;
        SetRandomcolor();
        Saving.Load();
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
        movement.x = Input.GetAxisRaw("Horizontal") * moveForce;
        currentY = (int)this.transform.position.y;
        camY = (int)cam.transform.position.y;
        currentYscore.text = "Current Y = " + currentY.ToString();
        highestYscore.text = "Highest Y = " + highestY.ToString();
        if (currentY > highestY)
        {
            highestY = currentY;
            Saving.Save();
            
        }
        if (currentY <= camY -5)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (pasuePanel.activeSelf == false)
            {
                pauseScreen();
            }
            else if (pasuePanel.activeSelf == true)
            {
                resumeGame();
            }
        }


    }
    public void pauseScreen()
    {
        pasuePanel.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void resumeGame()
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
        
            SetRandomcolor();
        
        rigid.velocity = Vector2.up * jumpForce;

    }
    void SetRandomcolor()
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
