using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Command <Player>{
    public Transform rootator;
    public float moveSpeed = 5, smoothDampen = 2;
    private float _t;
    public float t {
        get
        {
                return _t;
        }
        set
        {
            _t = value;
            playerAnimator.SetInteger("t", t > 0 ? 1 : 0);
        }
    }
    private Animator _playerAnimator;
    public Animator playerAnimator
    {
        get
        {
            return _playerAnimator ?? (_playerAnimator = GetComponentInChildren<Animator>());
        }
    }
  
    private void Update()
    {
       ExecuteCommand();
    }
    public void Move(Vector3 target,Vector3 lastPos)
    {
        float distance = Mathf.Abs(lastPos.x - target.x);
        t += (Time.deltaTime * moveSpeed)/(smoothDampen*distance);
        transform.position = Vector3.Lerp(clampedPosition, target, t);
        rootator.rotation = Quaternion.Euler(0, target.x > clampedPosition.x ? 180 : 0, 0);
      

    }
    

}
