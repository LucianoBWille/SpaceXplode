using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward* 2f * Time.deltaTime);
              
    }

    // functon to start coroutine
    public void StartChangeDirection()
    {
        StartCoroutine("changeDirection");
    }

    IEnumerator changeDirection()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            // transform.eulerAngles += new Vector3(0f, 180f, 0f);
            // independente da rotação atual, rotaciona 180 graus e volta para a posição inicial    
            transform.Rotate(0f, 180f, 0f, Space.Self);
        }
    }
}
