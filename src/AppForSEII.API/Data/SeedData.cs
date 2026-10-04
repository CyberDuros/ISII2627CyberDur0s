namespace AppForSEII.API.Data {
    public class SeedData {
        public static void Initialize(ApplicationDbContext dbContext, IServiceProvider serviceProvider, ILogger logger) {
            List<string> rolesNames = new List<string> { "Administrator", "Employee", "Customer" };

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            try {
                SeedRoles(roleManager, rolesNames);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the roles in the Database.");
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            try {
                SeedUsers(userManager, rolesNames);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the Users in the Database.");
            }

            try {
                SeedModelos3D(dbContext);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Ha ocurrido un error al generar los datos de la tabla Modelo3D en la base de datos.");
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager, List<string> roles) {

            foreach (string roleName in roles) {
                //it checks such role does not exist in the database 
                if (!roleManager.RoleExistsAsync(roleName).Result) {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    role.NormalizedName = roleName;
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }

        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, List<string> roles) {
            //first, it checks the user does not already exist in the DB
            if (userManager.FindByNameAsync("elena@uclm.es").Result == null) {
                ApplicationUser user = new ApplicationUser("1", "Elena", "Navarro Martínez", "elena@uclm.es");
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "Password1234%");
                result.Wait();

                if (result.IsCompletedSuccessfully) {
                    //administrator role
                    userManager.AddToRoleAsync(user, roles[0]).Wait();
                }
            }


            if (userManager.FindByNameAsync("peter@uclm.es").Result == null) {
                //A customer class has been defined because it has different attributes (purchase, rental, etc.)
                ApplicationUser user = new ApplicationUser("3", "Peter", "Jackson", "peter@uclm.es");
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "OtherPass12$");

                result.Wait();

                if (result.IsCompletedSuccessfully) {
                    //customer role
                    userManager.AddToRoleAsync(user, roles[2]).Wait();

                }
            }

        }

        //Metodo para para generar datos en la tabla Modelos3D de la base de datos
        public static void SeedModelos3D(ApplicationDbContext dbContext)
        {
            //Comprobamos si ya hay modelos 3D en la base de datos, si no los hay, los creamos
            if (!dbContext.Modelos3D.Any())
            {
                // Creamos las licencias de ejemplo
                var licenciaPersonal = new LicenciaModelo3D("Licencia personal", DateTime.Today.AddYears(1));
                var licenciaComercial = new LicenciaModelo3D("Licencia comercial", DateTime.Today.AddDays(15));
                //Las añadimos al DbContext
                dbContext.LicenciasModelo3D.Add(licenciaComercial);
                dbContext.LicenciasModelo3D.Add(licenciaPersonal);

                //A la misma vez que creamos 3 ejemplos de modelos 3D, les asignamos una licencia a cada uno
                //y los añadimos en el DbContext
                dbContext.Modelos3D.AddRange(
                    new Modelo3D
                    {
                        Nombre = "Maceta geometrica",
                        Categoria = "Decoracion",
                        Formato = FormatoModelo3D.OBJ,
                        Precio = 10.99m,
                        Licencia = licenciaPersonal
                    },
                    new Modelo3D
                    {
                        Nombre = "Soporte para mando",
                        Categoria = "Accesorios",
                        Formato = FormatoModelo3D.TresMF,
                        Precio = 15.99m,
                        Licencia = licenciaComercial
                    },
                    new Modelo3D
                    {
                        Nombre = "Dragon articulado",
                        Categoria = "Miniaturas",
                        Formato = FormatoModelo3D.STL,
                        Precio = 7.50m,
                        Licencia = licenciaPersonal
                    });
                dbContext.SaveChanges();
            }
        }
    }
}