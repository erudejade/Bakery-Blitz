using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Command <Player>{
    public float moveSpeed = 5;
    public float t { get; set; }
    private void Start()
    {
       
    }
    private void Update()
    {
       ExecuteCommand();
    }
    public void Move(Vector3 target)
    {
        t += Time.deltaTime * moveSpeed;
        transform.position = Vector3.Lerp(clampedPosition, target, t);
    }
    

}
