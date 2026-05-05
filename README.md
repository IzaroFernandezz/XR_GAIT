# XR_GAIT

## 1. What is XR_GAIT?

XR_GAIT is a research-oriented project focused on the development of mixed reality (XR) environments for the assessment of gait and motor function in Parkinson’s disease. The system aims to provide ecologically valid, controlled, and interactive scenarios that allow the evaluation of locomotion under conditions that are difficult to reproduce in traditional clinical settings.

By combining immersive technologies with data-driven analysis, XR_GAIT seeks to bridge the gap between laboratory-based assessments and real-world motor behaviour, contributing to more objective and context-aware evaluation methods.

---

## 2. Key Features

- **Mixed Reality environments** designed for gait and motor assessment  
- **Task-based interaction** (turning, obstacle avoidance, narrow spaces, dual-tasking)  
- **Integration with motion capture systems (Vicon)** for high-precision kinematic data  
- **Compatibility with Meta Quest 3 devices**  
- **Support for real-time interaction and user feedback**  
- **Data-driven analysis** of motor performance  

---

## 3. System Architecture

The XR_GAIT system is structured into three main layers:

### 3.1 Interaction Layer
- Mixed reality scenarios developed in **Unity**
- User interaction via **Meta Quest 3**
- Task-based environments simulating real-world challenges

### 3.2 Data Acquisition Layer
- Motion capture using **Vicon system**
- XR interaction data (position, timing, task performance)
- Optional integration with external datasets (e.g., wearable sensors)

### 3.3 Data Processing and Analysis
- Extraction of gait-related features
- Synchronisation between XR and motion capture data
- Preliminary analysis of motor patterns and behaviour

---

## 4. Components

- **Unity Application**
  - Core XR environment
  - Scenario design and interaction logic

- **XR Hardware**
  - Meta Quest 3 headset

- **Motion Capture System**
  - Vicon system for kinematic data acquisition

- **External Data Sources (optional)**
  - Wearable sensor datasets (e.g., STAT-ON)

---

## 5. Project Status

⚠️ **Development stage: Experimental / Research prototype**

- Mixed reality environments implemented and functional  
- Initial integration with motion capture systems  
- Preliminary testing conducted in healthy subjects  
- No clinical validation performed yet  

This project is part of an academic research initiative and is not intended for clinical use.

---

## 6. Download and Installation
Requirements
Unity (recommended version to be specified).
Meta Quest 3 headset.
Meta Quest Link, Air Link, or an equivalent deployment workflow.
Compatible PC for Unity development.
Vicon motion capture system (optional, required only for motion capture integration).
Git.
Installation Steps
Clone the repository:
```bash
   git clone https://github.com/BEGIBRAINLAB/XR_GAIT.git
   ```
Open the project in Unity.
Install or verify the required Unity packages:
XR Plugin Management.
OpenXR Plugin.
Meta XR / Oculus XR support, if required by the project configuration.
Configure the XR build settings:
Select Android as the target platform.
Enable XR support.
Configure the project for Meta Quest 3 deployment.
Connect the Meta Quest 3 headset to the development computer.
Build and deploy the application to the headset.
Optional: configure Vicon integration if motion capture data are required.
---
## 7. Usage
Launch the application on the Meta Quest 3 headset.
Select the desired mixed-reality scenario from the main menu.
Fol0low the instructions displayed in the environment.
Perform the task-based activities, which may include:
Walking through constrained spaces.
Turning tasks.
Obstacle avoidance.
Dual-task interaction.
Postural or reaching tasks.
If data recording is enabled, task events and interaction data can be stored for later analysis.
If the Vicon system is used, motion capture recording should be started and synchronised according to the experimental protocol.
---
## 8. Limitations
The current version of XR_GAIT presents several limitations:
The system has not yet been clinically validated in patients with Parkinson’s disease.
Testing has been limited to preliminary feasibility trials.
Motion capture integration is still under development.
The number of implemented scenarios and tasks may change as the project evolves.
Quantitative analysis pipelines are still exploratory.
Results obtained with the current prototype should be interpreted as preliminary.
---
## 9. Future Work
Planned future developments include:
Refinement of the mixed-reality scenarios.
Improved synchronisation between Unity and Vicon motion capture data.
Development of automated data extraction and analysis pipelines.
Expansion of task-based environments for gait, turning, obstacle avoidance, and postural control.
Usability testing with larger groups of healthy participants.
Future clinical validation in patients with Parkinson’s disease, subject to ethical approval.
Exploration of integration with wearable sensor data.
---
## 10. Acknowledgements
This project has been developed within the Neurodegenerative Diseases research environment at Biobizkaia Health Research Institute.
The work is part of an academic research project in Biomedical Engineering focused on the application of mixed-reality technologies and quantitative movement analysis to the assessment of motor function in Parkinson’s disease.
---
## 11. Licence
The licence for this repository has not yet been specified.
Please contact the project maintainers before using, modifying, or redistributing the contents of this repository.
