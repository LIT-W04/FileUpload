using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ImageWithText
    {
        public int Id { get; set; }
        public string ImageText { get; set; }
        public string FileName { get; set; }
    }

    public class DB
    {
        public IEnumerable<ImageWithText> GetImages()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConStr);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Images";
            List<ImageWithText> result = new List<ImageWithText>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ImageWithText text = new ImageWithText
                {
                    Id = (int) reader["Id"],
                    FileName = (string) reader["FileName"],
                    ImageText = (string) reader["ImageText"]
                };
                result.Add(text);
            }

            return result;
        }

        public void Add(string text, string fileName)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConStr);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Images VALUES (@text, @file)";
            command.Parameters.AddWithValue("@text", text);
            command.Parameters.AddWithValue("@file", fileName);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}