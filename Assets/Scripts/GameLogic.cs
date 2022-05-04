using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
  public GameObject victory;
  public GameObject defeat;

  public bool canMove = true;

  public void WinGame(){
    canMove = false;
    victory.SetActive(true);

  }
  public void LoseGame(){
    canMove = false;
    defeat.SetActive(true);

  }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
