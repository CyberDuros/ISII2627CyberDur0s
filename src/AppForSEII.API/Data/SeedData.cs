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

            try{
                SeedImpresoras3D(dbContext);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the Impresoras 3D in the Database.");
            }

            try {
                SeedMaterialesYPiezas3D(dbContext);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the Materiales and Piezas3D in the Database.");
            }
            try {
                SeedAccesorios(dbContext);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the Accesorios in the Database.");
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
        public static void SeedAccesorios(ApplicationDbContext dbcontext) {
            
            if (dbcontext.Accesorios.FirstOrDefault(a => a.Nombre == "Boquilla de laton") == null){
                
                dbcontext.Accesorios.Add(new Accesorio("Boquilla de laton", CategoriaAccesorio.Boquillas, "Ender 3", 30, 2.50m));

            }
            if (dbcontext.Accesorios.FirstOrDefault(a => a.Nombre == "Espátula") == null){
                
                dbcontext.Accesorios.Add(new Accesorio("Espátula", CategoriaAccesorio.Herramientas, "Todas", 15, 6.75m));

            }
            dbcontext.SaveChanges();


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


        public static void SeedImpresoras3D(ApplicationDbContext dbContext){ 
                if (dbContext.Impresoras3D.FirstOrDefault(i => i.Nombre == "Prusa MK4") == null){
                dbContext.Impresoras3D.Add(new Impresora3D("Prusa MK4", "MK4", TipoImpresora.Filamento,
                 "Impresora de filamento FDM", 0.15m, 5.00m));
            }
            if (dbContext.Impresoras3D.FirstOrDefault(i => i.Nombre == "Elegoo Saturn 3") == null){
                dbContext.Impresoras3D.Add(new Impresora3D("Elegoo Saturn 3", "Saturn 3", TipoImpresora.Resina,
                 "Impresora de resina de alta precision", 0.20m, 7.50m));

            }

            dbContext.SaveChanges();
          }


            public static void SeedMaterialesYPiezas3D(ApplicationDbContext dbcontext) {
            string[] materialesNombres = ["PLA", "PETG", "ABS", "Resina"];
            decimal[] preciosPorGramo = [0.025m, 0.030m, 0.028m, 0.090m];
            decimal[] stocksGramos = [5000m, 3000m, 0m, 1500m];
            List<Material> materiales = [];
            Pieza3D pieza;
            for(int i = 0; i < materialesNombres.Length; i++)
            {
                string nombre = materialesNombres[i];
                var material = dbcontext.Materiales.FirstOrDefault(m => m.Nombre == nombre);
                if (material == null)
                {
                    material = new Material(nombre, preciosPorGramo[i], stocksGramos[i]);
                    dbcontext.Materiales.Add(material);
                }
                materiales.Add(material);
            }
            if (dbcontext.Piezas3D.FirstOrDefault(p => p.Nombre == "Barco") == null)
            {
                pieza = new Pieza3D("Barco", 120.50m, CategoriaPieza.Decoracion);
                pieza.MaterialesValidos = new HashSet<Material> { materiales[0], materiales[1] };
                dbcontext.Piezas3D.Add(pieza);
            }
            if (dbcontext.Piezas3D.FirstOrDefault(p => p.Nombre == "Figura de la ESIIAB") == null)
            {
                pieza = new Pieza3D("Figura de la ESIIAB", 45.00m, CategoriaPieza.MiniaturasYMaquetas);
                pieza.MaterialesValidos = new HashSet<Material> { materiales[3], materiales[0] };
                dbcontext.Piezas3D.Add(pieza);
            }
             dbcontext.SaveChanges();
        }
    }
}