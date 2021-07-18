using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    float drasticity = 5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GreenBlock")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "YellowBlock")
        {
            collision.gameObject.tag = "GreenBlock";
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
        else if (collision.gameObject.tag == "OrangeBlock")
        {
            collision.gameObject.tag = "YellowBlock";
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
        }
        else if (collision.gameObject.tag == "RedBlock")
        {
            collision.gameObject.tag = "OrangeBlock";
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.3921569f, 0);
        }

        else if (collision.gameObject.tag == "Paddle")
        {
            rb.velocity = new Vector3(rb.velocity.x + drasticity * (transform.position.x - collision.gameObject.transform.position.x), rb.velocity.y);
        }

        else if (collision.gameObject.tag == "Finish")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            SceneManager.LoadScene("GameOver");
        }
    }
}
