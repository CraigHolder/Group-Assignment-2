﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rug : MonoBehaviour
{
    public player_controller_behavior s_Player;
    private bool b_active;
    //public AudioSource a_audiosource;
    public float f_speedforce = 0.6f;
    public float f_jumpspeeddef;
    public float f_jumptimedef;

    void Start()
    {
        s_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller_behavior>();
        f_jumpspeeddef = s_Player.PLAYER_JUMP;
        f_jumptimedef = s_Player.JumpCost;
    }

    // Start is called before the first frame update
    void OnTriggerStay(Collider collision)
    {
        if (b_active == false && collision.gameObject.tag == "Player")
        {
            s_Player = collision.gameObject.GetComponent<player_controller_behavior>();
            s_Player.PLAYER_SPEED *= f_speedforce;
            s_Player.PLAYER_JUMP = 0f;
            s_Player.JumpCost = 0f;
            //s_Player.b_isgrabbing = false;
            s_Player.DropItem();

            //s_Player.f_jumptimer = s_Player.f_jumptime;
            //c_control.Move(new Vector3(0, i_jumpspeed * Time.deltaTime, 0));
            //s_Player.e_currstate = PlayerMovement.FerretState.Jumping;
            //a_audiosource.Play();
            b_active = true;
        }
        else if (collision.gameObject.tag == "Player")
        {
            //s_Player.b_isgrabbing = false;
            s_Player.DropItem();
        }
    }
    void OnTriggerExit(Collider collision)
    {
        //s_Player = collisionInfo.gameObject.GetComponent<PlayerMovement>();
        if (collision.gameObject.tag == "Player")
        {

            b_active = false;
            s_Player.PLAYER_SPEED *= (1f / f_speedforce);
            s_Player.PLAYER_JUMP = f_jumpspeeddef;
            s_Player.JumpCost = f_jumptimedef;
        }
    }
}
