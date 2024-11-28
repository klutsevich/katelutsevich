
using UnityEngine;

public class MovementsControllers : MonoBehaviour
{
[SerializeField] private float _speed = 3f;
[SerializeField] private float _jumpForce = 5f;
 private SpriteRenderer _sprite;
 private Vector3 _playerMovementState;
 private Rigidbody2D _rb2D;
 
 private void Start()
 {
    _sprite = GetComponentInChildren<SpriteRenderer > ();
    _rb2D = GetComponent<Rigidbody2D> ();
 }

 void Update()
{
   Move();
   if (Input.GetKeyDown(KeyCode.Space))
   {
      Jump();
   }
}

private void Move()

{
   Vector3 playerMovementState = Vector3.right * Input.GetAxisRaw("Horizontal");
   transform.position =
      Vector3.MoveTowards(transform.position, transform.position + playerMovementState, _speed * Time.deltaTime);

   if (playerMovementState.x < 0)
   {
      _sprite.flipX = true;
   }
   else if (playerMovementState.x > 0)
   {
      _sprite.flipX = false;
   }

}

private void Jump()
{
   _rb2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
}

}

