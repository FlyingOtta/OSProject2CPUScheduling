using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public class SchedulingMetrics
    {
        public string AlgorithmName { get; set; }

        public double[] WaitingTimes { get; set; }
        public double[] TurnaroundTimes { get; set; }
        public double[] ResponseTimes { get; set; }

        public double AverageWaitingTime { get; set; }
        public double AverageTurnaroundTime { get; set; }
        public double AverageResponseTime { get; set; }

        public double CpuUtilization { get; set; }
        public double Throughput { get; set; }

        public void DisplayMetrics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"--- {AlgorithmName} Results ---");

            for (int i = 0; i < WaitingTimes.Length; i++)
            {
                sb.AppendLine($"P{i + 1}: Wait = {WaitingTimes[i]}s | Turnaround = {TurnaroundTimes[i]}s | Response = {ResponseTimes[i]}s");
            }

            sb.AppendLine($"Average Wait Time: {AverageWaitingTime:F2}s");
            sb.AppendLine($"Average Turnaround Time: {AverageTurnaroundTime:F2}s");
            sb.AppendLine($"Average Response Time: {AverageResponseTime:F2}s");
            sb.AppendLine($"CPU Utilization: {CpuUtilization:F2}%");
            sb.AppendLine($"Throughput: {Throughput:F2} processes/sec");

            MessageBox.Show(sb.ToString(), "Scheduling Metrics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
