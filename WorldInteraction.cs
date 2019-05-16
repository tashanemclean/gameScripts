using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldInteraction : MonoBehaviour 
{   
    // added code
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    Animator anim;
    public float rotationRate = 180;
    public float moveSpeed = 1;

    UnityEngine.AI.NavMeshAgent playerAgent;

     void Start()
    {
        playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // added code
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            GetInteraction();

        // added code
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);


        ApplyInput(moveAxis, turnAxis);
        if (Input.GetKeyDown(KeyCode.W)) anim.SetInteger("condition", 1);
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
            }

        }

        if (Input.GetKeyDown(KeyCode.A)) anim.SetInteger("condition", 1);
        else
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetInteger("condition", 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) anim.SetInteger("condition", 1);
        else
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetInteger("condition", 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.X)) anim.SetTrigger("Base_Attack");
        if (Input.GetKeyDown(KeyCode.Z)) anim.SetTrigger("Special_Attack");
    }


    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                //playerAgent.stoppingDistance = 0;
                //playerAgent.destination = interactionInfo.point;
            }
        }
    }

    // added code
    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        turn(turnInput);
    }

    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
    }

    private void turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);

    }

}
