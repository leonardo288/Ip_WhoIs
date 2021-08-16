using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Repository
{
    public class ImportIp
    {
        public void InsertIntoDB(string IP)
        {
            string url = "https://ipwhois.app/json/" + IP;
            String connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            List<IPAddress> iPAddresses = new List<IPAddress>();

            string json = RestAPI.CallRestMethod(url);

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //string sqlCommand = "INSERT INTO IpAdrese (ip, type, continent, continent_code, country, country_code, country_flag, country_capital, country_phone, country_neighbours, region, city, latitude, longitude, asn, isp, timezone, timezone_name, timezone_dstOffset, timezone_gmtOffset, timezone_gmt, currency, currency_code, currency_symbol, currency_rates, currency_plural) VALUES (@ip, @type, @continent, @continent_code, @country, @country_code @country_flag, @country_capital, @country_phone, @country_neighbours, @region, @city, @latitude, @longitude, @asn, @isp, @timezone, @timezone_name, @timezone_dstOffset, @timezone_gmtOffset, @timezone_gmt, @currency, @currency_code, @currency_symbol, @currency_rates, @currency_plural)";
                string sqlCommand = "INSERT INTO Gal_IpAdrese (ip, success, type, continent, continent_code, country, country_code, country_flag, country_capital, country_phone, country_neighbours, region, city, latitude, longitude, asn, org, isp, timezone, timezone_name, timezone_dstOffset, timezone_gmtOffset, timezone_gmt, currency, currency_code, currency_symbol, currency_rates, currency_plural, completed_requests) VALUES (@ip, @success, @type, @continent, @continent_code, @country, @country_code, @country_flag, @country_capital, @country_phone, @country_neighbours, @region, @city, @latitude, @longitude, @asn, @org, @isp, @timezone, @timezone_name, @timezone_dstOffset, @timezone_dstOffset, @timezone_gmt, @currency, @currency_code, @currency_symbol, @currency_rates, @currency_plural, @completed_requests)";

                var objects = JObject.Parse(json);
                try
                {
                    using (SqlCommand oCommand = new SqlCommand(sqlCommand, sqlConnection))
                    {
                        oCommand.Parameters.Clear();
                        oCommand.Parameters.AddWithValue("@ip", objects["ip"].ToString());
                        oCommand.Parameters.AddWithValue("@success", objects["success"].ToString());
                        oCommand.Parameters.AddWithValue("@type", objects["type"].ToString());
                        oCommand.Parameters.AddWithValue("@continent", objects["continent"].ToString());
                        oCommand.Parameters.AddWithValue("@continent_code", objects["continent_code"].ToString());
                        oCommand.Parameters.AddWithValue("@country", objects["country"].ToString());
                        oCommand.Parameters.AddWithValue("@country_code", objects["country_code"].ToString());
                        oCommand.Parameters.AddWithValue("@country_flag", objects["country_flag"].ToString());
                        oCommand.Parameters.AddWithValue("@country_capital", objects["country_capital"].ToString());
                        oCommand.Parameters.AddWithValue("@country_phone", objects["country_phone"].ToString());
                        oCommand.Parameters.AddWithValue("@country_neighbours", objects["country_neighbours"].ToString());
                        oCommand.Parameters.AddWithValue("@region", objects["region"].ToString());
                        oCommand.Parameters.AddWithValue("@city", objects["city"].ToString());
                        oCommand.Parameters.AddWithValue("@latitude", objects["latitude"].ToString());
                        oCommand.Parameters.AddWithValue("@longitude", objects["longitude"].ToString());
                        oCommand.Parameters.AddWithValue("@asn", objects["asn"].ToString());
                        oCommand.Parameters.AddWithValue("@org", objects["org"].ToString());
                        oCommand.Parameters.AddWithValue("@isp", objects["isp"].ToString());
                        oCommand.Parameters.AddWithValue("@timezone", objects["timezone"].ToString());
                        oCommand.Parameters.AddWithValue("@timezone_name", objects["timezone_name"].ToString());
                        oCommand.Parameters.AddWithValue("@timezone_dstOffset", objects["timezone_dstOffset"].ToString());
                        oCommand.Parameters.AddWithValue("@timezone_gmtOffset", objects["timezone_gmtOffset"].ToString());
                        oCommand.Parameters.AddWithValue("@timezone_gmt", objects["timezone_gmt"].ToString());
                        oCommand.Parameters.AddWithValue("@currency", objects["currency"].ToString());
                        oCommand.Parameters.AddWithValue("@currency_code", objects["currency_code"].ToString());
                        oCommand.Parameters.AddWithValue("@currency_symbol", objects["currency_symbol"].ToString());
                        oCommand.Parameters.AddWithValue("@currency_rates", objects["currency_rates"].ToString());
                        oCommand.Parameters.AddWithValue("@currency_plural", objects["currency_plural"].ToString());
                        oCommand.Parameters.AddWithValue("@completed_requests", objects["completed_requests"].ToString());

                        sqlConnection.Open();
                        using (DbDataReader dbDataReader = oCommand.ExecuteReader())
                        {

                        }
                        sqlConnection.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public List<IPAddress> GetIPAddresses()
        {
            List<IPAddress> iPAddresses = new List<IPAddress>();

            String connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (DbCommand command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Gal_IpAdrese";
                sqlConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        iPAddresses.Add(new IPAddress()
                        {
                            ip = (string)reader["ip"],
                            success = (string)reader["success"],
                            type = (string)reader["type"],
                            continent = (string)reader["continent"],
                            continent_code = (string)reader["continent_code"],
                            country = (string)reader["country"],
                            country_code = (string)reader["country_code"],
                            country_flag = (string)reader["country_flag"],
                            country_capital = (string)reader["country_capital"],
                            phone = (string)reader["country_phone"],
                            country_neighbours = (string)reader["country_neighbours"],
                            region = (string)reader["region"],
                            city = (string)reader["city"],
                            latitude = (string)reader["latitude"],
                            longitude = (string)reader["longitude"],
                            asn = (string)reader["asn"],
                            org = (string)reader["org"],
                            isp = (string)reader["isp"],
                            time_zone = (string)reader["timezone"],
                            timezone_name = (string)reader["timezone_name"],
                            timezone_dstOffset = (string)reader["timezone_dstOffset"],
                            timezone_gmtOffset = (string)reader["timezone_gmtOffset"],
                            timezone_gmt = (string)reader["timezone_gmt"],
                            currency = (string)reader["currency"],
                            currency_code = (string)reader["currency_code"],
                            currency_symbol = (string)reader["currency_symbol"],
                            currency_rates = (string)reader["currency_rates"],
                            currency_plural = (string)reader["currency_plural"],
                            complete_requests = (string)reader["completed_requests"]
                        });
                    }
                }
            }
            return iPAddresses;
        }

        public void Update(IPAddress ip, string Ip)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            using (DbConnection dbConnection = new SqlConnection(connectionString))
            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                dbCommand.CommandText = "UPDATE Gal_IpAdrese SET ip = '" + ip.ip + "', success = '" + ip.success + "', type = '" + ip.type + "', continent = '" + ip.continent + "', continent_code = '" + ip.continent_code + "', country = '" + ip.country + "', country_code = '" + ip.country_code + "', country_flag ='" + ip.country_flag + "', country_capital = '" + ip.country_capital + "', country_phone = '" + ip.phone + "', country_neighbours = '" + ip.country_neighbours + "' ,region = '" + ip.region + "', city = '" + ip.city + "', latitude = '" + ip.latitude + "', longitude = '" + ip.longitude + "', asn = '" + ip.asn + "', org = '" + ip.org + "', isp = '" + ip.isp + "', timezone = '" + ip.time_zone + "', timezone_name = '" + ip.timezone_name + "', timezone_dstOffset = '" + ip.timezone_dstOffset + "', timezone_gmtOffset = '" + ip.timezone_gmtOffset + "', timezone_gmt = '" + ip.timezone_gmt + "', currency = '" + ip.currency + "', currency_code = '" + ip.currency_code + "', currency_symbol = '" + ip.currency_symbol + "', currency_rates = '" + ip.currency_rates + "', currency_plural = '" + ip.currency_plural + "', completed_requests = '" + ip.complete_requests + "' WHERE ip = '" + Ip + "'";
                dbConnection.Open();
                using (DbDataReader oReader = dbCommand.ExecuteReader())
                {

                }
            }
        }

        public void Delete(IPAddress iP)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            using (DbConnection dbConnection = new SqlConnection(connectionString))
            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                dbCommand.CommandText = "DELETE FROM Gal_IpAdrese WHERE ip = '" + iP.ip + "'";
                dbConnection.Open();
                using (DbDataReader oReader = dbCommand.ExecuteReader())
                {

                }
            }
        }
        public List<IPAddress> Filter(string ip)
        {
            var popis = GetIPAddresses();
            if (ip != "ALL")
            {
                popis = popis.Where(x => x.ip.ToLower() == ip.ToLower()).ToList();
            }
            return popis;
        }
        public List<string> GetIPs()
        {
            var popisIP = GetIPAddresses().Select(x => x.ip).Distinct().ToList();
            popisIP.Insert(0, "ALL");

            return popisIP;
        }
    }
}
