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