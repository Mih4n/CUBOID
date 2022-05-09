using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SckinsDatabase", menuName = "Preferences/NewSkinsDatabase", order = 0)]
public class SckinsDatabase : ScriptableObject
{
    [Header("Sckins")]
    [SerializeField] private Sprite[] _headSprites;
    public Sprite HeadSpites
    {
        get { return _headSprites[Random.Range(0, _headSprites.Length)];}
        set
        {

        }
    }
    [SerializeField] private Sprite[] _bodySprites;
    public Sprite BodySprites
    {
        get { return _bodySprites[Random.Range(0, _bodySprites.Length)];}
        set
        {

        }
    }
    [SerializeField] private Sprite[] _leftHandsSprites;
    public Sprite LeftHandsSprites
    {
        get { return _leftHandsSprites[Random.Range(0, _leftHandsSprites.Length)];}
        set
        {

        }
    }
    [SerializeField] private Sprite[] _RightHandsSprites;
    public Sprite RightHandsSprites
    {
        get { return _RightHandsSprites[Random.Range(0, _RightHandsSprites.Length)];}
        set
        {

        }
    }
    [SerializeField] private Sprite[] _leftFootSprites;
    public Sprite LeftFootSprites
    {
        get { return _leftFootSprites[Random.Range(0, _leftFootSprites.Length)];}
        set
        {

        }
    }
    [SerializeField] private Sprite[] _rightFootSprites;
    public Sprite RightFootSprites
    {
        get { return _rightFootSprites[Random.Range(0, _rightFootSprites.Length)];}
        set
        {

        }
    }
}
