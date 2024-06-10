using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessModeScript : MonoBehaviour
{
    private CharacterScript characterScript;
    void Start()
    {
        characterScript = GameObject.FindWithTag("Player").GetComponent<CharacterScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            characterScript.ÝleriHareket();
    }
}
