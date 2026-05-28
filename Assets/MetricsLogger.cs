using System;
using System.Globalization;
using System.IO;
using UnityEngine;

public class MetricsLogger : MonoBehaviour
{
    public static MetricsLogger Instance;

    [Header("Session")]
    public string scenarioName = "Farm";
    public string taskName = "Task1";
    public int trialNumber = 1;

    private string sessionID;
    private string filePath;
    private float taskStartTime;
    private bool taskStarted = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        CreateCSV();
    }

    private void CreateCSV()
    {
        sessionID = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"MRGait_{scenarioName}_{taskName}_{sessionID}.csv";
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        string header = "session_id,scenario,task,trial,event_category,event_name,event_state,timestamp,pos_x,pos_y,pos_z\n";
        File.WriteAllText(filePath, header);

        Debug.Log("CSV created at: " + filePath);
    }

    public void StartTask()
    {
        taskStartTime = Time.time;
        taskStarted = true;

        LogEvent("TASK", "TASK_START", "START", Vector3.zero);
    }

    public void EndTask()
    {
        LogEvent("TASK", "TASK_END", "END", Vector3.zero);
        taskStarted = false;
    }

    public void LogEvent(string category, string eventName, string eventState, Vector3 position)
    {
        if (!taskStarted && eventName != "TASK_START")
            return;

        float timestamp = Time.time - taskStartTime;

        string line =
            sessionID + "," +
            scenarioName + "," +
            taskName + "," +
            trialNumber + "," +
            category + "," +
            eventName + "," +
            eventState + "," +
            timestamp.ToString("F3", CultureInfo.InvariantCulture) + "," +
            position.x.ToString("F3", CultureInfo.InvariantCulture) + "," +
            position.y.ToString("F3", CultureInfo.InvariantCulture) + "," +
            position.z.ToString("F3", CultureInfo.InvariantCulture) + "\n";

        File.AppendAllText(filePath, line);
        Debug.Log(line);
    }

    public void LogMetricEvent(MetricEvent metricEvent)
    {
        string line = metricEvent.ToString();

        File.AppendAllText(filePath, line);
        Debug.Log(line);
    }
}