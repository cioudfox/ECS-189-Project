using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour   
{
    [SerializeField] public float itemDropRange;
    [SerializeField] public float itemDropSpeed;
    [SerializeField] public float itemLifetime;


    Rigidbody2D item;
    Vector3 targetDropPosition;
    void Start()
    {
        this.item = this.gameObject.GetComponent<Rigidbody2D>();
        var Xrandom = Random.Range(-itemDropRange, itemDropRange);
        var Yrandom = Random.Range(-itemDropRange, itemDropRange);
        this.targetDropPosition = this.item.transform.position + new Vector3(Xrandom, Yrandom, 0.0f);
    }

    // private void OnTriggerEnter2D(Collider other)
    // {

    // }

    // // Update is called once per frame.
    void Update()
    {
        if (this.targetDropPosition != this.item.transform.position)
        {
            this.item.transform.position = Vector3.MoveTowards(this.item.transform.position, this.targetDropPosition, itemDropSpeed * Time.deltaTime);
        }

        this.itemLifetime -= Time.deltaTime;
        if (this.itemLifetime < 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
