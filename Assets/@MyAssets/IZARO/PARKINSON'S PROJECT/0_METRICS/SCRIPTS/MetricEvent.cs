using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class MetricEvent
{
    private string m_sessionID;
    private string m_scenarioName = "Farm";
    private string m_taskName = "Task1";
    private int m_trialNumber = 1;
    private string m_category = "INTERACTION";
    private string m_eventName = "BELL";
    private string m_eventState = "RING";
    private float m_timestamp;
    private Vector3 m_position;

    public string SessionID
    {
        get => m_sessionID;
        set => m_sessionID = value;
    }
    public string ScenarioName
    {
        get => m_scenarioName;
        set => m_scenarioName = value;
    }
    public string TaskName
    {
        get => m_taskName;
        set => m_taskName = value;
    }
    public int TrialNumber
    {
        get => m_trialNumber;
        set => m_trialNumber = value;
    }
    public string Category
    {
        get => m_category;
        set => m_category = value;
    }
    public string EventName
    {
        get => m_eventName;
        set => m_eventName = value;
    }
    public string EventState
    {
        get => m_eventState;
        set => m_eventState = value;
    }
    public float Timestamp
    {
        get => m_timestamp;
        set => m_timestamp = value;
    }
    public Vector3 Position
    {
        get => m_position;
        set => m_position = value;
    }

    public MetricEvent(string sessionID, string scenarioName, string taskName, int trialNumber, string category, string eventName, string eventState, float timestamp, Vector3 position)
    {
        m_sessionID = sessionID;
        m_scenarioName = scenarioName;
        m_taskName = taskName;
        m_trialNumber = trialNumber;
        m_category = category;
        m_eventName = eventName;
        m_eventState = eventState;
        m_timestamp = timestamp;
        m_position = position;
    }

    public override string ToString()
    {
        string line =
            m_sessionID + "," +
            m_scenarioName + "," +
            m_taskName + "," +
            m_trialNumber + "," +
            m_category + "," +
            m_eventName + "," +
            m_eventState + "," +
            m_timestamp.ToString("F3", CultureInfo.InvariantCulture) + "," +
            m_position.x.ToString("F3", CultureInfo.InvariantCulture) + "," +
            m_position.y.ToString("F3", CultureInfo.InvariantCulture) + "," +
            m_position.z.ToString("F3", CultureInfo.InvariantCulture) + "\n";
        
        return line;
    }
}
