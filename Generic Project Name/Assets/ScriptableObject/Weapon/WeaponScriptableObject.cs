using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    
    
    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }
    
    [SerializeField]
    float speed;
    public float Speed { get => speed; private set => speed = value; }
    
    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }
    
    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }

    [SerializeField]
    float lifetime;
    public float Lifetime { get => lifetime; private set => lifetime = value; }

    [SerializeField]
    bool chain;
    public bool Chain { get => chain; private set => chain = value; }

    [SerializeField]
    bool explosive;
    public bool Explosive { get => explosive; private set => explosive = value; }
    
    [SerializeField]
    float aoe;
    public float Aoe { get => aoe; private set => aoe = value; }

    [SerializeField]
    int projectileNumber;
    public int ProjectileNumber { get => projectileNumber; private set => projectileNumber = value; }
    
}