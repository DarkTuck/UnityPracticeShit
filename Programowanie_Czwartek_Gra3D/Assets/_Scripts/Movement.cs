using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Inputs input;
    [SerializeField] float speed=1;
    
    private InputAction turning;
    #region inputInit
    private void Awake()
    {
        input = new Inputs();
    }
    private void OnEnable()
    {
        turning = input.Player.Move;
        input.Player.Enable();
    }
    private void OnDisable() => input.Player.Disable();
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(turning.ReadValue<Vector2>().x + 0, 0, speed) * Time.deltaTime);
    }
}
