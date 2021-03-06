﻿using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour {


    public GameObject Parent;
    public GameObject Player;
    public AudioSource Hiss;

    // Use this for initialization
    void Start () {
        Player = FindObjectOfType<PlayerStateSystem>().gameObject;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other == Player.GetComponent<CharacterController>())
        {
            Parent.GetComponent<AI>().Pursuit = true;
            Hiss.Play();

        }
    }
    // Update is called once per frame
    void Update () {
	
	}
    
}
