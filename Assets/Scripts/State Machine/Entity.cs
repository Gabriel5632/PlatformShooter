using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Entity : MonoBehaviour
{
    #region Variables
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public SpriteRenderer sp { get; private set; }
    public GameObject character { get; private set; }
    public AnimationToStatemachine atsm { get; private set; }
    public Vector2 originalPosition { get; private set; }
    public Material originalMaterial { get; private set; }
    public QuietoState quietoState {get; private set;}

    //Where the actual health of the enemy will be stored
    public int health { get; private set; }

    //The last damage the entity recibed
    public int damageRecibed { get; private set; }
    
    //The speed the last attack have
    public int speedFromAttack { get; private set; }
    #endregion

    #region Unity Functions
    public virtual void Start()
    {
        character = transform.Find("Character").gameObject;
        rb = character.GetComponent<Rigidbody2D>();
        anim = character.GetComponent<Animator>();
        atsm = character.GetComponent<AnimationToStatemachine>();
        sp = character.GetComponent<SpriteRenderer>();
        originalPosition = character.transform.position;
        originalMaterial = sp.material;
        health = entityData.maxHealth;

        stateMachine = new FiniteStateMachine();
        quietoState = new QuietoState(this, this.atsm, );

    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion

    #region Input Functions

    public void InMovement(InputAction.CallbackContext context)
    {

    }

    public void InShoot(InputAction.CallbackContext context)
    {

    }

    #endregion

    #region Set Functions
    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetMaterial(Material material)
    {
        sp.material = material;
    }
    public void ResetMaterial()
    {
        sp.material = originalMaterial;
    }
    #endregion

    #region Other Functions
    public virtual void Flip()
    {
        character.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void Damage(int[] attackinf)
    {
        this.damageRecibed = attackinf[0];
    }
    #endregion
}