using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed  = 5f;
    [SerializeField] private float _gravity   = -9.81f;
    [SerializeField] private float _rotSpeed  = 10f;

    private CharacterController _cc;
    private InputHandler        _input;
    private float               _verticalVel;

    public float CurrentSpeed { get; private set; }
    public bool  IsGrounded   { get; private set; }

    void Start()
    {
        _cc    = GetComponent<CharacterController>();
        _input = GetComponent<InputHandler>();
    }

    void Update()
    {
        IsGrounded = _cc.isGrounded;

        if (IsGrounded && _verticalVel < 0f)
            _verticalVel = -2f;

        // Vector de movimiento en el plano horizontal
        Vector3 move = new Vector3(_input.Horizontal, 0f, _input.Vertical);

        if (move.magnitude > 1f)
            move.Normalize();

        CurrentSpeed = move.magnitude * _runSpeed;

        // Seleccionar velocidad según magnitud del input
        float speed = move.magnitude > 0.5f ? _runSpeed : _walkSpeed;

        // Rotar el personaje hacia la dirección de movimiento
        if (move.magnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, targetRot, Time.deltaTime * _rotSpeed);
        }

        // Aplicar gravedad
        _verticalVel += _gravity * Time.deltaTime;
        move.y        = _verticalVel;

        _cc.Move(move * speed * Time.deltaTime);
    }
}