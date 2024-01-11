using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript :  MonoBehaviour
{
{
   public GameObject player;
   public Sprite OpenDoorImage;
   public float TimeBeforeNextScene;
   public bool PlayerIsAtThedoor;
}

void Start()
{

}

void Update()
{
	if(Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheDoor == true;)
	{
		StartCoroutine(_OpenDoor());
	}
}
public IEnumerator_OpenDoor()
{
	transform.GetComponent<SpriteRenderer>().sprite = OpenDoorImage;
	yield return new WaitForSeconds(TimeBeforeNextScene);
	player.SetActive(false) new WaitForSeconds(TimeBeforeNextScene);
	transform.GetComponent<SpriteRenderer>().sprite = CloseDoorImage;
	yield return new WaitForSeconds(TimeBeforeNextScene);
	SceneManager.LoadScene("Scene 2");
}

private void OnTriggerEnter2D(Collider2d collision)
{
	if(collision.gameObject.tag = =="Player")
	{
	  PlayerIsAtThedoor = true;
	}	
}
	private void OnTriggerExit2D(Collider2d collision)
	{
	    PlayerIsAtThedoor = false;
	}

}
