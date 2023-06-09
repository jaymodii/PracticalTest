﻿using DataAccessLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PriceChangeRepository:IPriceChangeInterface
    {
        private readonly string connectionString;

        public PriceChangeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string AddPriceChangeAndUpdateItem(PriceChangeDTO pricedata)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("AddPriceChangeAndUpdateItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Itemcode", pricedata.itemcode);
                        command.Parameters.AddWithValue("@Increase_Decrease", pricedata.increaseDecrease);
                        command.Parameters.AddWithValue("@PriceType", pricedata.priceType);
                        command.Parameters.AddWithValue("@PriceUpdate", pricedata.priceUpate);
                        command.Parameters.AddWithValue("@Amount", pricedata.amount);

                        command.ExecuteNonQuery();
                    }
                }

                return "Price change and item update successful.";
            }
            catch (SqlException ex)
            {

                string errorMessage = "An error occurred while adding price change and updating the item.";


                return errorMessage;
            }
        }

        public List<PriceChangeDTO> ListPriceChanges()
        {
            List<PriceChangeDTO> priceChanges = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                using SqlCommand command = new("ListPriceChanges", connection);
                command.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PriceChangeDTO priceChange = new()
                    {
                       
                        itemcode = (int)reader["Itemcode"],
                        oldcost = (decimal)reader["Oldcost"],
                        increaseDecrease = (string)reader["Increase_Decrease"],
                        priceType = (string)reader["PriceType"],
                        priceUpate = (string)reader["PriceUpdate"],
                        newcost = (decimal)reader["Newcost"],
                        oldprice = (decimal)reader["Oldprice"],
                        newprice = (decimal)reader["Newprice"],
                        Created = (DateTime)reader["CreateDate"]
                    };

                    priceChanges.Add(priceChange);
                }
            }   

            return priceChanges;
        }
    }
}
