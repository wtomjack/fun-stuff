using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Project.Models;
using Project.Mapper;

namespace Project.Database
{
    public class DataAccessService
    {
        private SqlConnection Connection;
        private string QueryString;
        //args should be in this format TableName, String code of Id's to pull
        public DataAccessService(Dictionary<string, string> args = null)
        {
            this.Connection = BuildConnection();
            //this.QueryString = BuildQueryString("TEST");
            //BuildQueryString
            //LoadData
            //BuildObject
        }

        private static SqlConnection BuildConnection()
        {
            var connectionString = "Data Source=GP152130\\SqlExpress;Initial Catalog=Personal; Integrated Security = SSPI;";
            return new SqlConnection(connectionString);
        }

        private void BuildQueryString(string tableName)
        {
            this.QueryString = tableName;
        }

        public List<MenuItem> LoadMenuItems()
        {
            BuildQueryString("SELECT * FROM MenuItem");
            using (this.Connection)
            {
                using (var command = new SqlCommand(this.QueryString,this.Connection))
                {
                    try
                    {
                        this.Connection.Open();
                        var results = command.ExecuteReader();
                        var menuItems = new List<MenuItem>();
                        var subItems = new List<SubItem>();
                        while (results.Read())
                        {
                            var id = results.GetValueOrDefault<string>("Id");
                            var subItemKey = results.GetValueOrDefault<string>("SubItemKey");

                            if(subItemKey != null)
                            {
                                var subItem = new SubItem
                                {
                                    RouteController = results.GetValueOrDefault<string>("RouteController"),
                                    RouteMethod = results.GetValueOrDefault<string>("RouteAction"),
                                    Title = results.GetValueOrDefault<string>("Name"),
                                    SubItemKey = subItemKey,
                                    URL = results.GetValueOrDefault<string>("URL") 
                                };
                                subItems.Add(subItem);
                            }
                            else
                            {
                                var item = new MenuItem
                                {
                                    Title = results.GetValueOrDefault<string>("Name"),
                                    Id = id,
                                    RouteController = results.GetValueOrDefault<string>("RouteController"),
                                    RouteMethod = results.GetValueOrDefault<string>("RouteAction"),
                                };

                                menuItems.Add(item);
                            }

                        }
                        Mapper.Mapper.MenuMapper(subItems, menuItems);
                        return menuItems;
                    }
                    catch (SqlException e)
                    {
                        ////TODO Add logging
                        throw new Exception(e.ToString());
                    }
                    finally
                    {
                        command.Dispose();
                        if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
                        this.Connection.Dispose();
                    }
                }
            }
        }
    }
}