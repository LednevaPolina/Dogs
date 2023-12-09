namespace Dogs.Models
{
    public class DogDbInitializer
    {
        static public void seed(IApplicationBuilder app)
        {
            var result = app.ApplicationServices.CreateScope();
            var context = result.ServiceProvider.GetRequiredService<DogDbContext>();
            
            if (!context.Tags.Any())
            {
                context.Tags.Add(new Tag() { Name = "Охотничьи" });
                context.Tags.Add(new Tag() { Name = "Гончие" });
                context.Tags.Add(new Tag() { Name = "Подружейные" });
                context.Tags.Add(new Tag() { Name = "Служебные" });
                context.Tags.Add(new Tag() { Name = "Пастушьи" });
                context.Tags.Add(new Tag() { Name = "Охранные" });
                context.Tags.Add(new Tag() { Name = "Ездовые" });
                context.Tags.Add(new Tag() { Name = "Компаньоны" });
                context.Tags.Add(new Tag() { Name = "Декоративные" });                
                context.SaveChanges();
            }

            if (!context.FCICategories.Any())
            {
                context.FCICategories.Add(new FCICategory() { Name = "1" });
                context.FCICategories.Add(new FCICategory() { Name = "2" });
                context.FCICategories.Add(new FCICategory() { Name = "3" });
                context.FCICategories.Add(new FCICategory() { Name = "4" });
                context.FCICategories.Add(new FCICategory() { Name = "5" });
                context.FCICategories.Add(new FCICategory() { Name = "6" });
                context.FCICategories.Add(new FCICategory() { Name = "7" });
                context.FCICategories.Add(new FCICategory() { Name = "8" });
                context.FCICategories.Add(new FCICategory() { Name = "9" });
                context.FCICategories.Add(new FCICategory() { Name = "10" });
                context.FCICategories.Add(new FCICategory() { Name = "Непризнанные" });
                context.SaveChanges();
            }
        }
    }
}
