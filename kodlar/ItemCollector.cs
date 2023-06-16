using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{   
    public int ananaslar = 0;
    public int pizzalar = 0;
    public int totalfruit = 0;

    [SerializeField] private Text ananas;
    [SerializeField] private Text pizza;

    [SerializeField] private AudioSource collectSoundEffect;

    private void Update()
    {
        totalfruit = ananaslar + pizzalar;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ananas"))
        {
            Destroy(collision.gameObject);
            ananaslar++;
            ananas.text = "Ananas: " + ananaslar;
            collectSoundEffect.Play();
        }
        if (collision.gameObject.CompareTag("pizza"))
        {
            Destroy(collision.gameObject);
            pizzalar++;
            pizza.text = "Pizza: " + pizzalar;
            collectSoundEffect.Play();
        }
        
    }


        

    

}
