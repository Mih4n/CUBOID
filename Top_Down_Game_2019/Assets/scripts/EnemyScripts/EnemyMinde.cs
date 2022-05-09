using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMinde : MonoBehaviour
{
    public EnemyPreferences EnemySettings;

    [SerializeField] private SpriteRenderer HeadSprite;
    [SerializeField] private SpriteRenderer BodySprite;
    [SerializeField] private SpriteRenderer LeftHandsSprite;
    [SerializeField] private SpriteRenderer RightHandsSprite;
    [SerializeField] private SpriteRenderer LeftFootSprite;
    [SerializeField] private SpriteRenderer RightFootSprite;

    [HideInInspector] public addRoom Room;
    [HideInInspector] public bool FacingRight = true;
    [HideInInspector] public PlayerMovement Player;
    [HideInInspector] public Animator Anim;
    [HideInInspector] public NavMeshAgent Agent;

    public void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void OnStart()
    {
        SetAgent();
        SetSprites();
        Anim = GetComponent<Animator>();
        Player = FindObjectOfType<PlayerMovement>();
    }
    private void SetSprites()
    {
        HeadSprite.sprite = EnemySettings.Skins.HeadSpites;
        BodySprite.sprite = EnemySettings.Skins.BodySprites;
        LeftHandsSprite.sprite = EnemySettings.Skins.LeftHandsSprites;
        RightHandsSprite.sprite = EnemySettings.Skins.RightHandsSprites;
        LeftFootSprite.sprite = EnemySettings.Skins.LeftFootSprites;
        RightFootSprite.sprite = EnemySettings.Skins.RightFootSprites;
    }
    private void SetAgent()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }
}
