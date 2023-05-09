using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    
    Rigidbody rb;
    float speed = 8;
   public  Text scoretxt;
    int score;
    bool isgameover;
    public GameObject panelgameover;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {   //moving player
        if (!isgameover)
        {
            float movehorizontal = Input.GetAxis("Horizontal");
            float movevertical = Input.GetAxis("Vertical");
            

            Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
            rb.AddForce(movement * speed);//move player code ends
            // if jumping
          /*  if (Input.GetKey(KeyCode.Space))
            {
                Vector3 pos = transform.position;
                pos.y  += 0.3f;
                transform.position = pos;
                
            }*/
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="cointag")
        {
            Destroy(other.gameObject);
            score++;
            scoretxt.text =("score : "+ score);
        }
        // game over
        if (other.gameObject.tag=="enemytag")
        {
            isgameover = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            Destroy(other.gameObject);
            panelgameover.SetActive(true);
        }
    }
    public void playagainui()
    {
        SceneManager.LoadScene("playgame");
    }
}
