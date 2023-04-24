using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//Loads a new level when the tagTarget walks onto the triggering collider
public class RoomTrans : MonoBehaviour
{
    public string triggererTag = "Player";
    public string playerSpawnTransformName = "NOT SET";
    public float enterSpeed = 1f;
    public SceneAsset sceneToLoad;
    public GameObject transAnimation;

    private Canvas canvas;
    private Animator transitionAnimator;

    private void Start()
    {
        //Canvas
        canvas = FindObjectOfType<Canvas>();

        if (sceneToLoad == null)
        {
            throw new MissingReferenceException(name + " has no sceneToLoad set");
        }

        if (transAnimation == null)
        {
            throw new MissingReferenceException(name + " has no transition animation set");
        }
    }

    private void Update()
    {
        if (transitionAnimator != null)
        {
            //Check if the animation has finished
            //Change levels when animation is finished
            if (transitionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                //Send request for level to switch
                RoomEvents.roomExit.Invoke(sceneToLoad, playerSpawnTransformName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == triggererTag)
        {
            //GameObject playerDamageable = collider.gameObject;

            Rigidbody2D playerBody = collider.gameObject.GetComponent<Rigidbody2D>();
            playerBody.bodyType = RigidbodyType2D.Kinematic;

            //Player will walk towards the entrance direction
            Vector2 entranceDirection = (transform.position - playerBody.transform.position).normalized;

            playerBody.velocity = entranceDirection * enterSpeed;

            transitionAnimator = Instantiate(transAnimation, canvas.transform).GetComponent<Animator>();
            transitionAnimator.SetTrigger("Start");
        }
    }
}
