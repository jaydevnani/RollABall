using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;

    public float speed;
    public float jumpSpeed;
    public Text countText;
    public Text winText;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate () //physics
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 jumpVel = new Vector3(0f, jumpSpeed, 0f);
            rb.velocity += jumpVel;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
