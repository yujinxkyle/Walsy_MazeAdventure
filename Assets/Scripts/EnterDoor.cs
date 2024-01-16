using System.Collections;
using System.Collection.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : Monobehaviour
{
private bool enterAllowed;
private string sceneToLoad;

private void OnTriggerEnter2D(Collider2D collision)
{
  if (collision.GetComponent<BlueDoor>())
  {
    sceneToLoad = "Level2";
    enterAllowed = true;
  }
  else if (collision.GetComponent<BrownDoor>())
  {
    sceneToLoad = "Level1";
    enterAllowed = true;
  }
}

private void OnTriggerExit2D(Collider2D collision)
{
  if (collision.GetComponent<BlueDoor>() || collision.GetComponent<BrownDoor>())
  {
    enterAllowed = false;
  }
}

  private void Update()
  {
    if (enterAllowed && Input.GetKey(KeyCode.Return))
    {
    SceneManager.LoadScene(sceneToLoad);
    }
  }
}



