using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguinho : MonoBehaviour
{
    private bool colidde = false;
    private float move = -2;
    public float vMaxima;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Metodo para movimentar o inimigo
        GetComponent<Rigidbody2D>().velocity = new Vector2(move*vMaxima, GetComponent<Rigidbody2D>().velocity.y);
        if(colidde)
        {
            Flip();
        }
    }
    //Metodo com a função de flipar a imagem
    private void Flip()
    {
        move *= -1;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        colidde = false;
    }
    //Metodo para saber se tocou em outro personagem para poder andar para o outro lado
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Fogo"))
        {
           colidde = true;
           Debug.Log("Colidiu");
        }
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Fogo"))
        {
           colidde = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Fogo"))
        {
            colidde = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Fogo"))
        {
            colidde = false;
        }
    }
}
