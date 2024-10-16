using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMotion : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(StringConst.playerParaname);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(StringConst.playerParaname))
        {
            if (player.GetComponent<CharacterController>().velocity.magnitude > 0.1f)
            {
                anim.SetBool("Swaying", true);
            }
            else
            {
                anim.SetBool("Swaying", false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(StringConst.playerParaname))
        {
                anim.SetBool("Swaying", false);
        }
    }
}
