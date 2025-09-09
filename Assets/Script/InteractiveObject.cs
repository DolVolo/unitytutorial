using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.VFX;

public class InteractiveObject : MonoBehaviour
{
    public float radius = 3f;//กำหนดระยะการชนและการมองเห็น
    public Transform player;
    public Transform interactItem;
    bool hasInteracted = false;//เช็คว่าชนหรือยัง


    void Update()
    {
        float distance = Vector3.Distance(player.position, interactItem.position);
        if (distance <= radius && !hasInteracted)
        {
            hasInteracted = true;
            Interact();
        }
    }
    public virtual void Interact()
    {
        
    }
    //สร้างขอบเขตการชนไอเทม หรือ บริเว็นที่พบไอเท็ม
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactItem.position, radius);
    }
}
