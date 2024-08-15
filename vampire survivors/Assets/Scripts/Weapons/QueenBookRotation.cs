using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenBookRotation : MonoBehaviour
{
    public Transform playerTransform; // Oyuncunun transformunu buraya sürükleyin
    public float rotationSpeed = 50f; // Dönerkenki hız
    public float orbitDistance = 2f; // Oyuncuya olan mesafe

    private float angle = 0f;
    public float angleOffset = 0f; // Her obje için farklı açı kaydırması

    private void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        playerTransform = playerObject.transform;
    }

    void Update()
    {
        // Açıyı artırarak dairesel hareket sağlıyoruz
        angle += rotationSpeed * Time.deltaTime;

        // Açıyı kaydırma ile birlikte hesapla
        float adjustedAngle = angle + angleOffset;

        // X ve Y pozisyonunu hesaplayarak dairesel yörünge oluşturuyoruz
        float x = playerTransform.position.x + Mathf.Cos(adjustedAngle) * orbitDistance;
        float y = playerTransform.position.y + Mathf.Sin(adjustedAngle) * orbitDistance;

        // Nesnenin pozisyonunu güncelle
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void OnDrawGizmos()
    {
        // Orbit merkezini ve yarıçapını çiz
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerTransform.position, orbitDistance);

        // Orbit yolunu çiz
        float gizmoAngle = angle + angleOffset;
        Vector3 startPos = playerTransform.position + new Vector3(Mathf.Cos(gizmoAngle) * orbitDistance, Mathf.Sin(gizmoAngle) * orbitDistance, 0);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(startPos, playerTransform.position);

        for (float i = gizmoAngle; i < gizmoAngle + Mathf.PI * 2; i += Mathf.PI / 10)
        {
            Vector3 endPos = playerTransform.position + new Vector3(Mathf.Cos(i) * orbitDistance, Mathf.Sin(i) * orbitDistance, 0);
            Gizmos.DrawLine(startPos, endPos);
            startPos = endPos;
        }
    }
}
