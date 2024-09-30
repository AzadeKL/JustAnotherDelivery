using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private float dayStartHour = 8f;
    [SerializeField] private float framesPerHour = 60f;
    public TimeObject currentTime;
    public BoolVariable isGamePaused;

    [SerializeField] private bool isStopped = true; // Start in stopped state
    [SerializeField] private float time = 0f;
    [SerializeField] private float stopTime = 0f;
    [SerializeField] private bool hasTimer = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("TimeSystem");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        } 
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update 
    void Start()
    {
        currentTime.Set(dayStartHour);
        time = currentTime.GetTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused.value || isStopped) return;
        time += Time.deltaTime / framesPerHour;
        if (hasTimer && (time > stopTime))
        {
            time = stopTime;
            isStopped = true;
            hasTimer = false;
        }
        currentTime.Set(time);
    }

    public void StartTime()
    {
        isStopped = false;
    }

    public void StopTime()
    {
        isStopped = true;
    }

    public void StopTimeAt(float time)
    {
        stopTime = time;
        hasTimer = true;
    }

    public void StopTimeAfter(float timeInc)
    {
        stopTime = time + timeInc;
        hasTimer = true;
    }
}
