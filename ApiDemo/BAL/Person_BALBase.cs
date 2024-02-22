using ApiDemo.DAL;
using ApiDemo.Models;

namespace ApiDemo.BAL
{
    public class Person_BALBase
    {
        public List<PersonModel> API_Person_SelectAll()
        {
            try
            {
                Person_DALBase Person_DALBase = new Person_DALBase();
                List<PersonModel> pm = Person_DALBase.API_Person_SelectAll();
                return pm;
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
                Person_DALBase Person_DALBase = new Person_DALBase();
                PersonModel pm = Person_DALBase.API_Person_SelectByPK(PersonID);
                return pm;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int API_Person_Delete(int PersonId)
        {
            try
            {
                Person_DALBase person_DAL = new Person_DALBase();
                var person = person_DAL.API_Person_Delete(PersonId);
                return person;
            }
            catch
            {
                return 0;
            }
        }

        public bool API_Person_Insert(PersonModel personModel)
        {
            try
            {
                Person_DALBase personDALBase = new Person_DALBase();
                if (personDALBase.API_Person_Insert(personModel))
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
                Person_DALBase personDALBase = new Person_DALBase();
                if (personDALBase.API_Person_Update(PersonID, personModel))
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
