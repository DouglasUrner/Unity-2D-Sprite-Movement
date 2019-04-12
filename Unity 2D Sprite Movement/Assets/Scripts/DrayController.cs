using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrayController : MonoBehaviour
{
  public float speed = 5;

  public int dirHeld = -1; // Direction of held movement key.

  private Rigidbody rb;
  private Animator anim;

    // Start() is called once before the first frame.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update() is called once per frame
    void Update()
    {
      Vector3[] vels = {Vector3.right, Vector3.up, Vector3.left, Vector3.down};
      var vel = Vector3.zero;

      anim.speed = 0; // Speed the animator runs at.

      int dir = -1;

      if (Input.GetKey(KeyCode.RightArrow)) {dir = 0;}
      if (Input.GetKey(KeyCode.UpArrow)) {dir = 1;}
      if (Input.GetKey(KeyCode.LeftArrow)) {dir = 2;}
      if (Input.GetKey(KeyCode.DownArrow)) {dir = 3;}

      if (dir != -1) {
        vel = vels[dir];
        anim.CrossFade("Dray_Walk_" + dir, 0);
        anim.speed = 1;
      }

      rb.velocity = vel * speed;
    }
}
