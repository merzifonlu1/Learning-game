using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public ItemCollector Items;

    [SerializeField] private Text Notion;

    private bool LevelComplete = false;
    private AudioSource finishSound;

    private void Start()
    {
        Notion.enabled = false;
        finishSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !LevelComplete && Items.totalfruit == 7)
        {
            PlayerMovement moveScript = collision.GetComponent<PlayerMovement>();
            moveScript.canMove = false;
            LevelComplete = true;
            finishSound.Play();
            Invoke("CompleteLevel", 2f);
        }
        if (collision.gameObject.tag == "Player" && Items.totalfruit < 7)
        {
            Notion.enabled = true;
            Notion.text = "COLLECT ALL FRUITS!";
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Items.totalfruit < 7)
        {
            Notion.enabled = false;
        }
    }

    private void CompleteLevel()
    {                   
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);                   
    }
}
