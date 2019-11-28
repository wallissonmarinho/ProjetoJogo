using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacaController : MonoBehaviour
{
    public float velocidade;
    public GameObject Pla;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Pla.GetComponent<Player>().isGroundedEnemy;
        Ativado();
    }

    void Ativado()
    {
        if(isGround)
        {
            transform.Translate(0, velocidade * Time.deltaTime, 0);
        }
        
    }

}
