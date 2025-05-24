using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Target : MonoBehaviour
{
    List<RadialTrigger> radialTriggers;
    private void PopulateTriggers()
    {
        if (radialTriggers == null)
        {
            radialTriggers = new List<RadialTrigger>(FindObjectsByType<RadialTrigger>(FindObjectsSortMode.None));
            return;
        }

        // Get all current RadialTriggers in the scene
        var currentTriggers = FindObjectsByType<RadialTrigger>(FindObjectsSortMode.None);

        // Add only new triggers not already in the list
        foreach (var trigger in currentTriggers)
        {
            if (!radialTriggers.Contains(trigger))
            {
                radialTriggers.Add(trigger);
            }
        }

        //// Optionally, remove destroyed or missing triggers
        //radialTriggers.RemoveAll(t => t == null);
    }
    private void CheckIfInList()
    {
        PopulateTriggers();
        // Check if this target is already in the list of targets for each trigger
        foreach (var trigger in radialTriggers)
        {
            if (!trigger.targets.Contains(transform))
            {
                trigger.AddTarget(transform);
            }
        }
    }
    private void OnEnable()
    {
        CheckIfInList();
    }
}
