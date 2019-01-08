using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightServer
{
    public class VeraModel
    {
        public class RootObject
        {
            public Startup startup { get; set; }
            public Device[] devices { get; set; }
            public Scene[] scenes { get; set; }
            public int Using_2G { get; set; }
            public int LoadTime { get; set; }
            public int DataVersion { get; set; }
            public int UserData_DataVersion { get; set; }
            public int TimeStamp { get; set; }
            public int lights_on { get; set; }
            public int lights_off { get; set; }
            public int doors_locked { get; set; }
            public int doors_unlocked { get; set; }
            public int sensors_tripped { get; set; }
            public int sensors_not_tripped { get; set; }
            public int failed_devices { get; set; }
            public int visible_devices { get; set; }
            public int partitions_active { get; set; }
            public int partitions_notactive { get; set; }
            public Alert[] alerts { get; set; }
            public int ZWaveStatus { get; set; }
            public int Mode { get; set; }
            public string LocalTime { get; set; }
        }

        public class Startup
        {
            public Task[] tasks { get; set; }
        }

        public class Task
        {
            public int id { get; set; }
            public int status { get; set; }
            public string type { get; set; }
            public string comments { get; set; }
        }

        public class Device
        {
            public int id { get; set; }
            public State[] states { get; set; }
            public object[] Jobs { get; set; }
            public int PendingJobs { get; set; }
            public Tooltip tooltip { get; set; }
            public int status { get; set; }
        }

        public class Tooltip
        {
            public int display { get; set; }
            public string tag2 { get; set; }
        }

        public class State
        {
            public int id { get; set; }
            public string service { get; set; }
            public string variable { get; set; }
            public string value { get; set; }
        }

        public class Scene
        {
            public int id { get; set; }
            public object[] Jobs { get; set; }
            public Tooltip1 tooltip { get; set; }
            public int status { get; set; }
            public bool active { get; set; }
        }

        public class Tooltip1
        {
            public int display { get; set; }
        }

        public class Alert
        {
            public string PK_Alert { get; set; }
            public string LocalDate { get; set; }
            public int EventType { get; set; }
            public int SourceType { get; set; }
            public int Argument { get; set; }
            public int Filesize { get; set; }
            public int Severity { get; set; }
            public int LocalTimestamp { get; set; }
            public string Code { get; set; }
            public string NewValue { get; set; }
            public string Description { get; set; }
            public string Users { get; set; }
            public string Server_Storage { get; set; }
            public string Key { get; set; }
            public string Icon { get; set; }
            public string PK_Store { get; set; }
        }

    }
}
