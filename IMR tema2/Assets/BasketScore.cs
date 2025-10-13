using UnityEngine;
using TMPro;
using System.Collections;

public class BasketScore : MonoBehaviour
{
    public TMP_Text scoreText;   // drag a TextMeshPro object here (World Space or Screen Space)
    int totalScore = 0;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Throwable")) return;

        totalScore += 1;

        if (scoreText) scoreText.text = $"Score: {totalScore}";
        Debug.Log($"[SCORE] +1 => Total = {totalScore}");

        StartCoroutine(Flash());
    }
    System.Collections.IEnumerator Flash() { var rend = GetComponentInParent<Renderer>(); if (rend) { Color c = rend.material.color; rend.material.color = Color.yellow; yield return new WaitForSeconds(0.15f); rend.material.color = c; } }
}
