using itlathApp.Web.Exceptions;

namespace itlathApp.Web.Models
{
    public class PersonModel
    {

        private string firstName;
        public string FirstName 
        {
            get { return this.firstName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new StudentException("El campo nombre es requerido");
                else if(value.Length > 50) 
                {
                    throw new StudentException("La longitud del nombre es inválido");
                }
            }
        }
        public string LastName { get; set; }
    }
}
