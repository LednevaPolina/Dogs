namespace Dogs.Models
{
    public class DogDbInitializer
    {
        static public void seed(IApplicationBuilder app)
        {
            var result = app.ApplicationServices.CreateScope();
            var context = result.ServiceProvider.GetRequiredService<DogDbContext>();
            
            if (!context.Tag.Any())
            {
                context.Tag.Add(new Tag() { Name = "Охотник" });
                context.Tag.Add(new Tag() { Name = "Компаньон" });
                context.Tag.Add(new Tag() { Name = "Служебные" });
                context.Tag.Add(new Tag() { Name = "Декоративные" });
                context.SaveChanges();
            }
        }
    }
}
