using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float moveSpeed = 4f;
    public LayerMask obstacleLayers;
    public Transform movePoint;
    public Animator anim;

    public event Action OnEncountered;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f), .2f, obstacleLayers))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical")), .2f, obstacleLayers))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"));
                }
            }
        }      
    }

    private void CheckForEncounters()
    {
        //if ()
        //{
        //    anim.SetBool("isMoving", false);
        //    OnEncountered();
        //}
    }
}
