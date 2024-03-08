namespace MicroServiceUsuarios.Models
{
    public class User
    {

        public int ID_USER { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public DateTime BIRTHDAY { get; set; }
        public string USER_PHOTO { get; set; }
        public int USER_TYPE { get; set; }

    }
}
