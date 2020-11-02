using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    // public Text timeText;
    public Animator textAnimator;

    public ParticleSystem deathParticle;
    public SpriteRenderer sprite;
    public Shoot shoot;
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        //textAnimator.Play("DeadTextAnim");

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //Debug.Log(timeRemaining);
                DisplayTime(timeRemaining);
            }
            else
            {                
                timeRemaining = 0;
                timerIsRunning = false;

                Death();         

                //Debug.Log("Timer Run out!");
                //Destroy(gameObject);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    void Death()
    {
        shoot.enabled = false;
        movement.enabled = false;
        sprite.enabled = false;

        deathParticle.Play();

        shoot.Tentacles1.SetPosition(0, transform.position);
        shoot.Tentacles2.SetPosition(0, transform.position);
        shoot.Tentacles3.SetPosition(0, transform.position);
        shoot.Tentacles1.SetPosition(1, transform.position);
        shoot.Tentacles2.SetPosition(1, transform.position);
        shoot.Tentacles3.SetPosition(1, transform.position);

        textAnimator.SetBool("PlayerDead", true);

    }
}
