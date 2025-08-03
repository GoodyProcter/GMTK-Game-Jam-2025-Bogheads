using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aliensGrab : MonoBehaviour
{
    public GameObject dog;
    public BasicAI npc;
    public string flagToSet = "dogGrabbed";
    bool dogGrabbed = false;
    readonly Vector3 beamOffset = new Vector3(0f, -2.0f, 0f);


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"aliensGrab hit {collider.gameObject.name}");

        if (dogGrabbed || collider.gameObject != dog) return;

        dogGrabbed = true;

        // snap dog under ship & spin it
        var dogAgent = dog.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (dogAgent) dogAgent.enabled = false;
        var dogRb = dog.GetComponent<Rigidbody2D>();
        if (dogRb) dogRb.simulated = false;

        var follow = dog.AddComponent<DogBeamFollow>();
        follow.ufo = transform;
        follow.offset = beamOffset;

        GameFlags.Instance.SetFlag(flagToSet, true);
        Debug.Log($"aliensGrab {flagToSet}=TRUE");

        npc.TriggerNextStep();
        enabled = false;
    }

    class DogBeamFollow : MonoBehaviour
    {
        public Transform ufo;
        public Vector3 offset;

        void Update()
        {
            if (!ufo) return;
            transform.position = ufo.position + offset;
            transform.Rotate(0, 0, 180 * Time.deltaTime);
        }
    }
}
