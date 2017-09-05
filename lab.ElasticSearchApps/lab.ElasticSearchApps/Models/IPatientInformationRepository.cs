using lab.ElasticSearchApps.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.ElasticSearchApps.Models
{
    #region Interface Implement : PatientInformation

    public class PatientInformationRepository : IPatientInformationRepository
    {
        #region Global Variable Declaration

        private readonly AppDbContext _db = new AppDbContext();

        #endregion

        #region Constructor

        #endregion

        #region Get Method

        public IQueryable<PatientInformation> GetAll()
        {
            var patientInformations = new List<PatientInformation>();
            try
            {
                patientInformations = _db.PatientInformations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return patientInformations.AsQueryable();
        }

        public PatientInformation GetById(int id)
        {
            var patientInformation = new PatientInformation();

            try
            {
                patientInformation = _db.PatientInformations.Find(id); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patientInformation;
        }

        #endregion

        #region Create Method

        public int CreateOrUpdate(PatientInformation patientInformation)
        {
            int isSave = 0;
            try
            {
                if (patientInformation != null)
                {
                    //add
                    if (patientInformation.PatientId == default(int))
                    {
                        Create(patientInformation);
                    }
                    else //edit
                    {
                        Update(patientInformation);
                    }
                }
                else
                {
                    throw new ArgumentNullException("PatientInformation", MessageResourceHelper.NullError);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSave;
        }

        public int Create(PatientInformation patientInformation)
        {
            int isSave = 0;
            try
            {
                if (patientInformation != null)
                {
                    _db.PatientInformations.Add(patientInformation);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("PatientInformation", MessageResourceHelper.NullError);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSave;
        }

        #endregion

        #region Update Method

        public int Update(PatientInformation patientInformation)
        {
            int isSave = 0;
            try
            {
                var updatePatientInformation = GetById(patientInformation.PatientId);

                if (updatePatientInformation != null)
                {
                    _db.PatientInformations.Attach(patientInformation);
                    _db.Entry(patientInformation).State = System.Data.Entity.EntityState.Modified;

                    isSave = Save();

                }
                else
                {
                    throw new ArgumentNullException("PatientInformation", MessageResourceHelper.NullError);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        #endregion

        #region Delete Method

        public int Delete(PatientInformation patientInformation)
        {
            int isSave = 0;
            try
            {
                var deletePatientInformation = GetById(patientInformation.PatientId);

                if (deletePatientInformation != null)
                {
                    _db.PatientInformations.Remove(deletePatientInformation);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("PatientInformation", MessageResourceHelper.NullError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(int id)
        {
            int isSave = 0;
            try
            {
                var deletePatientInformation = GetById(id);
                if (deletePatientInformation != null)
                {
                    _db.PatientInformations.Remove(deletePatientInformation);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("PatientInformation", MessageResourceHelper.NullError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<PatientInformation> patientInformations)
        {
            int isSave = 0;
            try
            {
                foreach (var patientInformation in patientInformations)
                {
                    var deletePatientInformation = GetById(patientInformation.PatientId);
                    Delete(deletePatientInformation);
                }


                isSave = Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        #endregion

        #region Save By Commit

        public int Save()
        {
            return _db.SaveChanges();
        }

        #endregion

    }

    #endregion

    #region Interface : PatientInformation

    public interface IPatientInformationRepository : IGeneric<PatientInformation>
    {
        int Delete(List<PatientInformation> patientInformations);
    }

    #endregion
}