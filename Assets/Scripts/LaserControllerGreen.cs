using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControllerGreen : MonoBehaviour
{
    // game controller game object
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        // get game controller
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward* 10f * Time.deltaTime);
              
    }
    
    private void OnTriggerStay(Collider other)
    {
        // log para debug no console do nome do objeto que colidiu
        // Debug.Log(other.name);

        if(other.CompareTag("EnemyGreen"))
        {
            GameObject explosion = Instantiate(Resources.Load("Flare", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            // Destroy(other.gameObject);
            //desativa o inimigo
            other.gameObject.SetActive(false);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);

            // add score with send message
            gameController.SendMessage("IncrementScore");
        }
    }
}
