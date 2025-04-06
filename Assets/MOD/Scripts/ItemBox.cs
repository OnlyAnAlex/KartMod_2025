using UnityEngine;

public class ItemBox : MonoBehaviour
{
    
        

    public float velocidadeRotacao = 50f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        transform.Rotate(0, 0, velocidadeRotacao * Time.deltaTime);
    }
  
}
