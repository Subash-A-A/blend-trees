using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    float velX = 0.0f;
    float velZ = 0.0f;
    float acceleration = 10f;
    float running = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isRunning = Input.GetKey("left shift");

        if (isRunning && running <= 2)
        {
            running += Time.deltaTime * acceleration;
        }
        else if(!isRunning && running >= 1)
        {
            running -= Time.deltaTime * acceleration;
        }

        if(horizontal > 0 && velX <= 1)
        {
            velX += Time.deltaTime * acceleration;
        }
        if (horizontal < 0 && velX >= -1)
        {
            velX -= Time.deltaTime * acceleration;
        }
        if(horizontal == 0)
        {
            if(velX >= 0)
            {
                velX -= Time.deltaTime * acceleration;
            }
            if(velX <= 0)
            {
                velX += Time.deltaTime * acceleration;
            }
        }

        if(vertical > 0 && velZ <= 1)
        {
            velZ += Time.deltaTime * acceleration;
        }
        if(vertical <= 0 && velZ >= 0)
        {
            velZ -= Time.deltaTime * acceleration;
        }


        animator.SetFloat("VelocityX", velX * running);
        animator.SetFloat("VelocityZ", velZ * running);
    }
}
