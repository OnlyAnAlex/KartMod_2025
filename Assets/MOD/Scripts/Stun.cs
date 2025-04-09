using KartGame.KartSystems;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
public class Stun : MonoBehaviour
{



    [SerializeField] float timeTillDestroy = 30;

    [SerializeField] float timeStunned = 4;

    ArcadeKart arcadeKart;
    PlayerController playerController;

    private void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!other.isTrigger) return;

        arcadeKart = other.GetComponent<ArcadeKart>();
        playerController = other.gameObject.GetComponent<PlayerController>();

        StartCoroutine("Stunned");
    }


    IEnumerator Stunned()
    {
        float timer = 0;
        while(timer < timeStunned)
{
            arcadeKart.Rigidbody.linearVelocity *= 0;
            timer += Time.deltaTime;
            yield return new WaitForNextFrameUnit();
        }
    }

}