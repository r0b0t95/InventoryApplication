using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Connection
    {

        string ConnectionString { get; set; }

        public List<SqlParameter> ParamList = new List<SqlParameter>();

        public int PerformUpdateDeleteInsert( string SPName )
        {
            int Responce = 0;

            using ( SqlConnection MyCnn = new SqlConnection( ConnectionString ) )
            {
                SqlCommand MyCommand = new SqlCommand( SPName, MyCnn );
                MyCommand.CommandType = CommandType.StoredProcedure;

                if ( ParamList != null && ParamList.Count > 0 )
                {
                    foreach ( SqlParameter item in ParamList )
                    {
                        MyCommand.Parameters.Add(item);
                    }
                }

                MyCnn.Open();

                //if a command to perform is some = (update, Insert or delete) 
                //establich SET NOCOUNT OFF; en el SP 

                Responce = MyCommand.ExecuteNonQuery();
            }

            return Responce;
        }


        public DataTable PerformSelect( string SPName, bool LoadTable = false )
        {
            DataTable ReturnData = new DataTable();

            using ( SqlConnection MyCnn = new SqlConnection( ConnectionString ) )
            {
                SqlCommand MyCommand = new SqlCommand( SPName, MyCnn );
                MyCommand.CommandType = CommandType.StoredProcedure;
                if ( ParamList != null && ParamList.Count > 0 )
                {
                    foreach ( SqlParameter item in ParamList )
                    {
                        MyCommand.Parameters.Add( item );
                    }
                }
                SqlDataAdapter MyAdaptador = new SqlDataAdapter( MyCommand );

                if (LoadTable)
                {
                    MyAdaptador.FillSchema( ReturnData, SchemaType.Source );
                }
                else
                {
                    // optional Paso 1.3.1 y 1.3.2 
                    MyAdaptador.Fill( ReturnData );
                }
            }
            return ReturnData;
        }

        
        public Connection()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["CnnStr"].ToString();
        }

    }
}
