﻿using UnityEngine;

public class KillTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.Instance.Kill();
        }
    }
}
