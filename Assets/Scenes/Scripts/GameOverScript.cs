using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text loseText;

    void Start()
    {
        loseText.text = "";
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            loseText.text = "Game Over!!!";
        }
    }
}
