using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Lives))]
public class Animations : MonoBehaviour
{
    [SerializeField] private RectTransform _heart;
    [SerializeField] private RectTransform _greenButton;
    [SerializeField] private RectTransform _blueButton;
    [SerializeField] private RectTransform _image;

    private Lives _lives;

    private void Awake()
    {
        _lives = GetComponent<Lives>();
    }

    private void OnEnable()
    {
        _lives.LivesIsFull += FullState;
        _lives.LiveLargerOfMinAndLessOfMax += MiddleState;
        _lives.ZeroLives += EmptyState;
    }

    private void OnDisable()
    {
        _lives.LivesIsFull -= FullState;
        _lives.LiveLargerOfMinAndLessOfMax -= MiddleState;
        _lives.ZeroLives -= EmptyState;
    }

    private void FullState()
    {
        _heart.DOSizeDelta(new Vector2(120, 120), 0.2f, true);
        _heart.DOAnchorPos(new Vector3(0, -50, 0), 0.2f, true);

        _greenButton.DOSizeDelta(new Vector2(100, 50), 0.2f, true);
        _greenButton.DOAnchorPos(new Vector3(0, -50, 0), 0.2f, true);

        _blueButton.DOAnchorPos(new Vector3(0, -900, 0), 0.2f, true);
    }

    private void MiddleState()
    {
        _heart.DOSizeDelta(new Vector2(0, 0), 0.2f, true);
        _heart.DOAnchorPos(new Vector3(0, 0, 0), 0.2f, true);

        _blueButton.DOSizeDelta(new Vector2(0, 0), 0.2f, true);
        _blueButton.DOAnchorPos(new Vector3(0, 0, 0), 0.2f, true);

        _greenButton.DOSizeDelta(new Vector2(0, 0), 0.2f, true);
        _greenButton.DOAnchorPos(new Vector3(0, 0, 0), 0.2f, true);
    }
    private void EmptyState()
    {
        _heart.DOSizeDelta(new Vector2(0, 0), 0.2f, true);
        _heart.DOAnchorPos(new Vector3(0, 0, 0), 0.2f, true);

        _blueButton.DOSizeDelta(new Vector2(100, 50), 0.2f, true);
        _blueButton.DOAnchorPos(new Vector3(0, 150, 0), 0.2f, true);

        _greenButton.DOAnchorPos(new Vector3(0, -1000, 0), 0.2f, true);
    }
}
