using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public Text healthText;

    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void Damage()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
            Application.LoadLevel("End");
        }
    }
}
