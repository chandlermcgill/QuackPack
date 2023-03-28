using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorScript : MonoBehaviour
{
    public GameObject player;
    public Sprite OpenDoorImage;
    public Sprite ClosedDoorImage;
    public float TimeBeforeNextScene;
    public bool PlayerIsAtDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtDoor == true)
        {
            StartCoroutine(_OpenDoor());
        }
    }
    public IEnumerator _OpenDoor()
    {
        transform.GetComponent<SpriteRenderer>().sprite = OpenDoorImage;
        yield return new WaitForSeconds(TimeBeforeNextScene);
        player.SetActive(false);
        yield return new WaitForSeconds(TimeBeforeNextScene);
        transform.GetComponent<SpriteRenderer>().sprite = ClosedDoorImage;
        yield return new WaitForSeconds(TimeBeforeNextScene);
        SceneManager.LoadScene("testFile");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerIsAtDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerIsAtDoor = false;
    }
}
