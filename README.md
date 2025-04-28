# CPU Scheduling Simulation Project

## Overview

This project simulates various CPU scheduling algorithms as part of an Operating Systems course assignment (CS 3502 at Kennesaw State University).  
The simulator is built using C# Windows Forms and provides a visual interface for selecting and running different scheduling strategies.

Implemented algorithms include:

- First Come First Serve (FCFS)
- Shortest Job First (SJF)
- Priority Scheduling
- Round Robin (RR)
- Shortest Remaining Time First (SRTF) *(newly implemented)*
- Highest Response Ratio Next (HRRN) *(newly implemented)*

Each scheduling algorithm outputs key performance metrics:
- Average Waiting Time (AWT)
- Average Turnaround Time (ATT)
- CPU Utilization
- Throughput (Processes per second)
- (Optional) Response Time

---

## How to Run the Project

1. Clone this repository:
   ```bash
   git clone https://github.com/FlyingOtta/OSProject2CPUScheduling.git
   ```
2. Open the project in Visual Studio (Community 2022 or later recommended).
3. Build the project:
   - Ensure all dependencies (if any) are restored.
   - Build the solution (`Ctrl+Shift+B`).

4. Run the application:
   - Use the buttons on the dashboard to select an algorithm.
   - Enter the number of processes and input burst/arrival times as prompted.
   - View scheduling metrics and results through the GUI.


   
   
