using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Utils.Log
{
    public class log_manager
    {        
        static readonly log_manager _instance = new log_manager();
        public static log_manager Instance
        {
            get { return _instance; }
        }
        
        public enum log_type_t
        {
            MESSAGE,
            WARNING,
            ERROR
        }

        private const String LOG_FILENAME = "\\log.xml";
        private System.Threading.Thread thread_xml;
        private System.Threading.SemaphoreSlim semaphore = new System.Threading.SemaphoreSlim(0);
        private Object lock_object = new Object();
        private Boolean thread_enable = true;
        public Int32 Size = Int32.MaxValue;

        public LogDataSet logDataSet;

        protected log_manager() 
        {
            this.logDataSet = new LogDataSet();

            this.logDataSet.DataSetName = "LogDataSet";
            this.logDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        }

        public void Start()
        {
            try
            {
                this.logDataSet.table_log_t.ReadXml(System.Environment.CurrentDirectory + LOG_FILENAME);
            }
            catch (Exception) { }

            this.thread_xml = new System.Threading.Thread(this.write_xml_thread);
            this.thread_xml.Priority = System.Threading.ThreadPriority.Lowest;
            this.thread_xml.IsBackground = true;
            this.thread_xml.Start();
        }

        public void Dispose()
        {
            try
            {
                this.thread_enable = false;
                this.semaphore.Release(1);
                this.thread_xml.Abort();
            }
            catch (Exception) { }

            lock (this.lock_object)
            {
                this.logDataSet.Dispose();
            }
        }

        public void Clear()
        {
            lock (this.lock_object)
            {
                this.logDataSet.table_log_t.Clear();
            }

            try
            {
                System.IO.FileInfo aFile = new System.IO.FileInfo(System.Environment.CurrentDirectory + LOG_FILENAME);
                aFile.Delete();
            }
            catch (Exception ex)
            {
                AddLog(log_type_t.ERROR, "LogManager (Clear): " + ex.Message);
            }
        }

        public void AddLog(log_type_t type, String message)
        {
            DateTime log_time = DateTime.Now;

            try
            {
                lock (this.lock_object)
                {
                    LogDataSet.table_log_tRow new_row =
                        this.logDataSet.table_log_t.Addtable_log_tRow(log_time, Convert.ToByte(type), message);

                    if (this.logDataSet.table_log_t.Rows.Count > this.Size)
                        this.logDataSet.table_log_t.Rows.RemoveAt(0);

                    this.semaphore.Release(1);
                }
            }
            catch (ConstraintException) { }
        }

        private void write_xml_thread()
        {
            while (this.thread_enable)
            {
                lock (this.lock_object)
                {
                    this.logDataSet.table_log_t.WriteXml(System.Environment.CurrentDirectory + LOG_FILENAME);
                }
                this.semaphore.Wait();
            }
        }
    }

}
