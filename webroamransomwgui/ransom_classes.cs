using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.IO;

namespace webroamransomwgui
{
    public class Csv
    {
        public static DataTable DataSetGet(string filename, string separatorChar, out List<string> errors)
        {
            errors = new List<string>();
            var table = new DataTable("CSVTable");
            using (var sr = new StreamReader(filename, Encoding.UTF8))
            {
                string line;
                var i = 0;
                while (sr.Peek() >= 0)
                {
                    try
                    {
                        line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        var values = line.Split(new[] { separatorChar }, StringSplitOptions.None);
                        var row = table.NewRow();
                        for (var colNum = 0; colNum < values.Length-1; colNum++)
                        {
                            var value = values[colNum];
                            if (i == 0)
                            {
                                table.Columns.Add(value, typeof(String));
                            }
                            else
                            {
                                row[table.Columns[colNum]] = value;
                            }
                        }
                        if (i != 0) table.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        errors.Add(ex.Message);
                    }
                    i++;
                }
            }
            return table;
        }
    }
    public static class SqlReaderWriter
    {
        public static void DeleteQuery(string del)
        {
            // MessageBox.Show(insertorUpdq);
            SqlCeConnection m_dbConnection = new SqlCeConnection($"Data Source={(System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb;");
            m_dbConnection.Open();
            SqlCeCommand cmdDelete = new SqlCeCommand(del, m_dbConnection);
            int retVal = cmdDelete.ExecuteNonQuery();


                m_dbConnection.Close();
            
        }

        public static void ExecuteQuery(string insertorUpdq)
        {
            // MessageBox.Show(insertorUpdq);
            using (SqlCeConnection m_dbConnection = new SqlCeConnection($"Data Source={(System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb;"))
            {
                m_dbConnection.Open();
                
                    //string sql2 = "insert into highscores (name, family, score) values ('Me', 'Asghari', 3000)";
                    using (SqlCeCommand command2 = new SqlCeCommand(insertorUpdq, m_dbConnection))
                    {
                        try
                        {
                            command2.ExecuteNonQuery();
                        }
                        catch(Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    
                
              m_dbConnection.Close();
            }
        }


        public static DataTable ReadQuery(string selectq)
        {
            using (SqlCeConnection m_dbConnection = new SqlCeConnection($"Data Source={(System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb;"))
            {
                m_dbConnection.Open();
                using (SqlCeCommand command = new SqlCeCommand(selectq, m_dbConnection))
                {
                    command.CommandText = selectq;//"SELECT score, name, family FROM highscores";

                    DataSet DST = new DataSet();
                    DataTable DT = new DataTable();
                    using (SqlCeDataAdapter SDA = new SqlCeDataAdapter(command))
                    {

                        SDA.Fill(DT);
                        m_dbConnection.Close();
                        return DT;
                    }
                }
               
            }
               
           
            
        }


        public static object ExecuteScalar(string squery)
        {
            object rt;
            using (SqlCeConnection m_dbConnection = new SqlCeConnection($"Data Source={(System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb;"))
            {
                m_dbConnection.Open();
                //string sql2 = "insert into highscores (name, family, score) values ('Me', 'Asghari', 3000)";
                using (SqlCeCommand command2 = new SqlCeCommand(squery, m_dbConnection))
                {

                    //en.CreateDatabase();
                    //en.Upgrade();
                    
                    rt = command2.ExecuteScalar();
                }
                m_dbConnection.Close();
            }
            
            return rt;
        }
        public static int CountOfRow(string tableName, string Where)
        {
            int count = 0;
            count = Int32.Parse(ExecuteScalar("SELECT COUNT(*) FROM " + tableName + " " + Where).ToString());
            if(count>0)
                return Int32.Parse(ExecuteScalar("SELECT MAX(ID) FROM " + tableName + " " + Where).ToString());
            return count;
        }
        public static int CountOfRow(string tableName)
        {
            
            return CountOfRow(tableName, "");
        }
    }


}
