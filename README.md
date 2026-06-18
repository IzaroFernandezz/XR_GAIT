# XR_GAIT

Mixed reality prototype for gait-task execution and post-acquisition movement review in the context of Parkinson's disease research.

> Academic research prototype developed as part of a Biomedical Engineering Final Degree Project.

---

## Overview

**XR_GAIT** is a Unity-based mixed reality prototype designed to reproduce gait-related tasks inside a controlled laboratory environment.

The project combines two complementary lines of work:

- retrospective analysis of clinical and STAT-ON™ ambulatory monitoring data;
- development of mixed reality gait tasks compatible with motion capture recordings.

This repository focuses on the **mixed reality prototype** and its technical workflow.

The prototype is not a clinical product, diagnostic tool or certified medical device.

---

## Prototype structure

The application includes two mixed reality scenarios:

### Farm scenario

A linear corridor environment designed to reproduce controlled walking conditions.

Main task elements:

- corridor walking;
- turning point;
- chickens crossing the path;
- trapdoors;
- button interaction;
- delayed environmental changes.

### Park scenario

A more open environment organised around a central fountain and several interaction areas.

Main task elements:

- route following;
- fountain buttons;
- object relocation;
- bench, bin and fruit stand areas;
- phone-guided instructions.

---

## Main workflow

```text
Unity MR application
        ↓
Meta Quest 3 execution
        ↓
Vicon motion capture recording
        ↓
Vicon Nexus reconstruction
        ↓
Blender FBX conversion
        ↓
Unity playback
        ↓
CSV event output
```

The reconstructed movement can be imported back into Unity and replayed inside the corresponding task scene. During playback, event colliders register relevant task points and generate CSV files containing:

- event names;
- timestamps;
- spatial positions;
- estimated forward speed.

---

## Requirements

The project was developed using:

- Unity;
- Meta Quest 3;
- Meta XR / Oculus XR support;
- Vicon Nexus;
- Blender;
- Python for later CSV processing.

The exact Unity and package versions should be checked in the project settings and package files.

---

## Running the prototype

To open and deploy the project:

1. Clone or download the repository.
2. Open the project in Unity.
3. Check that the required XR packages are installed.
4. Connect the Meta Quest 3 headset to the computer.
5. Open **File > Build Settings**.
6. Select **Android** as the target platform.
7. Check that the required scenes are included.
8. Press **Build And Run**.

After deployment, the application can be launched directly from the Meta Quest 3 headset.

---

## Current status

The prototype currently includes:

- two mixed reality scenarios;
- seven task configurations;
- scenario and task selection menus;
- instruction panels with route guidance;
- interaction logic for buttons, trapdoors, objects and phone-guided actions;
- compatibility with a post-acquisition Vicon workflow;
- CSV event-output generation from reconstructed movement playback.

The system has been tested with healthy volunteers for preliminary technical and usability evaluation.

---

## Limitations

- The MR protocol has not been clinically validated in patients with Parkinson's disease.
- Unity and Vicon were not synchronised in real time.
- Dynamic virtual elements cannot be fully reproduced during post-acquisition analysis.
- CSV outputs are event-based and do not replace full biomechanical gait analysis.
- Confidential clinical data, participant recordings and large motion capture files are not included.

---

## Disclaimer

This repository contains an academic research prototype. It is intended for documentation, development and research purposes only.
