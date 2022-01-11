using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    float acceleration = 3f;
    float deceleration = 1f;
    int VelocityHash;
    float running = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = Input.GetKey("left shift");
        float vertical = Input.GetAxisRaw("Vertical");

        if(isRunning && running <= 2f)
        {
            running += Time.deltaTime * acceleration;
        }
        else if(!isRunning && running >= 1f)
        {
            running -= Time.deltaTime * deceleration;
        }

        if (vertical > 0 && velocity <= 0.5)
        {
            velocity += Time.deltaTime * acceleration;
        }
        else if(vertical <= 0 && velocity >= 0)
        {
            velocity -= Time.deltaTime * deceleration;
        }
        animator.SetFloat(VelocityHash, velocity * running);

    }
}
