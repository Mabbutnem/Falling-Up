using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float force = 1500f;

   private Vector2 target;
   private Vector2 velocity = Vector2.zero;
   private bool toMove = false;
   private new Rigidbody2D rigidbody2D;

   void Start()
   {
      rigidbody2D = GetComponent<Rigidbody2D>();
   }

   void Update()
   {
      if (Input.GetKey(KeyCode.Mouse0))
      {
         toMove = true;
         target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      }
   }

   void FixedUpdate()
   {
      if(toMove)
      {
         toMove = false;
         Vector2 dir = (target - (Vector2)transform.position).normalized;
         rigidbody2D.AddForce(Time.fixedDeltaTime * force * dir);
      }
   }
}
