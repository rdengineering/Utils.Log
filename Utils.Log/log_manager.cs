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

        public LogDataSet logDataSet;

        public log_manager() 
        {
            this.logDataSet = new LogDataSet();

            this.logDataSet.DataSetName = "LogDataSet";
            this.logDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

            try
            {
                this.logDataSet.table_log_t.ReadXml(System.Environment.CurrentDirectory + LOG_FILENAME);
            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            this.logDataSet.Dispose();
        }

        public void Clear()
        {
            this.logDataSet.table_log_t.Clear();

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
                LogDataSet.table_log_tRow new_row =
                    this.logDataSet.table_log_t.Addtable_log_tRow(log_time, Convert.ToByte(type), message);
            }
            catch (ConstraintException) { }

            this.logDataSet.table_log_t.WriteXml(System.Environment.CurrentDirectory + LOG_FILENAME);
        }
    }

}
