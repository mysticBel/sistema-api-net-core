namespace SistemaApiWeb.DAO
{
    public class PaisDAO
    {
        private string cadena;
        public PaisDAO()
        {

            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }

    }
}
