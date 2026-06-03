using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class MetricsLogger : MonoBehaviour
{
    public static MetricsLogger Instance;

    [Header("Session")]
    public string scenarioName = "Farm"; // Farm o Park
    public string taskName = "Task1";    // Task1, Task2, Task3...

    [Header("CSV")]
    public string separator = ";";

    private string filePath;
    private float taskStartTime;
    private bool taskStarted = false;
    private bool canLog = true;

    private HashSet<string> loggedEventsThisRun = new HashSet<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        SetupCSV();

        if (TaskAlreadyExistsInCSV())
        {
            Debug.LogWarning("La task " + taskName + " ya existe en el CSV. No se volverá a registrar.");
            canLog = false;
            return;
        }

        StartTask();
    }

    private void SetupCSV()
    {
        string cleanScenarioName = scenarioName.Trim();

        if (cleanScenarioName != "Farm" && cleanScenarioName != "Park")
        {
            Debug.LogWarning("scenarioName debería ser Farm o Park. Valor actual: " + cleanScenarioName);
        }

        string fileName = "MRGait_" + cleanScenarioName + ".csv";
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (!File.Exists(filePath))
        {
            string header =
                "scenario" + separator +
                "task" + separator +
                "event_category" + separator +
                "event_name" + separator +
                "event_state" + separator +
                "timestamp" + separator +
                "pos_x" + separator +
                "pos_y" + separator +
                "pos_z" + System.Environment.NewLine;

            File.WriteAllText(filePath, header);
            Debug.Log("CSV creado en: " + filePath);
        }
        else
        {
            Debug.Log("CSV existente encontrado en: " + filePath);
        }
    }

    private bool TaskAlreadyExistsInCSV()
    {
        if (!File.Exists(filePath))
            return false;

        string[] lines = File.ReadAllLines(filePath);

        for (int i = 1; i < lines.Length; i++) // saltamos la cabecera
        {
            string[] columns = lines[i].Split(separator);

            if (columns.Length < 2)
                continue;

            string scenarioInFile = columns[0];
            string taskInFile = columns[1];

            if (scenarioInFile == scenarioName && taskInFile == taskName)
            {
                return true;
            }
        }

        return false;
    }

    public void StartTask()
    {
        if (!canLog)
            return;

        taskStartTime = Time.time;
        taskStarted = true;

        LogEvent("TASK", "TASK_START", "START", Vector3.zero);
    }

    public void EndTask()
    {
        if (!canLog)
            return;

        LogEvent("TASK", "TASK_END", "END", Vector3.zero);
        taskStarted = false;
    }

    public void LogEvent(string category, string eventName, string eventState, Vector3 position)
    {
        if (!canLog)
            return;

        if (!taskStarted && eventName != "TASK_START")
            return;

        string eventKey = category + "_" + eventName + "_" + eventState;

        if (loggedEventsThisRun.Contains(eventKey))
        {
            Debug.Log("Evento duplicado ignorado: " + eventKey);
            return;
        }

        loggedEventsThisRun.Add(eventKey);

        float timestamp = Time.time - taskStartTime;

        string line =
            scenarioName + separator +
            taskName + separator +
            category + separator +
            eventName + separator +
            eventState + separator +
            timestamp.ToString("F3", CultureInfo.InvariantCulture) + separator +
            position.x.ToString("F3", CultureInfo.InvariantCulture) + separator +
            position.y.ToString("F3", CultureInfo.InvariantCulture) + separator +
            position.z.ToString("F3", CultureInfo.InvariantCulture) +
            System.Environment.NewLine;

        File.AppendAllText(filePath, line);

        Debug.Log(line);
    }
}