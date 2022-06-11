using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInstall : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager m_TrackedImageManager;
    [SerializeField] private Image _target;
    [SerializeField] private Camera _ARCamera;

    // Start is called before the first frame update
    void Start()
    {
        AddImage(Bridge.Marker);
        m_TrackedImageManager.trackedImagesChanged += args =>
        {
            foreach (var a in args.added)
            {
                a.gameObject.GetComponentInChildren<Canvas>().worldCamera = _ARCamera;
            }
            foreach(var a in args.removed)
            {
            }
            foreach(var updated in args.updated)
            {
                if(updated.trackingState == TrackingState.None || updated.trackingState == TrackingState.Limited)
                {
                    updated.gameObject.SetActive(false);
                }
                else
                {
                    updated.gameObject.SetActive(true);
                }
            }
        };

    }

    void AddImage(Texture2D imageToAdd)
    {
        RuntimeReferenceImageLibrary runtimeLibrary = m_TrackedImageManager.CreateRuntimeLibrary();
        var mutable = runtimeLibrary as MutableRuntimeReferenceImageLibrary;
        mutable.ScheduleAddImageWithValidationJob(imageToAdd, "userImg", 1f);
        m_TrackedImageManager.referenceLibrary = mutable;
    }
}
