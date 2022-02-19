using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;

    private LifesController lifesController;
    private void Awake()
    {
        lifesController = GetComponent<LifesController>();
    }

    void FixedUpdate()
    {
        var hor = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, hor, 0) * speed;
        transform.position = new Vector3(-5.5f, Mathf.Clamp(transform.position.y, -6.4f, 6.4f), 0);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.transform.localScale *= 0;
            lifesController.TakeLife();
        }
    }
}
