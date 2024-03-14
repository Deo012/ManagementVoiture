using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using LabMVC;

namespace LabMVC.Models
{
    public class VoitureDAO
    {
        private string dp = "System.Data.SqlClient";
        private string cnString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Voiture;Integrated Security=True";
        private DbProviderFactory df;
        private DbConnection cn;
        private DbCommand cmdCommand;
        public VoitureDAO()
        {
            this.df = DbProviderFactories.GetFactory(this.dp);
            this.cn = this.df.CreateConnection();

            try
            {
                this.cn.ConnectionString = this.cnString;
                this.cn.Open();

                this.cmdCommand = this.df.CreateCommand();
                this.cmdCommand.Connection = this.cn;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erreur de connexion, exception: " + e.StackTrace.ToString());
            }
        }

        public List<VoitureVO> recupererVoitures()
        {
            List<VoitureVO> voitures = new List<VoitureVO>();
            try
            {
                df = DbProviderFactories.GetFactory(dp);

                cn = df.CreateConnection();
                
                    cn.ConnectionString = cnString;
                    cn.Open();

                    cmdCommand = df.CreateCommand();
                    cmdCommand.Connection = cn;

                    string sqlQuery = "Select * from tablVoiture";

                    cmdCommand.CommandText = sqlQuery;
                
                using (DbDataReader reader = cmdCommand.ExecuteReader()) {
                    while (reader.Read())
                    {
                        VoitureVO voiture = new VoitureVO
                        {
                            NomVoiture = reader.GetString(reader.GetOrdinal("nomVoiture")),
                            UrlImage = reader.GetString(reader.GetOrdinal("urlImage")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            Prix = reader.GetInt32(reader.GetOrdinal("prix"))

                        };
                        voitures.Add(voiture);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retriving cars: " + e.Message);
            }
            return voitures;
        }

        public string Dp { get => dp; set => dp = value; }
        public string CnString { get => cnString; set => cnString = value; }
        public DbProviderFactory Df { get => df; set => df = value; }
        public DbConnection Cn { get => cn; set => cn = value; }
    }
}