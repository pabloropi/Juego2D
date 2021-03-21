using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Atributos
    public float fuerzaSalto = 5.5f;
    public float playerSpeed = 8.8f;
    private Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Comprueba si ha pulsado el espacio
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Le aplicamos el valor de la fuerza en la componente vertial
            myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, fuerzaSalto);
        }

        myRigidBody2D.velocity = new Vector2(playerSpeed, myRigidBody2D.velocity.y); ;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("monedaoro"))
        {
            Debug.Log("Ganas 10 puntos!");
            Destroy(collision.gameObject);
            

        }
        else if (collision.gameObject.CompareTag("monedaplata"))
        {
            Debug.Log("Ganas 5 puntos!");
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("monedaroja"))
        {
            Debug.Log("Pierdes vida!!");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("zonamuerte"))
        {
            Debug.Log("Game Over");
            GameOver();
        }
            

    }

    private void GameOver()
    {
        // Carga una escena nueva o reinicia -> pantalla inicial del juego
        SceneManager.LoadScene("level1");
        
    }

}
