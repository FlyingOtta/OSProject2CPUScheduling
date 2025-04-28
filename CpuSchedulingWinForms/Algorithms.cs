using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {
        public static void fcfsAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            double[] responseTime = new double[np];

            double totalCpuTime = 0;
            int currentTime = 0;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter burst time for P{i + 1}", "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(burstInput);
                    arrivalTime[i] = 0; // FCFS assumes all processes arrive at 0 unless otherwise stated
                }

                for (int i = 0; i < np; i++)
                {
                    if (i == 0)
                    {
                        waitingTime[i] = 0;
                        responseTime[i] = 0;
                    }
                    else
                    {
                        waitingTime[i] = waitingTime[i - 1] + burstTime[i - 1];
                        responseTime[i] = waitingTime[i];
                    }
                    turnaroundTime[i] = waitingTime[i] + burstTime[i];
                    currentTime += (int)burstTime[i];
                }

                totalCpuTime = burstTime.Sum();

                SchedulingMetrics metrics = new SchedulingMetrics
                {
                    AlgorithmName = "First Come First Serve (FCFS)",
                    WaitingTimes = waitingTime,
                    TurnaroundTimes = turnaroundTime,
                    ResponseTimes = responseTime,
                    AverageWaitingTime = waitingTime.Average(),
                    AverageTurnaroundTime = turnaroundTime.Average(),
                    AverageResponseTime = responseTime.Average(),
                    CpuUtilization = (totalCpuTime / currentTime) * 100,
                    Throughput = (double)np / currentTime
                };
                metrics.DisplayMetrics();
            }
        }

        public static void sjfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] burstTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            double[] responseTime = new double[np];
            bool[] isCompleted = new bool[np];
            int completed = 0;
            int currentTime = 0;

            DialogResult result = MessageBox.Show("Shortest Job First Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter burst time for P{i + 1}", "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(burstInput);
                }

                while (completed != np)
                {
                    int idx = -1;
                    double minBurst = double.MaxValue;
                    for (int i = 0; i < np; i++)
                    {
                        if (!isCompleted[i] && burstTime[i] < minBurst)
                        {
                            minBurst = burstTime[i];
                            idx = i;
                        }
                    }

                    if (idx != -1)
                    {
                        waitingTime[idx] = currentTime;
                        responseTime[idx] = currentTime;
                        currentTime += (int)burstTime[idx];
                        turnaroundTime[idx] = waitingTime[idx] + burstTime[idx];
                        isCompleted[idx] = true;
                        completed++;
                    }
                }

                double totalCpuTime = burstTime.Sum();

                SchedulingMetrics metrics = new SchedulingMetrics
                {
                    AlgorithmName = "Shortest Job First (SJF)",
                    WaitingTimes = waitingTime,
                    TurnaroundTimes = turnaroundTime,
                    ResponseTimes = responseTime,
                    AverageWaitingTime = waitingTime.Average(),
                    AverageTurnaroundTime = turnaroundTime.Average(),
                    AverageResponseTime = responseTime.Average(),
                    CpuUtilization = (totalCpuTime / currentTime) * 100,
                    Throughput = (double)np / currentTime
                };
                metrics.DisplayMetrics();
            }
        }

        public static void priorityAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] burstTime = new double[np];
            int[] priority = new int[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            double[] responseTime = new double[np];
            bool[] isCompleted = new bool[np];
            int completed = 0;
            int currentTime = 0;

            DialogResult result = MessageBox.Show("Priority Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter burst time for P{i + 1}", "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(burstInput);

                    string priorityInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter priority for P{i + 1}", "Priority", "", -1, -1);
                    priority[i] = Convert.ToInt32(priorityInput);
                }

                while (completed != np)
                {
                    int idx = -1;
                    int minPriority = int.MaxValue;
                    for (int i = 0; i < np; i++)
                    {
                        if (!isCompleted[i] && priority[i] < minPriority)
                        {
                            minPriority = priority[i];
                            idx = i;
                        }
                    }

                    if (idx != -1)
                    {
                        waitingTime[idx] = currentTime;
                        responseTime[idx] = currentTime;
                        currentTime += (int)burstTime[idx];
                        turnaroundTime[idx] = waitingTime[idx] + burstTime[idx];
                        isCompleted[idx] = true;
                        completed++;
                    }
                }

                double totalCpuTime = burstTime.Sum();

                SchedulingMetrics metrics = new SchedulingMetrics
                {
                    AlgorithmName = "Priority Scheduling",
                    WaitingTimes = waitingTime,
                    TurnaroundTimes = turnaroundTime,
                    ResponseTimes = responseTime,
                    AverageWaitingTime = waitingTime.Average(),
                    AverageTurnaroundTime = turnaroundTime.Average(),
                    AverageResponseTime = responseTime.Average(),
                    CpuUtilization = (totalCpuTime / currentTime) * 100,
                    Throughput = (double)np / currentTime
                };
                metrics.DisplayMetrics();
            }
        }

        public static void roundRobinAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] remainingTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            double[] responseTime = new double[np];
            bool[] firstResponse = new bool[np];
            int x = np;
            int currentTime = 0;
            double timeQuantum;

            DialogResult result = MessageBox.Show("Round Robin Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    string arrivalInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter arrival time for P{i + 1}", "Arrival Time", "", -1, -1);
                    arrivalTime[i] = Convert.ToDouble(arrivalInput);

                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter burst time for P{i + 1}", "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(burstInput);

                    remainingTime[i] = burstTime[i];
                    firstResponse[i] = true;
                }

                string quantumInput = Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum:", "Time Quantum", "", -1, -1);
                timeQuantum = Convert.ToDouble(quantumInput);
                Helper.QuantumTime = quantumInput;

                while (x != 0)
                {
                    for (int i = 0; i < np; i++)
                    {
                        if (remainingTime[i] > 0 && arrivalTime[i] <= currentTime)
                        {
                            if (firstResponse[i])
                            {
                                responseTime[i] = currentTime - arrivalTime[i];
                                if (responseTime[i] < 0) responseTime[i] = 0;
                                firstResponse[i] = false;
                            }

                            if (remainingTime[i] <= timeQuantum)
                            {
                                currentTime += (int)remainingTime[i];
                                turnaroundTime[i] = currentTime - arrivalTime[i];
                                waitingTime[i] = turnaroundTime[i] - burstTime[i];
                                remainingTime[i] = 0;
                                x--;
                            }
                            else
                            {
                                remainingTime[i] -= timeQuantum;
                                currentTime += (int)timeQuantum;
                            }
                        }
                    }
                }

                double totalCpuTime = burstTime.Sum();

                SchedulingMetrics metrics = new SchedulingMetrics
                {
                    AlgorithmName = "Round Robin",
                    WaitingTimes = waitingTime,
                    TurnaroundTimes = turnaroundTime,
                    ResponseTimes = responseTime,
                    AverageWaitingTime = waitingTime.Average(),
                    AverageTurnaroundTime = turnaroundTime.Average(),
                    AverageResponseTime = responseTime.Average(),
                    CpuUtilization = (totalCpuTime / currentTime) * 100,
                    Throughput = (double)np / currentTime
                };
                metrics.DisplayMetrics();
            }
        }

        public static void srtfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] remainingTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            double[] responseTime = new double[np];
            bool[] isCompleted = new bool[np];
            int completed = 0, currentTime = 0;
            bool firstResponse;

            DialogResult result = MessageBox.Show("Shortest Remaining Time First (SRTF) Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    string arrivalInput = Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time for P" + (i + 1), "Arrival Time", "", -1, -1);
                    arrivalTime[i] = Convert.ToInt64(arrivalInput);

                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time for P" + (i + 1), "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToInt64(burstInput);

                    remainingTime[i] = burstTime[i];
                }

                int prev = -1;
                while (completed != np)
                {
                    int idx = -1;
                    int minRemaining = int.MaxValue;
                    for (int i = 0; i < np; i++)
                    {
                        if (arrivalTime[i] <= currentTime && !isCompleted[i] && remainingTime[i] < minRemaining)
                        {
                            minRemaining = (int)remainingTime[i];
                            idx = i;
                        }
                    }

                    if (idx != -1)
                    {
                        if (remainingTime[idx] == burstTime[idx])
                        {
                            responseTime[idx] = currentTime - arrivalTime[idx];
                            if (responseTime[idx] < 0) responseTime[idx] = 0;
                        }

                        remainingTime[idx]--;
                        currentTime++;

                        if (remainingTime[idx] == 0)
                        {
                            turnaroundTime[idx] = currentTime - arrivalTime[idx];
                            waitingTime[idx] = turnaroundTime[idx] - burstTime[idx];
                            isCompleted[idx] = true;
                            completed++;

                            MessageBox.Show($"Process {idx + 1} completed. Turnaround = {turnaroundTime[idx]}, Waiting = {waitingTime[idx]}, Response = {responseTime[idx]}", "Process Completed", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        currentTime++;
                    }
                }

                
                SchedulingMetrics metrics = new SchedulingMetrics
                {
                    AlgorithmName = "SRTF",
                    WaitingTimes = waitingTime,
                    TurnaroundTimes = turnaroundTime,
                    ResponseTimes = responseTime,
                    AverageWaitingTime = waitingTime.Average(),
                    AverageTurnaroundTime = turnaroundTime.Average(),
                    AverageResponseTime = responseTime.Average(),
                    CpuUtilization = ((double)burstTime.Sum() / currentTime) * 100,
                    Throughput = (double)np / currentTime
                };
                metrics.DisplayMetrics();
            }
        }

        public static void hrrnAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            double[] responseTime = new double[np];
            bool[] isCompleted = new bool[np];
            int completed = 0, currentTime = 0;

            DialogResult result = MessageBox.Show("Highest Response Ratio Next (HRRN) Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    string arrivalInput = Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time for P" + (i + 1), "Arrival Time", "", -1, -1);
                    arrivalTime[i] = Convert.ToInt64(arrivalInput);

                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time for P" + (i + 1), "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToInt64(burstInput);
                }

                while (completed != np)
                {
                    double maxRatio = -1;
                    int idx = -1;
                    for (int i = 0; i < np; i++)
                    {
                        if (arrivalTime[i] <= currentTime && !isCompleted[i])
                        {
                            double responseRatio = (waitingTime[i] + burstTime[i]) / burstTime[i];
                            if (responseRatio > maxRatio)
                            {
                                maxRatio = responseRatio;
                                idx = i;
                            }
                        }
                    }

                    if (idx != -1)
                    {
                        if (currentTime < arrivalTime[idx])
                            currentTime = (int)arrivalTime[idx];

                        waitingTime[idx] = currentTime - arrivalTime[idx];
                        responseTime[idx] = waitingTime[idx];
                        currentTime += (int)burstTime[idx];
                        turnaroundTime[idx] = currentTime - arrivalTime[idx];
                        isCompleted[idx] = true;
                        completed++;

                        MessageBox.Show($"Process {idx + 1} completed. Turnaround = {turnaroundTime[idx]}, Waiting = {waitingTime[idx]}, Response = {responseTime[idx]}", "Process Completed", MessageBoxButtons.OK);
                    }
                    else
                    {
                        currentTime++;
                    }
                }

                
                SchedulingMetrics metrics = new SchedulingMetrics
                {
                    AlgorithmName = "HRRN",
                    WaitingTimes = waitingTime,
                    TurnaroundTimes = turnaroundTime,
                    ResponseTimes = responseTime,
                    AverageWaitingTime = waitingTime.Average(),
                    AverageTurnaroundTime = turnaroundTime.Average(),
                    AverageResponseTime = responseTime.Average(),
                    CpuUtilization = ((double)burstTime.Sum() / currentTime) * 100,
                    Throughput = (double)np / currentTime
                };
                metrics.DisplayMetrics();
            }
        }
    }
}
