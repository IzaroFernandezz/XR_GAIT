using System.Globalization;
using System.IO;
using UnityEngine;

public class MetricsLogger : MonoBehaviour
{
    public static MetricsLogger Instance;

    [Header("Session")]
    public string scenarioName = "Farm";
    public string taskName = "Task1";

    [Header("CSV")]
    public string separator = ";";

    private string filePath;
    private float taskStartTime;
    private bool hasFirstPoint = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SetupCSV();
    }

    private void SetupCSV()
    {
        scenarioName = scenarioName.Trim();
        taskName = taskName.Trim();

        string fileName = "MRGait_" + scenarioName + ".csv";
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (!File.Exists(filePath))
        {
            string header =
                "scenario" + separator +
                "task" + separator +
                "point" + separator +
                "timestamp" + separator +
                "pos_x" + separator +
                "pos_y" + separator +
                "pos_z" + separator +
                "forward_speed" + System.Environment.NewLine;

            File.WriteAllText(filePath, header);
            Debug.Log("CSV created at: " + filePath);
        }
        else
        {
            Debug.Log("Existing CSV found at: " + filePath);
        }
    }

    public void SetTask(string newScenarioName, string newTaskName)
    {
        scenarioName = newScenarioName.Trim();
        taskName = newTaskName.Trim();

        hasFirstPoint = false;

        SetupCSV();
    }

    public void LogPoint(string pointName, Vector3 position, float forwardSpeed)
    {
        if (!hasFirstPoint)
        {
            taskStartTime = Time.time;
            hasFirstPoint = true;
        }

        float timestamp = Time.time - taskStartTime;

        string line =
            scenarioName + separator +
            taskName + separator +
            pointName + separator +
            timestamp.ToString("F3", CultureInfo.InvariantCulture) + separator +
            position.x.ToString("F3", CultureInfo.InvariantCulture) + separator +
            position.y.ToString("F3", CultureInfo.InvariantCulture) + separator +
            position.z.ToString("F3", CultureInfo.InvariantCulture) + separator +
            forwardSpeed.ToString("F3", CultureInfo.InvariantCulture) +
            System.Environment.NewLine;

        File.AppendAllText(filePath, line);
        Debug.Log(line);
    }

    public void LogEvent(string category, string eventName, string eventState, Vector3 position)
    {
        Debug.LogWarning("Old LogEvent ignored: " + category + " / " + eventName + " / " + eventState);
    }
}