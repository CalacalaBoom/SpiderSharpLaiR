using LiveCharts;
using SpiderLaiR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpiderLaiR.Models
{
    class MainModel: NotifyBase
    {
        private FrameworkElement _maincontent;

        public FrameworkElement MainContent
        {
            get { return _maincontent; }
            set { _maincontent = value; this.DoNotify(); }
        }
        /// <summary>
        /// 用电量峰值
        /// </summary>
        private float _maxPower = 0;

        public float MaxPower
        {
            get { return _maxPower; }
            set { _maxPower = value; this.DoNotify(); }
        }
        /// <summary>
        /// CPU占用率峰值
        /// </summary>
        private float _maxLoad = 0;

        public float maxLoad
        {
            get { return _maxLoad; }
            set { _maxLoad = value; this.DoNotify(); }
        }
        /// <summary>
        /// CPU温度峰值
        /// </summary>
        private float _maxTemperature = 0;

        public float maxTemperature
        {
            get { return _maxTemperature; }
            set { _maxTemperature = value; this.DoNotify(); }
        }
        /// <summary>
        /// 内存占用率峰值
        /// </summary>
        private float _maxMemoryAvailable = 0;

        public float maxMemoryAvailable
        {
            get { return _maxMemoryAvailable; }
            set { _maxMemoryAvailable = value; this.DoNotify(); }
        }
        /// <summary>
        /// 磁盘读写速率峰值
        /// </summary>
        private float _maxDisk = 0;

        public float maxDisk
        {
            get { return _maxDisk; }
            set { _maxDisk = value; this.DoNotify(); }
        }
        /// <summary>
        /// CPU占用率
        /// </summary>
        private string _load;

        public string Load
        {
            get { return _load; }
            set { _load = value; this.DoNotify(); }
        }
        /// <summary>
        /// CPU 温度
        /// </summary>
		private string _temperature;

        public string Temperature
        {
            get { return _temperature; }
            set { _temperature = value; this.DoNotify(); }
        }
        /// <summary>
        /// 内存占用率
        /// </summary>
		private string _memoryAvailable;

        public string MemoryAvailable
        {
            get { return _memoryAvailable; }
            set { _memoryAvailable = value; this.DoNotify(); }
        }
        /// <summary>
        /// 磁盘读写速率
        /// </summary>
		private string _disk;

        public string Disk
        {
            get { return _disk; }
            set { _disk = value; this.DoNotify(); }
        }
        /// <summary>
        /// CPUChart
        /// </summary>
        private ChartValues<float> _cvLoad = new ChartValues<float>();

        public ChartValues<float> cvLoad
        {
            get { return _cvLoad; }
            set { _cvLoad = value; this.DoNotify(); }
        }
        /// <summary>
        /// CPU温度Chart
        /// </summary>
        private ChartValues<float> _cvTemperature = new ChartValues<float>();

        public ChartValues<float> cvTemperature
        {
            get { return _cvTemperature; }
            set { _cvTemperature = value; this.DoNotify(); }
        }
        /// <summary>
        /// 内存Chart
        /// </summary>
        private ChartValues<float> _cvMemoryAvailable = new ChartValues<float>();

        public ChartValues<float> cvMemoryAvailable
        {
            get { return _cvMemoryAvailable; }
            set { _cvMemoryAvailable = value; this.DoNotify(); }
        }
        /// <summary>
        /// 磁盘读写效率Chart
        /// </summary>
        private ChartValues<float> _cvDisk = new ChartValues<float>();

        public ChartValues<float> cvDisk
        {
            get { return _cvDisk; }
            set { _cvDisk = value; this.DoNotify(); }
        }
    }
}
