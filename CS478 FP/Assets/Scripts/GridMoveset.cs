using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMoveset : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float moveSpeed = 4f;
    public LayerMask obstacleLayers;
    public Transform movePoint;
    //private float moveSpeed;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
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

        //if (Input.GetKey(KeyCode.W) && !isMoving)
        //{
        //    StartCoroutine(MovePlayer(Vector3.up));
        //    anim.SetBool("isMovingUp", true);
        //    anim.SetBool("isMovingLeft", false);
        //    anim.SetBool("isMovingRight", false);
        //    anim.SetBool("isMovingDown", false);
        //}

        //if (Input.GetKey(KeyCode.A) && !isMoving)
        //{
        //    StartCoroutine(MovePlayer(Vector3.left));
        //    anim.SetBool("isMovingLeft", true);
        //    anim.SetBool("isMovingUp", false);
        //    anim.SetBool("isMovingRight", false);
        //    anim.SetBool("isMovingDown", false);
        //}

        //if (Input.GetKey(KeyCode.S) && !isMoving)
        //{
        //    StartCoroutine(MovePlayer(Vector3.down));
        //    anim.SetBool("isMovingDown", true);
        //    anim.SetBool("isMovingRight", false);
        //    anim.SetBool("isMovingLeft", false);
        //    anim.SetBool("isMovingUp", false);
        //}

        //if (Input.GetKey(KeyCode.D) && !isMoving)
        //{
        //    StartCoroutine(MovePlayer(Vector3.right));
        //    anim.SetBool("isMovingRight", true);
        //    anim.SetBool("isMovingLeft", false);
        //    anim.SetBool("isMovingUp", false);
        //    anim.SetBool("isMovingDown", false);
        //}

    }

    //private IEnumerator MovePlayer(Vector3 direction)
    //{
    //    isMoving = true;
    //    float elapsedTime = 0;
    //    origPos = transform.position;
    //    targetPos = origPos + direction;

    //    while(elapsedTime < timeToMove)
    //    {
    //        transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    transform.position = targetPos;

    //    isMoving = false;
    //}

}
