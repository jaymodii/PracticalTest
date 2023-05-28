using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace DataAccessLayer.Repositories
{
    public class ItemRepository:IItemInterface
    {
        private readonly string connectionString; 

        public ItemRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ItemDTO> ListItems()
        {
            List<ItemDTO> items = new List<ItemDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using SqlCommand command = new SqlCommand("ListItems", connection);
                command.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ItemDTO item = new()
                    {

                        Srno = reader.GetInt32(reader.GetOrdinal("Srno")),
                        Itemcode = reader.GetInt32(reader.GetOrdinal("Itemcode")),
                        Barcode = reader.GetString(reader.GetOrdinal("Barcode")),
                        Itemname = reader.GetString(reader.GetOrdinal("Itemname")),
                        Cost = reader.GetDecimal(reader.GetOrdinal("Cost")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        CreateDate = reader.GetDateTime(reader.GetOrdinal("CreateDate")),
                        UpdateDate = reader.GetDateTime(reader.GetOrdinal("UpdateDate"))
                    };

                    items.Add(item);
                }
            }

            return items;
        }

        public string AddItem(ItemDTO itemDTO)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand("AddItem", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            command.Parameters.AddWithValue("@Itemcode", itemDTO.Itemcode);
            command.Parameters.AddWithValue("@Barcode", itemDTO.Barcode);
            command.Parameters.AddWithValue("@Itemname", itemDTO.Itemname);
            command.Parameters.AddWithValue("@Cost", itemDTO.Cost);
            command.Parameters.AddWithValue("@Price", itemDTO.Price);

            try
            {
                // Execute the stored procedure
                command.ExecuteNonQuery();
                return "Added Successfully";
            }
            catch (SqlException ex)
            {
                // Handle the exception
                if (ex.Number == 50000) // Custom error number for "Item with the same Itemname or Barcode already exists"
                {
                    return "Item with the same Itemname or Barcode already exists.";
                }
                else
                {
                    return "Error Occured";
                }
            }
        }

    }
}
