using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehavior
{
    public float FollowSpeed = 2f;
    public float yoofset = 1f;
    public Transform target;


    void update()
    {
	Vector3 newPos = new Vector3(target.position.x,target,position.y + yOffset,-10f);
	transform.position = Vector3.Slerp(transfer.position,newPos,FollowSpeed*Time.deltaTime);
    }
}
