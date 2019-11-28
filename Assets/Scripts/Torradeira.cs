using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torradeira : MonoBehaviour
{
    private Animator Torrad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Torrad = GetComponent<Animator>();
        Torrad.SetBool("Presenca",true);
        
    }
}
