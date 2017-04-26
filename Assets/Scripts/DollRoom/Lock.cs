﻿using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour
{
    public enum LockColors
    {
        NONE, RED, GREEN, BLUE
    }
    [SerializeField]
    private LockColors lockColor;
    [HideInInspector]
    public Color LockColor;
    public bool isLocked; 
	// Use this for initialization
	void Start ()
    {
        isLocked = true;
        switch(lockColor)
        {
            case LockColors.RED:
                LockColor = Color.red;
                break;
            case LockColors.BLUE:
                LockColor = Color.blue;
                break;
            case LockColors.GREEN:
                LockColor = Color.green;
                break;
            default:
                LockColor = Color.black;
                break;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Key>())
        {            
            if(other.GetComponent<Key>().KeyColor == this.LockColor)
            {
                other.transform.parent = this.transform;
                other.transform.localPosition = Vector3.zero;
                isLocked = false;
                Events.LockUnlocked.Invoke();
            }            
        }
    }
}
