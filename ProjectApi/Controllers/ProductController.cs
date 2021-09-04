namespace ProjectApi.Controllers
{
    #region NameSpaces
    using ProductCommon;
    using ProjectApi.Models;
    using ProjectApi.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Http;
    #endregion

    public class ProductController : BaseController
    {
        private SqlConnection conn;

        //To Handle connection related activities 
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SubaruAppConnect"].ToString();
            conn = new SqlConnection(constr);
        }
        [HttpGet]
        public ApiResponse GetProductTypeList()
        {
            connection();
            using (conn)
            {
                try
                {
                    List<ProductType> ProductTypeList = new List<ProductType>();
                    SqlCommand com = new SqlCommand("USP_GetProductTypeList", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();

                    conn.Open();
                    da.Fill(dt);
                    conn.Close();
                    //Bind  generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {

                        ProductTypeList.Add(

                            new ProductType
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = Convert.ToString(dr["Name"]),
                                Description = Convert.ToString(dr["Description"])
                            }
                            );
                    }
                    return this.Response(MessageType.Success,string.Empty, ProductTypeList);
                }
                catch (System.Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        [HttpGet]
        public ApiResponse GetProductByTypeId(int id)
        {
            connection();
            using (conn)
            {
                try
                {
                    List<Product> ProductList = new List<Product>();
                    SqlCommand com = new SqlCommand("USP_GetProductByTypeId", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();

                    conn.Open();
                    da.Fill(dt);
                    conn.Close();
                   // Bind  generic list using dataRow
                    foreach (DataRow dr in dt.Rows)
                    {

                        ProductList.Add(

                            new Product
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = Convert.ToString(dr["Name"]),
                                Description = Convert.ToString(dr["Description"]),
                                TypeName = Convert.ToString(dr["TypeName"])
                            }
                            );
                    }
                    return this.Response(MessageType.Success, string.Empty, ProductList);
                }
                catch (System.Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
