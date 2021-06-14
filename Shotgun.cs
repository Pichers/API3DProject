using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Rigidbody player;
    public Transform cam;

    public float reloadCooldown;
    private float remainingCooldown;

    public int magazine;
    private int bullets;

    public float recoil;
    public Transform shotgunTip;

    //public ParticleSystem particles;
    public Animator animator;


    void Start()
    {
        bullets = magazine;
        remainingCooldown = reloadCooldown;
    }

    
    void Update()
    {
        Debug.Log(bullets);
        if (bullets > 0) 
        {
            if (Input.GetMouseButtonDown(1))
            {
                player.AddForce(-cam.forward * recoil, ForceMode.Impulse);
                bullets -= 1;
                if (bullets == 1)
                    animator.SetTrigger("shot");
            }
        }
        else if (bullets == 0)
        {
            remainingCooldown -= Time.deltaTime;
            if (remainingCooldown != reloadCooldown)
            {
                animator.SetBool("reloading", true);
            }
            if (remainingCooldown <= 0)
            {
                bullets = magazine;
                remainingCooldown = reloadCooldown;
                animator.SetBool("reloading", false);
            }
        }
    }
}
