using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] public GameObject productDropPrefab;

    public EnemyScriptableObject enemyData;

    float currentDamage;
    float currentSpeed;
    float currentHp;
    // Controls the horizontal speed at which prefabs are instantiated.

    // Update is called once per frame
    void Awake()
    {
        currentDamage = enemyData.Damage;
        currentSpeed = enemyData.Speed;
        currentHp = enemyData.MaxHp;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        
        bool isCriticalHit = Random.Range(0,100) < 30;

        DamgePopup.Create(this.gameObject.transform.position, (int)damage, isCriticalHit);

        
        if(currentHp <= 0)
        {
            Kill();
        }
    }


    public void Kill()
    {
        Destroy(gameObject);

        var itemDrop = (GameObject) Instantiate(productDropPrefab, this.gameObject.transform.position, Quaternion.identity);

    }
}
