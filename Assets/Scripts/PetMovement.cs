using UnityEngine;

public class PetMovement : MonoBehaviour {
    public Rigidbody2D RB;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform groundCastOrigin;
    [SerializeField]
    private float groundCastDistance, groundCastRadius;
    [SerializeField]
    private LayerMask groundLayer;
    public enum Direction { Right, Left };
    private Direction dir;

    [System.NonSerialized]
    public bool Stun = false;

    private enum Movement { Idle, Walk };
    private Movement moveType;
    private readonly Timer moveTimer = new Timer(0f);

    private void Awake() {
        moveType = Movement.Idle;
        SetMoveTimer();
    }

    private void SetMoveTimer() {
        moveTimer.Cooldown = Random.Range(2f, 5f);
        moveTimer.BeginCount();
    }

    public bool Walking { get; private set; }
    private void FixedUpdate() {
        moveTimer.DecreaseTime(Time.fixedDeltaTime);

        if (moveTimer.IsTime()) {
            SetMoveTimer();
            moveType = moveType == Movement.Idle ? Movement.Walk : Movement.Idle;
            dir = Random.Range(0, 2) == 0 ? Direction.Right : Direction.Left;
        }

        Walking = false;
        switch (moveType) {
            case Movement.Walk:
                if (!Stun && Physics2D.CircleCast(groundCastOrigin.position, groundCastRadius, Vector2.down, groundCastDistance, groundLayer)) {
                    RB.MovePosition(RB.position + new Vector2(dir == Direction.Right ? speed : -speed, 0f));
                    Walking = true;
                }
                break;
        }
    }
}
