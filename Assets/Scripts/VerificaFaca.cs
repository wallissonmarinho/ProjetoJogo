using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaFaca : MonoBehaviour
{
    public bool isGroundedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Debug.Log("Colidiu com :"+collider.gameObject.name);

        if(collider.gameObject.CompareTag("Player"))
        {
            isGroundedEnemy = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            isGroundedEnemy = false;
        }
    }
}
