using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Command <Player>{
    public float moveSpeed = 5;
    private void Start()
    {
       
    }
    private void Update()
    {
       ExecuteCommand();
    }
    public void Move(Vector3 target)
    {
        transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
    }
    

}
