using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{

    Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1, 1, 1);
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // setPosition();
    }

    // Update is called once per frame
    void Update()
    {
        setPosition();

        if (Input.GetMouseButtonDown(0))
        {
            teleport();
            
        }


    }


    public void setPosition()
    {
        transform.position = PhysicsPointer.Instance.DefaultEnd(PhysicsPointer.Instance.defaultLength) + offset;
    }


    public void teleport()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = Vector3.MoveTowards(player.position, transform.position, 5f);
        player.GetComponent<CharacterController>().enabled = true;
        gameObject.SetActive(false);

    }

}
