using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Referece Variables")]
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRend;
    public Color cyan, yellow, pink, purple;
    public GameObject menuShiz;
    [Header("Value Variables")]
    [Range(5,15)]
        public float jumpForce = 10f;
        public float moveForce = 1f;
    public string currentColor;
    public bool startGame;
    public GameObject controlsPanel;
    public GameObject deathPanel;
    public int currentY;
    public int highestY;
   

    private Vector2 movement;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRend = this.gameObject.GetComponent<SpriteRenderer>();
        startGame = false;
        rigid.bodyType = RigidbodyType2D.Kinematic;
        SetRandomcolor();
        highestY = 0;
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
            }
            
        }
        movement.x = Input.GetAxisRaw("Horizontal") * moveForce;
        currentY = (int)this.transform.position.y;
        if (currentY > highestY)
        {
            highestY = currentY;
        }
        if (currentY <= highestY -5)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0;
        }

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
