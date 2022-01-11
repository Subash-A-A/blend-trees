using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    float acceleration = 0.5f;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardPressed = Input.GetAxisRaw("Vertical");

        if (forwardPressed > 0 && velocity <= 1)
        {
            velocity += Time.deltaTime * acceleration;
        }
        else if(forwardPressed <= 0 && velocity >= 0)
        {
            velocity -= Time.deltaTime * acceleration;
        }
        animator.SetFloat(VelocityHash, velocity);

    }
}
