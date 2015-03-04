using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{

    private int speed;
    private CharacterController characterC;
    protected Animator animate;
	void Start () 
    {
        speed = 3;
        animate = GetComponent<Animator>();
        characterC = GetComponent<CharacterController>();
	}
	
	void Update () 
    {
        Vector3 moveVec = new Vector3(0, 0, 0);
        Vector3 rotVec = new Vector3(0, 0, 0);
        AnimatorStateInfo animateInfo = animate.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKey(KeyCode.W))
        {
            moveVec.z += Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVec.z -= Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveVec.x -= Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveVec.x += Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotVec.y -= Time.deltaTime * speed*100;
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotVec.y += Time.deltaTime * speed*100;
        }
        if (moveVec.x != 0 || moveVec.z != 0)
        {
            //if (animateInfo.nameHash == Animator.StringToHash("Base Layer.stand"))
            {
                animate.SetBool("stand", false);
                animate.SetBool("walk", true);
                //animate.Play("walk");
            }
        }
        else
        {
            //if (animateInfo.nameHash == Animator.StringToHash("Base Layer.walk") && !animate.IsInTransition(0))
            {
                animate.SetBool("walk", false);
                animate.SetBool("stand", true);
                Debug.Log(animateInfo.nameHash + " " + Animator.StringToHash("Base Layer.walk"));
                //animate.Play("stand");
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            animate.SetInteger("attack_1", 1);
            //animate.Play("attack_1");
        }

        characterC.Move(transform.TransformDirection(moveVec));
        //transform.Translate(moveVec);
        transform.Rotate(rotVec);

        //Camera.main.transform.Rotate(rotVec);
	}
}
