using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{

    Transform player;
    Vector3 offset;
    Transform triangle;
    float translateValue;
    // Start is called before the first frame update
    void Start()
    {
        translateValue = 0f;
        triangle = transform.GetChild(0);
        offset = new Vector3(1, 4, 1);
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // setPosition();
    }

    // Update is called once per frame
    void Update()
    {
        animateTeleport();
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

    public void animateTeleport()
    {
        
        translateValue+=1;
        
        if(translateValue > 10f)
        {
           translateValue=-10f;
        }

        triangle.Translate(new Vector3(0f, translateValue * Time.deltaTime, 0f));

    }


    public void teleport()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = Vector3.MoveTowards(player.position, transform.position, 5f);
        player.GetComponent<CharacterController>().enabled = true;
        gameObject.SetActive(false);

    }

}
