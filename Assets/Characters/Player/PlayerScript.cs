using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 5.0f;    
    Rigidbody2D rb;
    private int health = 100;
    private float beginGameHealth;
    public bool facingLeft = false;
    public UnityEngine.UI.Image healthImage;
    private float healthWidth;
    public string gameOverScene;
    public Text maintext;
    public Text exptext;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthWidth = healthImage.sprite.rect.width;
        beginGameHealth = health;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        facingLeft = false;
        if (horizontal > 0)
        {
            GetComponent<Animator>().Play("Right");
        } else if (horizontal < 0)
        {
            GetComponent<Animator>().Play("Left");
            facingLeft = true;
        } else if (vertical > 0)
        {
            GetComponent<Animator>().Play("Up");
        } else if (vertical < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            if (health < 1)
            {
                SceneManager.LoadScene("Game Over Scene");
            }
            Vector2 temp = new Vector2(healthWidth * (health / beginGameHealth), healthImage.sprite.rect.height);
            healthImage.rectTransform.sizeDelta = temp;
        }
    }
}