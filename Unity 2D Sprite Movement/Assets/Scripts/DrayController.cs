using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrayController : MonoBehaviour
{
  public float speed = 5;

  public int dirHeld = -1; // Direction of held movement key.

  private Rigidbody rb;
  private Animator anim;

    // Awake is called when the game object becomes active.
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirHeld = -1;
        anim.speed = 0;

        if (Input.GetKey(KeyCode.RightArrow)) {dirHeld = 0;}
        if (Input.GetKey(KeyCode.UpArrow)) {dirHeld = 1;}
        if (Input.GetKey(KeyCode.LeftArrow)) {dirHeld = 2;}
        if (Input.GetKey(KeyCode.DownArrow)) {dirHeld = 3;}

        var vel = Vector3.zero;
        switch (dirHeld) {
          case 0:
            vel = Vector3.right;
            anim.CrossFade("Dray_Walk_" + dirHeld, 0);
            anim.speed = 1;
            break;
          case 1:
            vel = Vector3.up;
            anim.CrossFade("Dray_Walk_" + dirHeld, 0);
            anim.speed = 1;
            break;
          case 2:
            vel = Vector3.left;
            anim.CrossFade("Dray_Walk_" + dirHeld, 0);
            anim.speed = 1;
            break;
          case 3:
            vel = Vector3.down;
            anim.CrossFade("Dray_Walk_" + dirHeld, 0);
            anim.speed = 1;
            break;
        }

        rb.velocity = vel * speed;
    }
}
