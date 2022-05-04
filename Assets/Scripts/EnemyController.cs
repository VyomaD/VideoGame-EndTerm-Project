using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public float rotationSpeed = 90;
  public Animator animator;
  public UnityEngine.AI.NavMeshAgent agent;
  public Transform visionRayPoint;
  public float PlayerHeightOffset = 1f;
  public bool canrotate = true;

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
        agent.isStopped = true;
        return;
      }
      if(agent.remainingDistance < 0.01f){
        animator.SetFloat("MoveSpeed", 0);
        canrotate = true;

      }
      if(canrotate == true)
      {
        float rotateAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotateAmount);
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player")
      {
        Vector3 playerPosition = other.transform.position;
        playerPosition.y +=PlayerHeightOffset;
        Vector3 rayDir = playerPosition - visionRayPoint.position;
        Ray ray = new Ray(visionRayPoint.position, rayDir);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
          if(hit.transform.gameObject.tag == "Player")
          {
            canrotate = false;
            agent.SetDestination(other.transform.position);
            animator.SetFloat("MoveSpeed", 1);

          }
        }
      }
    }
}
