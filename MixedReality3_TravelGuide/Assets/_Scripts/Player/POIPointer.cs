﻿using UnityEngine;

public class POIPointer : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer NormalSprite;

    [SerializeField]
    private SpriteRenderer BigSprite;

    [SerializeField]
    private float PointerDistanceToPlayer = 2.0f;

    [SerializeField]
    float DirectionMatchPercentage = 0.95f;

    public Vector2 UnityTarget { get; set; }

	public void OnPlayerPositionChanged(Vector2 PlayerPosition)
    {
        Vector3 dir = new Vector3(UnityTarget.x - PlayerPosition.x, UnityTarget.y - PlayerPosition.y, 0.0f);
        if (dir.magnitude > 0.5f)
        {
            this.gameObject.SetActive(true);
            dir = PointerDistanceToPlayer * dir.normalized;
            this.transform.localPosition = dir;
            this.transform.rotation = Quaternion.LookRotation(-Vector3.forward, dir);
        }
        else
        {
            this.gameObject.SetActive(false);
        }     
    }

    public void OnPlayerRotationChanged(Vector2 forward)
    {
        float dotForwardTarget = Vector2.Dot(this.transform.up, forward);
        if(dotForwardTarget > DirectionMatchPercentage)
        {
            BigSprite.gameObject.SetActive(true);
            NormalSprite.gameObject.SetActive(false);
        }
        else
        {
            BigSprite.gameObject.SetActive(false);
            NormalSprite.gameObject.SetActive(true);
        }
    }
        
}
