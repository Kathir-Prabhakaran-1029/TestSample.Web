using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestSample.Domain.Entities;
using TestSample.Persistance.DBConnectionFactory;
using TestSample.Persistance.Interface;

namespace TestSample.Persistance.Implementation
{
    public class InsurerDao : IInsurerDao
    {
        #region Private variables and constructors

        readonly IDbConnectionFactory _factory;

        public InsurerDao(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        #endregion

        public int Delete(int Id, long DeletedBy)
        {
            int result = 0;

            DynamicParameters param = new DynamicParameters();
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int64);
            param.Add("@Id", Id, dbType: DbType.Int32);

            using (IDbConnection conn = _factory.GetConnection())
            {
                conn.Open();
                string SQL = @"[usp_Insurer_Delete]";
                result = conn.Execute(sql: SQL, param: param, commandType: CommandType.StoredProcedure);
                conn.Close();
            }

            return result;
        }

        public Insurer Get(int Id)
        {
            Insurer insurer = null;
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id, DbType.Int32);
            using (IDbConnection conn = _factory.GetConnection())
            {
                conn.Open();
                string SQL = @"[usp_Insurer_Get]";
                insurer = conn.Query<Insurer>(SQL, param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                conn.Close();
            }
            return insurer;
        }

        public List<Insurer> GetAll(bool? IsActive, string Search, int Page, int NoOfRecords)
        {
            List<Insurer> insurer = null;
            DynamicParameters param = new DynamicParameters();

            if (IsActive != null)
                param.Add("@IsActive", IsActive, DbType.Boolean);

            param.Add("@Search", Search, dbType: DbType.String);

            param.Add("@Page", Page, dbType: DbType.Int32);
            param.Add("@NoOfRecords", NoOfRecords, dbType: DbType.Int32);

            using (IDbConnection conn = _factory.GetConnection())
            {
                conn.Open();
                string SQL = @"[usp_Insurer_GetAll]";
                insurer = conn.Query<Insurer>(SQL, param: param, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }
            return insurer;
        }

        public List<Insurer> GetByName(string Name, int Id)
        {
            List<Insurer> insurers = null;

            if (!string.IsNullOrEmpty(Name))
            {
                using (IDbConnection conn = _factory.GetConnection())
                {
                    conn.Open();
                    string SQL = @"[usp_Insurer_GetByName]";
                    DynamicParameters Param = new DynamicParameters();

                    if (Id > 0)
                        Param.Add("@Id", Id, DbType.Int32);

                    Param.Add("@Name", Name, DbType.String);

                    insurers = conn.Query<Insurer>(SQL, Param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }
            }
            return insurers;
        }

        public List<Insurer> GetByInternalCode(string InternalCode, int Id)
        {
            List<Insurer> insurers = null;

            if (!string.IsNullOrEmpty(InternalCode))
            {
                using (IDbConnection conn = _factory.GetConnection())
                {
                    conn.Open();
                    string SQL = @"[usp_Insurer_GetByInternalCode]";
                    DynamicParameters Param = new DynamicParameters();

                    if (Id > 0)
                        Param.Add("@Id", Id, DbType.Int32);

                    Param.Add("@InternalCode", InternalCode, DbType.String);

                    insurers = conn.Query<Insurer>(SQL, Param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }
            }
            return insurers;
        }

        public List<Insurer> GetByProductSubCategory(int ProductSubCategoryId)
        {
            List<Insurer> insurers = null;

            using (IDbConnection conn = _factory.GetConnection())
            {
                conn.Open();
                string SQL = @"[usp_Insurer_GetByProductSubCategoryId]";
                DynamicParameters Param = new DynamicParameters();

                Param.Add("@ProductSubCategoryId", ProductSubCategoryId, DbType.Int32);

                insurers = conn.Query<Insurer>(SQL, Param, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }

            return insurers;
        }

        public int Save(Insurer I, long CreatedOrModifiedBy)
        {
            int result = 0;

            DynamicParameters param = new DynamicParameters();
            param.Add("@CreatedOrModifiedBy", CreatedOrModifiedBy, dbType: DbType.Int64);
            param.Add("@SystemIp", I.SystemIp, dbType: DbType.String);

            if (I.Id > 0)
                param.Add("@Id", I.Id, dbType: DbType.Int32);

            param.Add("@Name", I.Name, dbType: DbType.String);
            param.Add("@Desc", I.Desc, dbType: DbType.String);
            param.Add("@InternalCode", I.InternalCode, dbType: DbType.String);
            param.Add("@Remarks", I.Remarks, dbType: DbType.String);
            param.Add("@IsActive", I.IsActive, dbType: DbType.Boolean);

            using (IDbConnection conn = _factory.GetConnection())
            {
                conn.Open();
                string SQL = @"[usp_Insurer_Save]";
                result = conn.Execute(sql: SQL, param: param, commandType: CommandType.StoredProcedure);
                conn.Close();
            }

            return result;
        }
    }
}