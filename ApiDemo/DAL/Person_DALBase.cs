using ApiDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ApiDemo.DAL
{
    public class Person_DALBase : DAL_Helper
    {
        private object PersonID;

        public List<PersonModel> API_Person_SelectAll()
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Person_SelectAll");
                List<PersonModel> list = new List<PersonModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        PersonModel pm = new PersonModel();
                        pm.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                        pm.Name = dr["Name"].ToString();
                        pm.Email = dr["Email"].ToString();
                        pm.Contact = dr["Contact"].ToString();
                        list.Add(pm);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PersonModel API_Person_SelectByPK(int PersonID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Person_SelectByPK");
                sqldb.AddInParameter(cmd, "@PersonID", SqlDbType.Int, PersonID);
                PersonModel pm = new PersonModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        pm.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                        pm.Name = dr["Name"].ToString();
                        pm.Email = dr["Email"].ToString();
                        pm.Contact = dr["Contact"].ToString();
                    }

                }

                return pm;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int API_Person_Delete(int PersonID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);
                var person = sqlDatabase.ExecuteNonQuery(dbCommand);
                return person;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool API_Person_Insert(PersonModel personModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, personModel.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, personModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, personModel.Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool API_Person_Update(int PersonID, PersonModel personModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_Update");
                sqlDatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, personModel.PersonID);
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, personModel.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, personModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, personModel.Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
