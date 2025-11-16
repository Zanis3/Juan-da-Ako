using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject victoryScreen;
    public static GameManager Instance
    { 
        get; private set; 
    }
    // Tracks active draggables
    private HashSet<DragDrop> activeDraggables = new HashSet<DragDrop>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    public void RegisterDraggable(DragDrop d)
    {
        if (d == null)
        {
            return;
        }
        activeDraggables.Add(d);
    }
    // Called by the draggable before it destroys itself
    public void NotifyDraggableDestroyed(DragDrop d)
    {
        if (d == null)
        {
            return;
        }
        activeDraggables.Remove(d);
        CheckLevelComplete();
    }
    // safety in case OnDestroy called without Notify
    public void UnregisterIfNeeded(DragDrop d)
    {
        if (d == null)
        {
            return;
        }
        if (activeDraggables.Contains(d))
        {
            activeDraggables.Remove(d);
            CheckLevelComplete();
        }
    }
    private void CheckLevelComplete()
    {
        if (activeDraggables.Count == 0)
        {
            victoryScreen.SetActive(true);
        }
    }

    // optional helper: reset manager (e.g., on level start)
    public void ResetManager()
    {
        activeDraggables.Clear();
    }
}
