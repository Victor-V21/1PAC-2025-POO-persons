namespace Persons.API.Dtos.Persons
{
    public class PersonActionResponseDto

        //Es lo que se devuelve como resultado de una consulta
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
