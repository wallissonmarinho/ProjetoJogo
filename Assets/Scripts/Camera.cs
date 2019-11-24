using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{	
    [SerializeField]
	private Transform camera;
    public float x1;
    public float x2;
	
    void Start()
    {
        
    }

    void Update()
    {
        PosicaoCamera();
		
    }
    //Metodo responsavel pela movimentação da camera, seguindo o player.
    void PosicaoCamera()
    {
        if(transform.position.x > x1 && transform.position.x < x2)
        {
            camera.position = new Vector3(transform.position.x,
			camera.position.y,
			camera.position.z);
        }
    }
}