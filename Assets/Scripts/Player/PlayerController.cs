using Player;
using Ship;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    // Singleton
    private static PlayerController instance = null;
    public static PlayerController Instance { get => instance; }
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    [SerializeField] private InputReader inputReader;
    public  Pawn pawn;
    private Camera _currentCamera;
    private bool _isRightClickPressed = false;
    public FModEvent shipBell;
    

    [HideInInspector] public DirectionCursor directionCursor;
    private Vector2 _target;

    private void OnValidate()
    {
        if (pawn == null)
            pawn = GetComponent<Pawn>();
    }

    private void Start()
    {
        _currentCamera = Camera.main;
        _target = Vector2.zero;
    }

    private void OnEnable() {
        inputReader.onRightClick.AddListener(SetTarget);
        inputReader.onLeftClick.AddListener(FireEquipment);
    }

    private void OnDisable()
    {
        inputReader.onRightClick.RemoveListener(SetTarget);
        inputReader.onLeftClick.RemoveListener(FireEquipment);
    }

    private void FireEquipment(InputAction.CallbackContext context)
    {
        // TODO Check if the equipment we're trying to use is our (lol)
        if (!context.performed) return;
        Vector2 mousePos = ScreenToWorld(inputReader.GetMousePosition());
        Collider2D overlap = Physics2D.OverlapBox(mousePos, Vector2.one * 0.5f, 0, 1 << 6);
        if (overlap && overlap.transform.parent.TryGetComponent(out EquipmentSlot equipment))
        {
            equipment.DoAction();
        }
    }

    private Vector2 ScreenToWorld(Vector3 mousePos)
    {
        Ray ray = _currentCamera.ScreenPointToRay(mousePos);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    private void SetTarget(InputAction.CallbackContext context)
    {
        if (context.canceled)
            _isRightClickPressed = false;
        if (!context.performed) return;
        _isRightClickPressed = true;
        
        if(!ScreenToWorld(inputReader.GetMousePosition()).IsNearlyEqual(transform.position, pawn.slowDistance))
            shipBell.PlayOneShotAttached(gameObject);
    }

    private void Update()
    {
        if (_isRightClickPressed)
        {
            Vector2 mousePos = inputReader.GetMousePosition();
            if (directionCursor)
            {
                directionCursor.UpdateCursorPos(mousePos);
            }

            _target = ScreenToWorld(mousePos); // Get the world pos of where we clicked
            if (_target.SqrDistance(pawn.Position) < pawn.slowDistance * pawn.slowDistance
            ) // If we are in the deadzone, don't move, just rotate
            {
                pawn.Stop();
                pawn.RotateToward(_target);
                if (directionCursor) directionCursor.UpdateCursorForce(0);
                _target = Vector2.zero; // Transform to local position
            }
            else
            {
                _target -= pawn.Position; // Transform to local position;
            }

            if (directionCursor) directionCursor.UpdateCursorAngle(pawn.AngleTarget);
        }

        if (!_target.IsNearlyEqual(Vector2.zero)) // Don't change the target if nearly equal to 0
        {
            pawn.SetTarget(pawn.Position + _target); // The target in the pawn is in worldpos
            if (directionCursor)
            {
                Vector2 pawnPosition = pawn.Position;
                Vector2 target = new Vector2(_target.x + pawnPosition.x, _target.y + pawnPosition.y);
                float distance = target.SqrDistance(pawn.transform.position);
                directionCursor.UpdateCursorForce(distance > pawn.fastDistance * pawn.fastDistance ? 2 : 1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Pontoon"))
        {
            Transform targetPos = other.transform.Find("TargetTransform").transform;
            Vector2 targetUp = targetPos.up;
            Vector2 target = pawn.Position + targetUp;
            pawn.SetTarget(target);
            _target = Vector2.zero;
            GameManager.Instance.EnterIslandMode();    
        }
    }
}