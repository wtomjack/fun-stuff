using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Project.Database
{
    /// <summary>
    /// Data access helper class.
    /// </summary>
    public static class DataAccessHelper
    {
        /// <summary>
        /// Gets the value from data reader.
        /// </summary>
        /// <typeparam name="T">Generic value input</typeparam>
        /// <param name="reader">Data reader.</param>
        /// <param name="name">Name of the table value.</param>
        /// <returns>A value of input type T.</returns>
        public static T GetValueOrDefault<T>(this SqlDataReader reader, string name)
        {
            var value = reader[name];
            if (DBNull.Value == value) return default(T);
            return (T)value;
        }

        /// <summary>
        /// Gets the value from data reader.
        /// </summary>
        /// <typeparam name="T">Input type.</typeparam>
        /// <param name="reader">Data reader.</param>
        /// <param name="index">Integer index value from reader.</param>
        /// <returns>Value of input type t.</returns>
        public static T GetValueOrDefault<T>(this SqlDataReader reader, int index)
        {
            if (reader.IsDBNull(index)) return default(T);
            return (T)reader[index];
        }

        /// <summary>
        /// Checks if data reader value is null.
        /// </summary>
        /// <param name="reader">Data reader.</param>
        /// <param name="name">Name of the table value.</param>
        /// <returns>A value indicating whether the table value is null.</returns>
        public static bool IsDbNull(this SqlDataReader reader, string name)
        {
            return reader.IsDBNull(reader.GetOrdinal(name));
        }
    }
}