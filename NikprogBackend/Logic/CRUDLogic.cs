using NikprogServerClient.Data;
using NikprogServerClient.Models.CourseMaterials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace NikprogServerClient.Logic
{
    public class CRUDLogic<TEntity> : ICRUDLogic<TEntity> where TEntity : class
    {
        internal ICRUDRepository<TEntity> repo;
        public CRUDLogic(ICRUDRepository<TEntity> repo)
        {
            this.repo = repo;
        }

        public virtual void Create(TEntity obj)//Plus: Chain of Responsibility
        {
            Type type = obj.GetType();
            var properties = type.GetProperties().Where(p => p.GetCustomAttribute<NotMappedAttribute>() is null).ToArray();

            bool hasSequenceNum = false;
            bool objIsCreatable = true;
            int i = 0;
            var property = properties[i];
            var propertyValue = property.GetValue(obj);
            while (objIsCreatable && i < properties.Length)
            {
                property = properties[i];
                var attributes = property.GetCustomAttributes(false).Where(attr => attr.GetType().BaseType.FullName.Contains("ValidationAttribute")).ToArray();
                propertyValue = property.GetValue(obj);

                //It sikps the vaéidation if the property name is sequenceNum
                if (!hasSequenceNum && property.Name.Equals("SequenceNum"))
                {
                    hasSequenceNum = true;
                }
                else
                {
                    //It valiadtes the constraint(s) of the property
                    int j = 0;
                    while (objIsCreatable && j < attributes.Length)
                    {
                        objIsCreatable = ((ValidationAttribute)attributes[j]).IsValid(propertyValue);

                        j++;
                    }
                }
                i++;
            }

            if (objIsCreatable && !hasSequenceNum)
            {
                repo.Create(obj);
            }
            else if (!objIsCreatable)
            {
                throw new ArgumentException($"Given parameter is inadequate! {property.Name}: {propertyValue}");
            }
        }

        public TEntity Read(string id)
        {
            return repo.Read(id);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(TEntity obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties().Where(p => p.GetCustomAttribute<NotMappedAttribute>() is null).ToArray();

            bool objIsCreatable = true;
            int i = 0;
            var property = properties[i];
            var propertyValue = property.GetValue(obj);
            while (objIsCreatable && i < properties.Length)
            {
                property = properties[i];
                var attributes = property.GetCustomAttributes(false).Where(attr => attr.GetType().BaseType.FullName.Contains("ValidationAttribute")).ToArray();
                propertyValue = property.GetValue(obj);

                int j = 0;
                while (objIsCreatable && j < attributes.Length)
                {
                    objIsCreatable = ((ValidationAttribute)attributes[j]).IsValid(propertyValue);

                    j++;
                }

                i++;
            }

            if (objIsCreatable)
            {
                repo.Update(obj);
            }
            else
            {
                throw new ArgumentException($"Given parameter is inadequate! {property.Name}: {propertyValue}");
            }
        }

        public void Delete(string id)
        {
            if (Read(id) != null)
            {
                try
                {
                    repo.Delete(id);
                }
                catch (Exception)
                {
                    throw new Exception($"You can not delete a record that is strictly bound with other records.");
                }
            }
            else
            {
                throw new ArgumentNullException($"There is no record matching the specified data (ID: {id}) to delete.");
            }
        }
    }
}
