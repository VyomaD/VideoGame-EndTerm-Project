using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float rotateSpeed = 90f;
  public float moveSpeed = 5f;

  public CharacterController controller;
  public Animator animator;

  GameLogic gameLogic;
    // Start is called before the first frame update
    void Start()
    {
      gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
      if(gameLogic.canMove == false){
        animator.SetFloat("MoveSpeed", 0);
        return;
      }
      float rotateAmount = Input.GetAxis("Horizontal");
      rotateAmount *= rotateSpeed * Time.deltaTime;
      transform.Rotate(Vector3.up, rotateAmount);

      float moveAmount = Input.GetAxis("Vertical");
      animator.SetFloat("MoveSpeed", moveAmount);

      Vector3 moveVector = transform.forward *moveAmount;
      moveVector *= moveSpeed * Time.deltaTime;
      controller.Move(moveVector);
    }

    private void OnTriggerEnter(Collider other){
      if(other.tag == "Goal"){
        gameLogic.WinGame();
      }
    }
}
