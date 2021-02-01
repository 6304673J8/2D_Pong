using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bounceSource;
    public AudioSource goalSource;
    // Start is called before the first frame update
    void Start()
    {
        bounceSource = GetComponent<AudioSource>();
        goalSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle" || collision.gameObject.tag == "Wall")
        {
            bounceSource.Play();
        }
    }
}
