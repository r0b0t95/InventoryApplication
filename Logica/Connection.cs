﻿using System;
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


        public int ExecuteUpdateDeleteInsert( string SPName )
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
                        MyCommand.Parameters.Add( item );
                    }
                }

                MyCnn.Open();

                Responce = MyCommand.ExecuteNonQuery();
            }

            return Responce;
        }


        public DataTable ExecuteSelect( string SPName, bool LoadTable = false )
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

                if ( LoadTable )
                {
                    MyAdaptador.FillSchema( ReturnData, SchemaType.Source );
                }
                else
                {

                    MyAdaptador.Fill( ReturnData );
                }
            }
            return ReturnData;
        }


        public Object ExecuteScalarReturn( string SPName )
        {
            Object Retorno = null;

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

                MyCnn.Open();
                Retorno = MyCommand.ExecuteScalar();
            }

            return Retorno;
        }


        public void backupDataBase()
        {
            Connection conn = new Connection();
            
            conn.ExecuteUpdateDeleteInsert( "BackUpDatabase" );
        }


        public Connection()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["CnnStr"].ToString();
        }

    }
}
